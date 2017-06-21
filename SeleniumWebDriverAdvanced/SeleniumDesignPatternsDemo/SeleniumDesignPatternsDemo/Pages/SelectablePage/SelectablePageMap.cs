using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.SelectablePage
{
    public partial class SelectablePage
    {
        public IWebElement firstItem
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[1]"));
            }
        }

        public IWebElement secondItem
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[2]"));
            }
        }
    }
}