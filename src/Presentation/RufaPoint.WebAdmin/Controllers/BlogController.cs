﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RufaPoint.Core;
using RufaPoint.Core.Domain.Blogs;
using RufaPoint.Core.Domain.Customers;
using RufaPoint.Core.Domain.Localization;
using RufaPoint.Services.Blogs;
using RufaPoint.Services.Events;
using RufaPoint.Services.Localization;
using RufaPoint.Services.Logging;
using RufaPoint.Services.Messages;
using RufaPoint.Services.Security;
using RufaPoint.Services.Seo;
using RufaPoint.Services.Stores;
using RufaPoint.Web.Factories;
using RufaPoint.Web.Framework;
using RufaPoint.Web.Framework.Controllers;
using RufaPoint.Web.Framework.Mvc;
using RufaPoint.Web.Framework.Mvc.Filters;
using RufaPoint.Web.Framework.Mvc.Rss;
using RufaPoint.Web.Framework.Security;
using RufaPoint.Web.Framework.Security.Captcha;
using RufaPoint.Web.Models.Blogs;

namespace RufaPoint.Web.Controllers
{
    [HttpsRequirement(SslRequirement.No)]
    public partial class BlogController : BasePublicController
    {
        #region Fields

        private readonly IBlogService _blogService;
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly ILocalizationService _localizationService;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IWebHelper _webHelper;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IPermissionService _permissionService;
        private readonly IBlogModelFactory _blogModelFactory;
        private readonly IEventPublisher _eventPublisher;

        private readonly BlogSettings _blogSettings;
        private readonly LocalizationSettings _localizationSettings;
        private readonly CaptchaSettings _captchaSettings;
        
        #endregion
        
        #region Ctor

        public BlogController(IBlogService blogService,
            IWorkContext workContext,
            IStoreContext storeContext,
            ILocalizationService localizationService,
            IWorkflowMessageService workflowMessageService,
            IWebHelper webHelper,
            ICustomerActivityService customerActivityService,
            IStoreMappingService storeMappingService,
            IPermissionService permissionService,
            IBlogModelFactory blogModelFactory,
            IEventPublisher eventPublisher,
            BlogSettings blogSettings,
            LocalizationSettings localizationSettings,
            CaptchaSettings captchaSettings)
        {
            this._blogService = blogService;
            this._workContext = workContext;
            this._storeContext = storeContext;
            this._localizationService = localizationService;
            this._workflowMessageService = workflowMessageService;
            this._webHelper = webHelper;
            this._customerActivityService = customerActivityService;
            this._storeMappingService = storeMappingService;
            this._permissionService = permissionService;
            this._blogModelFactory = blogModelFactory;
            this._eventPublisher = eventPublisher;

            this._blogSettings = blogSettings;
            this._localizationSettings = localizationSettings;
            this._captchaSettings = captchaSettings;
        }
        
        #endregion
        
        #region Methods

        public virtual IActionResult List(BlogPagingFilteringModel command)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("HomePage");

            var model = _blogModelFactory.PrepareBlogPostListModel(command);
            return View("List", model);
        }

        public virtual IActionResult BlogByTag(BlogPagingFilteringModel command)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("HomePage");

            var model = _blogModelFactory.PrepareBlogPostListModel(command);
            return View("List", model);
        }

        public virtual IActionResult BlogByMonth(BlogPagingFilteringModel command)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("HomePage");

            var model = _blogModelFactory.PrepareBlogPostListModel(command);
            return View("List", model);
        }

        public virtual IActionResult ListRss(int languageId)
        {
            var feed = new RssFeed(
                $"{_storeContext.CurrentStore.GetLocalized(x => x.Name)}: Blog",
                "Blog",
                new Uri(_webHelper.GetStoreLocation()),
                DateTime.UtcNow);

            if (!_blogSettings.Enabled)
                return new RssActionResult(feed, _webHelper.GetThisPageUrl(false));

            var items = new List<RssItem>();
            var blogPosts = _blogService.GetAllBlogPosts(_storeContext.CurrentStore.Id, languageId);
            foreach (var blogPost in blogPosts)
            {
                var blogPostUrl = Url.RouteUrl("BlogPost", new { SeName = blogPost.GetSeName(blogPost.LanguageId, ensureTwoPublishedLanguages: false) }, _webHelper.IsCurrentConnectionSecured() ? "https" : "http");
                items.Add(new RssItem(blogPost.Title, blogPost.Body, new Uri(blogPostUrl),
                    $"urn:store:{_storeContext.CurrentStore.Id}:blog:post:{blogPost.Id}", blogPost.CreatedOnUtc));
            }
            feed.Items = items;
            return new RssActionResult(feed, _webHelper.GetThisPageUrl(false));
        }

        public virtual IActionResult BlogPost(int blogPostId)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("HomePage");

            var blogPost = _blogService.GetBlogPostById(blogPostId);
            if (blogPost == null ||
                (blogPost.StartDateUtc.HasValue && blogPost.StartDateUtc.Value >= DateTime.UtcNow) ||
                (blogPost.EndDateUtc.HasValue && blogPost.EndDateUtc.Value <= DateTime.UtcNow))
                return RedirectToRoute("HomePage");

            //Store mapping
            if (!_storeMappingService.Authorize(blogPost))
                return InvokeHttp404();
            
            //display "edit" (manage) link
            if (_permissionService.Authorize(StandardPermissionProvider.AccessAdminPanel) && _permissionService.Authorize(StandardPermissionProvider.ManageBlog))
                DisplayEditLink(Url.Action("Edit", "Blog", new { id = blogPost.Id, area = AreaNames.Admin }));

            var model = new BlogPostModel();
            _blogModelFactory.PrepareBlogPostModel(model, blogPost, true);

            return View(model);
        }

        [HttpPost, ActionName("BlogPost")]
        [PublicAntiForgery]
        [FormValueRequired("add-comment")]
        [ValidateCaptcha]
        public virtual IActionResult BlogCommentAdd(int blogPostId, BlogPostModel model, bool captchaValid)
        {
            if (!_blogSettings.Enabled)
                return RedirectToRoute("HomePage");

            var blogPost = _blogService.GetBlogPostById(blogPostId);
            if (blogPost == null || !blogPost.AllowComments)
                return RedirectToRoute("HomePage");

            if (_workContext.CurrentCustomer.IsGuest() && !_blogSettings.AllowNotRegisteredUsersToLeaveComments)
            {
                ModelState.AddModelError("", _localizationService.GetResource("Blog.Comments.OnlyRegisteredUsersLeaveComments"));
            }

            //validate CAPTCHA
            if (_captchaSettings.Enabled && _captchaSettings.ShowOnBlogCommentPage && !captchaValid)
            {
                ModelState.AddModelError("", _captchaSettings.GetWrongCaptchaMessage(_localizationService));
            }

            if (ModelState.IsValid)
            {
                var comment = new BlogComment
                {
                    BlogPostId = blogPost.Id,
                    CustomerId = _workContext.CurrentCustomer.Id,
                    CommentText = model.AddNewComment.CommentText,
                    IsApproved = !_blogSettings.BlogCommentsMustBeApproved,
                    StoreId = _storeContext.CurrentStore.Id,
                    CreatedOnUtc = DateTime.UtcNow,
                };
                blogPost.BlogComments.Add(comment);
                _blogService.UpdateBlogPost(blogPost);

                //notify a store owner
                if (_blogSettings.NotifyAboutNewBlogComments)
                    _workflowMessageService.SendBlogCommentNotificationMessage(comment, _localizationSettings.DefaultAdminLanguageId);

                //activity log
                _customerActivityService.InsertActivity("PublicStore.AddBlogComment", _localizationService.GetResource("ActivityLog.PublicStore.AddBlogComment"));

                //raise event
                if (comment.IsApproved)
                    _eventPublisher.Publish(new BlogCommentApprovedEvent(comment));

                //The text boxes should be cleared after a comment has been posted
                //That' why we reload the page
                TempData["nop.blog.addcomment.result"] = comment.IsApproved
                    ? _localizationService.GetResource("Blog.Comments.SuccessfullyAdded")
                    : _localizationService.GetResource("Blog.Comments.SeeAfterApproving");
                return RedirectToRoute("BlogPost", new { SeName = blogPost.GetSeName(blogPost.LanguageId, ensureTwoPublishedLanguages: false) });
            }

            //If we got this far, something failed, redisplay form
            _blogModelFactory.PrepareBlogPostModel(model, blogPost, true);
            return View(model);
        }
        
        #endregion
    }
}
