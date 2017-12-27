using RufaPoint.Services.Seo;
using RufaPoint.Tests;
using Xunit;

namespace RufaPoint.Services.Tests.Seo
{
    public class SeoExtensionsTests
    {
        [Fact]
        public void Should_return_lowercase()
        {
            SeoExtensions.GetSeName("tEsT", false, false).ShouldEqual("test");
        }

        [Fact]
        public void Should_allow_all_latin_chars()
        {
            SeoExtensions.GetSeName("abcdefghijklmnopqrstuvwxyz1234567890", false, false).ShouldEqual("abcdefghijklmnopqrstuvwxyz1234567890");
        }

        [Fact]
        public void Should_remove_illegal_chars()
        {
            SeoExtensions.GetSeName("test!@#$%^&*()+<>?/", false, false).ShouldEqual("test");
        }

        [Fact]
        public void Should_replace_space_with_dash()
        {
            SeoExtensions.GetSeName("test test", false, false).ShouldEqual("test-test");
            SeoExtensions.GetSeName("test     test", false, false).ShouldEqual("test-test");
        }

        [Fact]
        public void Can_convert_non_western_chars()
        {
            //German letters with diacritics
            SeoExtensions.GetSeName("testäöü", true, false).ShouldEqual("testaou");
            SeoExtensions.GetSeName("testäöü", false, false).ShouldEqual("test");
        }

        [Fact]
        public void Can_allow_unicode_chars()
        {
            //Russian letters
            SeoExtensions.GetSeName("testтест", false, true).ShouldEqual("testтест");
            SeoExtensions.GetSeName("testтест", false, false).ShouldEqual("test");
        }
    }
}



