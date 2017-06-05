using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumDesignPatternsDemo.Pages.DroppablePage
{
    public partial class DroppablePage : BasePage
    {
        public DroppablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return url + "droppable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void NavigateToSecondTab()
        {
            var secondTab = "#tabs-2";
            this.Driver.Navigate().GoToUrl(this.URL + secondTab);
        }

        public void DragAndDrop()
        {
            var builder = new Actions(this.Driver);

            var drag = builder.DragAndDrop(this.Source, this.Target);

            drag.Perform();
        }

        public void DragAndDropSecondTab()
        {
            var builder = new Actions(this.Driver);

            var drag = builder.DragAndDrop(this.SourceSecondTabDrag, this.TargetSecondTab);

            drag.Perform();
        }
    }
}