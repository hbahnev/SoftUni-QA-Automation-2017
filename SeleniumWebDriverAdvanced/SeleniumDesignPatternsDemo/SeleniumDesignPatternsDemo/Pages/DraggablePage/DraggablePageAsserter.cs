using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.DraggablePage
{
    public static class DraggablePageAsserter
    {
        public static void AssertFirstTabSourceAttribute(this DraggablePage page, string text)
        {
            Assert.AreEqual(text, page.SourceFirstTab.GetAttribute("class"));
        }

        public static void AssertFirstTabSourceLocation(this DraggablePage page)
        {
            Assert.AreNotSame(page.SourceFirstTab.Location, page.SourceFirstTab.Location);
        }

        public static void AssertSecondTabVerticalSourceAttribute(this DraggablePage page, string text)
        {
            Assert.AreEqual(text, page.SourceVerticalSecondTab.GetAttribute("class"));
        }

        public static void AssertSecondTabVerticalSourceLocation(this DraggablePage page)
        {
            Assert.AreNotSame(page.SourceVerticalSecondTab.Location, page.SourceFirstTab.Location);
        }

        public static void AssertSecondTabHorizontalSourceAttribute(this DraggablePage page, string text)
        {
            Assert.AreEqual(text, page.SourceHorizontalSecondTab.GetAttribute("class"));
        }

        public static void AssertSecondTabHorizontalSourceLocation(this DraggablePage page)
        {
            Assert.AreNotSame(page.SourceHorizontalSecondTab.Location, page.SourceFirstTab.Location);
        }
    }
}