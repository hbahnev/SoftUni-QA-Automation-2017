using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.ResizablePage
{
    public static class ResizablePageAsserter
    {
        public static void AssertNewSize(this ResizablePage page)
        {
            Assert.IsTrue(page.resizeWindow.Size.Width > 232 && page.resizeWindow.Size.Width < 235);
            Assert.IsTrue(page.resizeWindow.Size.Height > 232 && page.resizeWindow.Size.Height < 235);
        }

        public static void AssertNewSizeWidth(this ResizablePage page)
        {
            Assert.IsTrue(page.resizeWindow.Size.Width > 232 && page.resizeWindow.Size.Width < 235);
            Assert.IsTrue(page.resizeWindow.Size.Height == 150 && page.resizeWindow.Size.Height == 150);
        }

        public static void AssertNewSizeHeight(this ResizablePage page)
        {
            Assert.IsTrue(page.resizeWindow.Size.Width == 150 && page.resizeWindow.Size.Width == 150);
            Assert.IsTrue(page.resizeWindow.Size.Height > 232 && page.resizeWindow.Size.Height < 235);
        }

        public static void AssertWindowAttribute(this ResizablePage page, string text)
        {
            Assert.AreEqual(text, page.resizeWindow.GetAttribute("class"));
        }
    }
}