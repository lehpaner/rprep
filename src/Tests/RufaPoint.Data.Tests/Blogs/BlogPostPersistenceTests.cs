using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.Blogs
{

    public class BlogPostPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_blogPost()
        {
            var blogPost = this.GetTestBlogPost();

            var fromDb = SaveAndLoadEntity(this.GetTestBlogPost());
            fromDb.ShouldNotBeNull();
            fromDb.PropertiesShouldEqual(blogPost);

            fromDb.Language.ShouldNotBeNull();
            fromDb.Language.PropertiesShouldEqual(blogPost.Language);
        }

        [Fact]
        public void Can_save_and_load_blogPost_with_blogComments()
        {
            var blogPost = this.GetTestBlogPost();

            blogPost.BlogComments.Add(this.GetTestBlogComment());
            var fromDb = SaveAndLoadEntity(blogPost);
            fromDb.ShouldNotBeNull();

            fromDb.BlogComments.ShouldNotBeNull();
            (fromDb.BlogComments.Count == 1).ShouldBeTrue();
            fromDb.BlogComments.First().IsApproved.ShouldEqual(true);
            fromDb.BlogComments.First().Store.ShouldNotBeNull();
        }        
    }
}
