using SeleniumDesignPatternsDemo.Pages.AutomationPracticePage;
using SeleniumDesignPatternsDemo.Pages.DraggablePage;
using SeleniumDesignPatternsDemo.Pages.DroppablePage;
using SeleniumDesignPatternsDemo.Pages.ResizablePage;
using SeleniumDesignPatternsDemo.Pages.SelectablePage;
using SeleniumDesignPatternsDemo.Pages.SortablePage;
using SeleniumDesignPatternsDemo.Pages.ToolsQAHomePage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Models;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDesignPatternsDemo
{
    [TestFixture]
    public class ToolsQATests
    {
        private IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            var logFile = ConfigurationManager.AppSettings["Logs"] + "log" + ".txt";
            File.AppendAllText(logFile, TestContext.CurrentContext.Result.Outcome + " ... " +
                TestContext.CurrentContext.Test.FullName + " ... " +
                TestContext.CurrentContext.Test.Name + Environment.NewLine);

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var fileNameLog = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";

                if (File.Exists(fileNameLog))
                {
                    File.Delete(fileNameLog);
                }
                File.WriteAllText(fileNameLog, TestContext.CurrentContext.Test.FullName + " ... " + TestContext.CurrentContext.Result.FailCount);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                var fileNameScreenshot = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name;

                if (File.Exists(fileNameScreenshot))
                {
                    File.Delete(fileNameScreenshot);
                }
                screenshot.SaveAsFile(fileNameScreenshot + ".jpeg", ScreenshotImageFormat.Jpeg);
            }

            driver.Quit();
        }




        [Test]
        [Property("PopUp", "3")]
        public void HandlePopUp()
        {
            var automationPage = new AutomationPage(driver);
            var homePage = new ToolsQAHomePage(driver);

            automationPage.NavigateTo();
            automationPage.NewTabButton.Click();
            this.driver.SwitchTo().ActiveElement();
            var secondTab = this.driver.WindowHandles.Last();

            Assert.AreEqual("http://toolsqa.com/wp-content/uploads/2014/08/Toolsqa.jpg",
                homePage.Logo.GetAttribute("src"));
            Assert.AreEqual(2, driver.WindowHandles.Count);
        }
    
        [Test]
        [Property("Droppable", "1")]
        public void DroppableFirstTest()
        {
            var droppablePage = new DroppablePage(driver);

            droppablePage.NavigateTo();
            droppablePage.DragAndDrop();

            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");
        }

        [Test]
        [Property("Droppable", "1")]
        public void DroppableSecondTest()
        {
            var droppablePage = new DroppablePage(driver);

            droppablePage.NavigateTo();
            droppablePage.DragAndDrop();

            droppablePage.AssertTargetAttributeValueId("droppableview");
        }

        [Test]
        [Property("Droppable", "1")]
        public void DroppableThirdTest()
        {
            var droppablePage = new DroppablePage(driver);

            droppablePage.NavigateTo();
            droppablePage.DragAndDrop();

            droppablePage.AssertTargetText("Dropped!");
        }

        [Test]
        [Property("Droppable", "1")]
        public void DroppableFourthTest()
        {
            var droppablePage = new DroppablePage(driver);

            droppablePage.NavigateToSecondTab();
            droppablePage.DragAndDrop();

            droppablePage.AssertTargetAttributeValue("ui-widget-header ui-droppable");
        }

        [Test]
        [Property("Droppable", "1")]
        public void DroppableFifthTest()
        {
            var droppablePage = new DroppablePage(driver);

            droppablePage.NavigateToSecondTab();
            droppablePage.DragAndDropSecondTab();

            droppablePage.AssertSecondTabTargetAttributeValue("ui-widget-header ui-droppable ui-state-highlight");
        }

        [Test]
        [Property("Droppable", "1")]
        public void DroppableSixthTest()
        {
            var droppablePage = new DroppablePage(driver);

            droppablePage.NavigateToSecondTab();
            droppablePage.DragAndDropSecondTab();

            droppablePage.AssertTextSecondTarget("you can find a screenshot of the this failed test!");
        }
    
        [Test]
        [Property("Draggable", "1")]
        public void DraggableFirstTest()
        {
            var draggablePage = new DraggablePage(driver);

            draggablePage.NavigateTo();
            draggablePage.DragFirstTab();

            draggablePage.AssertFirstTabSourceAttribute("ui-widget-content ui-draggable ui-draggable-handle ui-draggable-dragging");
        }

        [Test]
        [Property("Draggable", "1")]
        public void DraggableSecondTest()
        {
            var draggablePage = new DraggablePage(driver);

            draggablePage.NavigateTo();
            draggablePage.DragFirstTab();

            draggablePage.AssertFirstTabSourceLocation();
        }

        [Test]
        [Property("Draggable", "1")]
        public void DraggableThirdTest()
        {
            var draggablePage = new DraggablePage(driver);

            draggablePage.NavigateToSecondTab();
            draggablePage.DragVertical();

            draggablePage.AssertSecondTabVerticalSourceLocation();
        }

        [Test]
        [Property("Draggable", "1")]
        public void DraggableFourthTest()
        {
            var draggablePage = new DraggablePage(driver);

            draggablePage.NavigateToSecondTab();
            draggablePage.DragVertical();

            draggablePage.AssertSecondTabVerticalSourceAttribute("draggable ui-widget-content ui-draggable ui-draggable-handle ui-draggable-dragging");
        }

        [Test]
        [Property("Draggable", "1")]
        public void DraggableFifthTest()
        {
            var draggablePage = new DraggablePage(driver);

            draggablePage.NavigateToSecondTab();
            draggablePage.DragHorizontal();

            draggablePage.AssertSecondTabHorizontalSourceLocation();
        }

        [Test]
        [Property("Draggable", "1")]
        public void DraggableSixthTest()
        {
            var draggablePage = new DraggablePage(driver);

            draggablePage.NavigateToSecondTab();
            draggablePage.DragHorizontal();

            draggablePage.AssertSecondTabHorizontalSourceAttribute("draggable ui-widget-content ui-draggable ui-draggable-handle ui-draggable-dragging");
        }

        [Test]
        [Property("Resizable", "1")]
        public void ResizableFirstTest()
        {
            var resizablePage = new ResizablePage(driver);

            resizablePage.NavigateTo();
            resizablePage.IncreaseWidthAndHeightBy(100, 100);

            resizablePage.AssertNewSize();
        }

        [Test]
        [Property("Resizable", "1")]
        public void ResizableSecondTest()
        {
            var resizablePage = new ResizablePage(driver);

            resizablePage.NavigateTo();
            resizablePage.IncreaseWidthAndHeightBy(100, 0);

            resizablePage.AssertNewSizeWidth();
        }

        [Test]
        [Property("Resizable", "1")]
        public void ResizableThirdTest()
        {
            var resizablePage = new ResizablePage(driver);

            resizablePage.NavigateTo();
            resizablePage.IncreaseWidthAndHeightBy(0, 100);

            resizablePage.AssertNewSizeHeight();
        }

        [Test]
        [Property("Resizable", "1")]
        public void ResizableFourthTest()
        {
            var resizablePage = new ResizablePage(driver);

            resizablePage.NavigateTo();
            resizablePage.ResizeWindowWithoutDropping();

            resizablePage.AssertWindowAttribute("you can find a screenshot of the this failed test");
        }

        [Test]
        [Property("Selectable", "1")]
        public void SelectableFirstTest()
        {
            var selectablePage = new SelectablePage(driver);

            selectablePage.NavigateTo();
            selectablePage.DragAndDropOneItem();

            selectablePage.AssertSelectedItemAttribute("ui-widget-content ui-corner-left ui-selectee ui-selected");
        }

        [Test]
        [Property("Selectable", "1")]
        public void SelectableSecondTest()
        {
            var selectablePage = new SelectablePage(driver);

            selectablePage.NavigateTo();
            selectablePage.DragAndDropTwoItems();

            selectablePage.AssertSelectedItemAttribute("ui-widget-content ui-corner-left ui-selectee ui-selected");
        }

        [Test]
        [Property("Selectable", "1")]
        public void SelectableThirdTest()
        {
            var selectablePage = new SelectablePage(driver);

            selectablePage.NavigateTo();
            selectablePage.SelectItemWithoutDropping();

            selectablePage.AssertSelectedItemAttribute("ui-widget-content ui-corner-left ui-selectee ui-selecting");
        }

        [Test]
        [Property("Sortable", "1")]
        public void SortableFirstTest()
        {
            var sortablePage = new SortablePage(driver);

            sortablePage.NavigateTo();
            sortablePage.DragAndDrop();

            sortablePage.AssertTargetLocation();
        }

        [Test]
        [Property("Sortable", "1")]
        public void SortableSecondTest()
        {
            var sortablePage = new SortablePage(driver);

            sortablePage.NavigateTo();
            sortablePage.ReverseDragAndDrop();

            sortablePage.AssertTargetLocation();
        }

        [Test]
        [Property("Sortable", "1")]
        public void SortableThirdTest()
        {
            var sortablePage = new SortablePage(driver);

            sortablePage.NavigateTo();
            sortablePage.SortWithoutDropping();

            sortablePage.AssertSortingItemAttribute("ui-state-default ui-corner-left ui-sortable-handle ui-sortable-helper");
        }
    }
}