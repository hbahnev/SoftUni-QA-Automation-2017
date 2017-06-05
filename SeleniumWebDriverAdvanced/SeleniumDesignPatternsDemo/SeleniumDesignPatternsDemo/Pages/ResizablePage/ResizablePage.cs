using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace SeleniumDesignPatternsDemo.Pages.ResizablePage
{
    public partial class ResizablePage : BasePage
    {
        public ResizablePage(IWebDriver driver) : base(driver)
        {
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public string URL
        {
            get
            {
                return url + "resizable/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void IncreaseWidthAndHeightBy(int increaseWidth, int increaseHeight)
        {
            var builder = new Actions(this.Driver);

            var resize = builder.DragAndDropToOffset(resizeButton, increaseWidth, increaseHeight);

            resize.Perform();
        }

        public void ResizeWindowWithoutDropping()
        {
            var builder = new Actions(this.Driver);

            var drag = builder.ClickAndHold(resizeButton).MoveByOffset(10, 10);

            drag.Perform();
        }
    }
}