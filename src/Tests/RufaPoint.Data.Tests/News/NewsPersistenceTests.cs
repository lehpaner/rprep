using System.Linq;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Data.Tests.News
{

    public class NewsPersistenceTests : PersistenceTest
    {
        [Fact]
        public void Can_save_and_load_newsItem()
        {
            var news = this.GetTestNewsItem();
            news.Language = this.GetTestLanguage();

            var fromDb = SaveAndLoadEntity(news);
            fromDb.PropertiesShouldEqual(this.GetTestNewsItem());
            fromDb.Language.ShouldNotBeNull();
            fromDb.Language.PropertiesShouldEqual(this.GetTestLanguage());
        }

        [Fact]
        public void Can_save_and_load_newsItem_with_comments()
        {
            var news = this.GetTestNewsItem();
            news.Language = this.GetTestLanguage();
            news.NewsComments.Add(this.GetTestNewsComment());

            var fromDb = SaveAndLoadEntity(news);
            fromDb.ShouldNotBeNull();

            fromDb.NewsComments.ShouldNotBeNull();
            (fromDb.NewsComments.Count == 1).ShouldBeTrue();
            fromDb.NewsComments.First().PropertiesShouldEqual(this.GetTestNewsComment());
        }
    }
}
