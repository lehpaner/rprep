﻿using RufaPoint.Core.Domain.Blogs;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Core.Tests.Domain.Blogs
{

    public class BlogPostTests
    {
        [Fact]
        public void Can_parse_tags()
        {
            var blogPost = new BlogPost
            {
                Tags = "tag1, tag2, tag 3 4,  "
            };

            var tags = blogPost.ParseTags();
            tags.Length.ShouldEqual(3);
            tags[0].ShouldEqual("tag1");
            tags[1].ShouldEqual("tag2");
            tags[2].ShouldEqual("tag 3 4");
        }
    }
}
