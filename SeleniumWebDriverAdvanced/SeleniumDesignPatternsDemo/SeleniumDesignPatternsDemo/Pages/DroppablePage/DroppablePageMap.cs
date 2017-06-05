using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.DroppablePage
{
    public partial class DroppablePage
    {
        public IWebElement Source
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id=\"draggableview\"]/p"));
            }
        }

        public IWebElement Target
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id=\"droppableview\"]"));
            }
        }

        public IWebElement SourceNotDroppable
        {
            get
            {
                return Driver.FindElement(By.Id("draggable-nonvalid"));
            }
        }

        public IWebElement TargetSecondTab
        {
            get
            {
                return Driver.FindElement(By.Id("droppableaccept"));
            }
        }

        public IWebElement SourceSecondTabDrag
        {
            get
            {
                return Driver.FindElement(By.Id("draggableaccept"));
            }
        }
    }
}