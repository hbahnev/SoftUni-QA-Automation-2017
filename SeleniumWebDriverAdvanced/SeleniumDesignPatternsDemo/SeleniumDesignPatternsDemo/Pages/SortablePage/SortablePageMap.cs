using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.SortablePage
{
    public partial class SortablePage
    {
        public IWebElement firstItem
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[1]"));
            }
        }

        public IWebElement secondItem
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[2]"));
            }
        }

        public IWebElement lastItem
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[7]"));
            }
        }
    }
}