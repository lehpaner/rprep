﻿using RufaPoint.Web.Framework.Mvc.Models;

namespace RufaPoint.Web.Models.Profile
{
    public partial class PostsModel : BaseNopModel
    {
        public int ForumTopicId { get; set; }
        public string ForumTopicTitle { get; set; }
        public string ForumTopicSlug { get; set; }
        public string ForumPostText { get; set; }
        public string Posted { get; set; }
    }
}