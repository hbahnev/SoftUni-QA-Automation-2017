using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.HomePage
{
    public static class HomePageAsserter
    {
        public static void AssertHomePageIsOpen(this HomePage page, string text)
        {
            Assert.AreEqual(text, page.HomePageHeader.Text);
        }
    }
}
