using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.SortablePage
{
    public partial class SortablePage : BasePage
    {
        public SortablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return url + "sortable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void DragAndDrop()
        {
            var builder = new Actions(this.Driver);

            var drag = builder.DragAndDrop(this.firstItem, this.secondItem);

            drag.Perform();
        }

        public void ReverseDragAndDrop()
        {
            var builder = new Actions(this.Driver);

            var drag = builder.DragAndDrop(this.secondItem, this.firstItem);

            drag.Perform();
        }

        public void SortWithoutDropping()
        {
            var builder = new Actions(this.Driver);

            var drag = builder.ClickAndHold(firstItem).MoveByOffset(10, 10);

            drag.Perform();
        }
    }
}
