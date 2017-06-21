using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.DraggablePage
{
    public partial class DraggablePage
    {
        public IWebElement SourceFirstTab
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggable"));
            }
        }

        public IWebElement SourceVerticalSecondTab
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggabl"));
            }
        }

        public IWebElement SourceHorizontalSecondTab
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggabl2"));
            }
        }
    }
}