using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.SelectablePage
{
    public partial class SelectablePage : BasePage
    {
        public SelectablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return url + "selectable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void DragAndDropOneItem()
        {
            var builder = new Actions(this.Driver);

            var drag = builder.DragAndDropToOffset(firstItem, 1, 1);

            drag.Perform();
        }

        public void DragAndDropTwoItems()
        {
            var builder = new Actions(this.Driver);

            var drag = builder.DragAndDropToOffset(firstItem, 1, 45);

            drag.Perform();
        }

        public void SelectItemWithoutDropping()
        {
            var builder = new Actions(this.Driver);

            var drag = builder.ClickAndHold(firstItem).MoveByOffset(1, 1);

            drag.Perform();
        }
    }
}
