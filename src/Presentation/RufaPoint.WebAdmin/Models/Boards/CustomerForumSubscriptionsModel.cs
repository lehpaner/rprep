﻿using System.Collections.Generic;
using RufaPoint.Web.Framework.Mvc.Models;
using RufaPoint.Web.Models.Common;

namespace RufaPoint.Web.Models.Boards
{
    public partial class CustomerForumSubscriptionsModel : BaseNopModel
    {
        public CustomerForumSubscriptionsModel()
        {
            this.ForumSubscriptions = new List<ForumSubscriptionModel>();
        }

        public IList<ForumSubscriptionModel> ForumSubscriptions { get; set; }
        public PagerModel PagerModel { get; set; }

        #region Nested classes

        public partial class ForumSubscriptionModel : BaseNopEntityModel
        {
            public int ForumId { get; set; }
            public int ForumTopicId { get; set; }
            public bool TopicSubscription { get; set; }
            public string Title { get; set; }
            public string Slug { get; set; }
        }

        #endregion
    }
}