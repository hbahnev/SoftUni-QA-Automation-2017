using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace SeleniumDesignPatternsDemo.Pages.DraggablePage
{
    public partial class DraggablePage : BasePage
    {
        public DraggablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return url + "draggable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void NavigateToSecondTab()
        {
            var secondTab = "#tabs-3";
            this.Driver.Navigate().GoToUrl(this.URL + secondTab);
        }

        public void DragFirstTab()
        {
            var builder = new Actions(this.Driver);

            var drag = builder.ClickAndHold(SourceFirstTab).MoveByOffset(10, 10);

            drag.Perform();
        }

        public void DragVertical()
        {
            var builder = new Actions(this.Driver);

            var drag = builder.ClickAndHold(SourceVerticalSecondTab).MoveByOffset(0, 15);

            drag.Perform();
        }

        public void DragHorizontal()
        {
            var builder = new Actions(this.Driver);

            var drag = builder.ClickAndHold(SourceHorizontalSecondTab).MoveByOffset(15, 0);

            drag.Perform();
        }
    }
}