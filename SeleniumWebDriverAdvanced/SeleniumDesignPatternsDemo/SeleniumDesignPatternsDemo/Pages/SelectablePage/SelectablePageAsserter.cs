using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.SelectablePage
{
    public static class SelectablePageAsserter
    {
        public static void AssertSelectedItemAttribute(this SelectablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.firstItem.GetAttribute("class"));
        }

        public static void AssertSelectedItemAttributeForTwoItems(this SelectablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.firstItem.GetAttribute("class"));
            Assert.AreEqual(classValue, page.secondItem.GetAttribute("class"));
        }

        public static void AssertSelectedItemAttributeWhenDragging(this SelectablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.firstItem.GetAttribute("class"));
        }
    }
}