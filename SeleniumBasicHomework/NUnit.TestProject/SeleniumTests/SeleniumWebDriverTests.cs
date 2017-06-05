using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    [TestFixture]
    public class SeleniumWebDriverTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void CleanUp()
        {
            this.driver.Quit();
            
        }
        [Test]
        public void GoogleSearch()
        {
            
            driver.Url = "https://www.google.com/";

            var searchArea = driver.FindElement(By.XPath("//*[@id='lst-ib']"));
            searchArea.Clear();
            searchArea.SendKeys("Selenium");

            var searchButton = driver.FindElement(By.Name("btnG"));
            searchButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='rso']/div[1]/div/div/div/h3/a")));

            var firstLink = driver.FindElement(By.XPath("//*[@id='rso']/div[1]/div/div/div/h3/a"));
            firstLink.Click();
            Assert.AreEqual("Selenium - Web Browser Automation", driver.Title, "Title is 'Selenium - Web Browser Automation'");
        }
        [Test]
        public void QAAutomation()
        {
            driver.Url = "https://www.softuni.bg/";

            var subjects = driver.FindElement(By.XPath("//*[@id='header-nav']/div[1]/ul/li[2]/a/span"));
            subjects.Click();

            var qaCourse = driver.FindElement(By.XPath("//*[@id='header-nav']/div[1]/ul/li[2]/div/div/div/div[2]/div[2]/ul/li[4]/a"));
            qaCourse.Click();

            var tagOne = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/div/div/h1"));
            Assert.AreEqual("Курс QA Automation - март 2017", tagOne.Text);

            var tagTwo = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/article/div[1]/h2"));
            Assert.AreEqual("Курс QA Automation - март 2017", tagTwo.Text);
        }

        [Test]
        public void RegistrationPage()
        {
            driver.Url = "http://www.demoqa.com";

            var RegistrationButton = driver.FindElement(By.XPath("//*[@id='menu-item-374']/a"));
            RegistrationButton.Click();

            var CurrentUrl = driver.Url;
            Assert.AreEqual(CurrentUrl, "http://demoqa.com/registration/");
        }

        [Test]

        public void RegistrationEmptyNameField()
        {
            driver.Url = "http://demoqa.com/registration/";

            //IWebElement firstName = driver.FindElement(By.Id("name_3_firstname"));
            // Type(firstName, "Toni");
            // IWebElement lastName = driver.FindElement(By.Id("name_3_lastname"));
            // Type(lastName, "Naika");
            IWebElement maritalStatus = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            maritalStatus.Click();
            List<IWebElement> hobbys = driver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[2].Click();
            IWebElement countryDropDown = driver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = driver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = driver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = driver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = driver.FindElement(By.Id("phone_9"));
            Type(telephone, "359999999999");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Type(userName, "ToniNaika");
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Type(email, "Naika@abv.bg");
            IWebElement uploadPicButton = driver.FindElement(By.Id("profile_pic_10"));
            uploadPicButton.Click();
            driver.SwitchTo().ActiveElement().SendKeys(@"C:\Users\hrist\Desktop\Ceca.jpg");
            IWebElement description = driver.FindElement(By.Id("description"));
            Type(description, "Ceca Forever!");
            IWebElement password = driver.FindElement(By.Id("password_2"));
            Type(password, "123456789");
            IWebElement confirmPassword = driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "123456789");
            IWebElement submitButton = driver.FindElement(By.Name("pie_submit"));
            submitButton.Click();

            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id='pie_register']/li[1]/div[1]/div[2]/span"));
            Assert.AreEqual("* This field is required", errorMessage.Text);
        }

        public void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        [Test]
        public void RegistrationNotEnoughDigitsOfPhoneNumber()
        {
            driver.Url = "http://demoqa.com/registration/";

            IWebElement firstName = driver.FindElement(By.Id("name_3_firstname"));
            Type(firstName, "Toni");
            IWebElement lastName = driver.FindElement(By.Id("name_3_lastname"));
            Type(lastName, "Naika");
            IWebElement maritalStatus = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            maritalStatus.Click();
            List<IWebElement> hobbys = driver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[2].Click();
            IWebElement countryDropDown = driver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = driver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = driver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = driver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = driver.FindElement(By.Id("phone_9"));
            Type(telephone, "35999");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Type(userName, "ToniNaika");
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Type(email, "Naika@abv.bg");
            IWebElement uploadPicButton = driver.FindElement(By.Id("profile_pic_10"));
            uploadPicButton.Click();
            driver.SwitchTo().ActiveElement().SendKeys(@"C:\Users\hrist\Desktop\Ceca.jpg");
            IWebElement description = driver.FindElement(By.Id("description"));
            Type(description, "Ceca Forever!");
            IWebElement password = driver.FindElement(By.Id("password_2"));
            Type(password, "123456789");
            IWebElement confirmPassword = driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "123456789");
            IWebElement submitButton = driver.FindElement(By.Name("pie_submit"));
            submitButton.Click();

            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id='pie_register']/li[6]/div/div/span"));
            Assert.AreEqual("* Minimum 10 Digits starting with Country Code", errorMessage.Text);
        }
        [Test]

        public void RegistrationInvalidEmailAddress()
        {
            driver.Url = "http://demoqa.com/registration/";

            IWebElement firstName = driver.FindElement(By.Id("name_3_firstname"));
            Type(firstName, "Toni");
            IWebElement lastName = driver.FindElement(By.Id("name_3_lastname"));
            Type(lastName, "Naika");
            IWebElement maritalStatus = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            maritalStatus.Click();
            List<IWebElement> hobbys = driver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[2].Click();
            IWebElement countryDropDown = driver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = driver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = driver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = driver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = driver.FindElement(By.Id("phone_9"));
            Type(telephone, "359999999999");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Type(userName, "ToniNaika");
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Type(email, "Samo Levski");
            IWebElement uploadPicButton = driver.FindElement(By.Id("profile_pic_10"));
            uploadPicButton.Click();
            driver.SwitchTo().ActiveElement().SendKeys(@"C:\Users\hrist\Desktop\Ceca.jpg");
            IWebElement description = driver.FindElement(By.Id("description"));
            Type(description, "Ceca Forever!");
            IWebElement password = driver.FindElement(By.Id("password_2"));
            Type(password, "123456789");
            IWebElement confirmPassword = driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "123456789");
            IWebElement submitButton = driver.FindElement(By.Name("pie_submit"));
            submitButton.Click();

            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id='pie_register']/li[8]/div/div/span"));
            Assert.AreEqual("* Invalid email address", errorMessage.Text);

        }
        [Test]

        public void RegistrationEmptyEmailAddress()
        {
            driver.Url = "http://demoqa.com/registration/";

            IWebElement firstName = driver.FindElement(By.Id("name_3_firstname"));
            Type(firstName, "Toni");
            IWebElement lastName = driver.FindElement(By.Id("name_3_lastname"));
            Type(lastName, "Naika");
            IWebElement maritalStatus = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            maritalStatus.Click();
            List<IWebElement> hobbys = driver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[2].Click();
            IWebElement countryDropDown = driver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = driver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = driver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = driver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = driver.FindElement(By.Id("phone_9"));
            Type(telephone, "359999999999");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Type(userName, "ToniNaika");
            //IWebElement email = driver.FindElement(By.Id("email_1"));
            //Type(email, "Naika@abv.bg");
            IWebElement uploadPicButton = driver.FindElement(By.Id("profile_pic_10"));
            uploadPicButton.Click();
            driver.SwitchTo().ActiveElement().SendKeys(@"C:\Users\hrist\Desktop\Ceca.jpg");
            IWebElement description = driver.FindElement(By.Id("description"));
            Type(description, "Ceca Forever!");
            IWebElement password = driver.FindElement(By.Id("password_2"));
            Type(password, "123456789");
            IWebElement confirmPassword = driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "123456789");
            IWebElement submitButton = driver.FindElement(By.Name("pie_submit"));
            submitButton.Click();

            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id='pie_register']/li[8]/div/div/span"));
            Assert.AreEqual("* This field is required", errorMessage.Text);

        }
        [Test]

        public void RegistrationDifferentPassword()
        {
            driver.Url = "http://demoqa.com/registration/";

            IWebElement firstName = driver.FindElement(By.Id("name_3_firstname"));
            Type(firstName, "Toni");
            IWebElement lastName = driver.FindElement(By.Id("name_3_lastname"));
            Type(lastName, "Naika");
            IWebElement maritalStatus = driver.FindElement(By.XPath("//*[@id=\"pie_register\"]/li[2]/div/div/input[1]"));
            maritalStatus.Click();
            List<IWebElement> hobbys = driver.FindElements(By.Name("checkbox_5[]")).ToList();
            hobbys[0].Click();
            hobbys[2].Click();
            IWebElement countryDropDown = driver.FindElement(By.Id("dropdown_7"));
            SelectElement countryOption = new SelectElement(countryDropDown);
            countryOption.SelectByText("Bulgaria");
            IWebElement mountDropDown = driver.FindElement(By.Id("mm_date_8"));
            SelectElement mountOption = new SelectElement(mountDropDown);
            mountOption.SelectByValue("3");
            IWebElement dayDropDown = driver.FindElement(By.Id("dd_date_8"));
            SelectElement dayOption = new SelectElement(dayDropDown);
            dayOption.SelectByText("3");
            IWebElement yearDropDown = driver.FindElement(By.Id("yy_date_8"));
            SelectElement yearOption = new SelectElement(yearDropDown);
            yearOption.SelectByValue("1989");
            IWebElement telephone = driver.FindElement(By.Id("phone_9"));
            Type(telephone, "359999999999");
            IWebElement userName = driver.FindElement(By.Id("username"));
            Type(userName, "ToniNaika");
            IWebElement email = driver.FindElement(By.Id("email_1"));
            Type(email, "Naika@abv.bg");
            IWebElement uploadPicButton = driver.FindElement(By.Id("profile_pic_10"));
            uploadPicButton.Click();
            driver.SwitchTo().ActiveElement().SendKeys(@"C:\Users\hrist\Desktop\Ceca.jpg");
            IWebElement description = driver.FindElement(By.Id("description"));
            Type(description, "Ceca Forever!");
            IWebElement password = driver.FindElement(By.Id("password_2"));
           Type(password, "123456789");
            IWebElement confirmPassword = driver.FindElement(By.Id("confirm_password_password_2"));
            Type(confirmPassword, "23131232312");
            IWebElement submitButton = driver.FindElement(By.Name("pie_submit"));
            submitButton.Click();

            IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id='pie_register']/li[12]/div/div/span"));
            Assert.AreEqual("* Fields do not match", errorMessage.Text);

        }
    }
}
