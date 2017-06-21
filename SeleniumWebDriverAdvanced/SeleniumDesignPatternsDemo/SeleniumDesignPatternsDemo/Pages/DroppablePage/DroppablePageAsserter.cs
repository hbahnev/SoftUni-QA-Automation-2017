using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.DroppablePage
{
    public static class DroppablePageAsserter
    {
        public static void AssertTargetAttributeValue(this DroppablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.Target.GetAttribute("class"));
        }

        public static void AssertTargetAttributeValueId(this DroppablePage page, string idValue)
        {
            Assert.AreEqual(idValue, page.Target.GetAttribute("id"));
        }

        public static void AssertTargetText(this DroppablePage page, string text)
        {
            Assert.AreEqual(page.Target.Text, text);
        }

        public static void AssertTextSecondTarget(this DroppablePage page, string text)
        {
            Assert.AreEqual(page.TargetSecondTab.Text, text);
        }

        public static void AssertSecondTabTargetAttributeValue(this DroppablePage page, string classValue)
        {
            Assert.AreEqual(classValue, page.TargetSecondTab.GetAttribute("class"));
        }
    }
}