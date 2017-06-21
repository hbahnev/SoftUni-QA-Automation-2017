using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.SortablePage
{
    public static class SortablePageAsserter
    {
        public static void AssertTargetLocation(this SortablePage page)
        {
            Assert.IsTrue(page.secondItem.Location.Y > page.firstItem.Location.Y);
        }

        public static void AssertSortingItemAttribute(this SortablePage page, string text)
        {
            Assert.AreEqual(page.firstItem.GetAttribute("class"), text);
        }
    }
}