using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using SeleniumDesignPatternsDemo.Models;
using SeleniumDesignPatternsDemo.Pages.HomePage;
using SeleniumDesignPatternsDemo.Pages.RegistrationPage;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System;
using OpenQA.Selenium.Interactions;

namespace SeleniumTests
{
    [TestFixture]
    public class SeleniumWebDriverTests
    {
        public IWebDriver driver;

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
        public void NavigateToHomePage()
        {
            var homePage = new HomePage(driver);
            PageFactory.InitElements(this.driver, homePage);

            homePage.NavigateTo();

            homePage.AssertHomePageIsOpen("Home");
        }

        [Test]
        public void NavigateToRegistrationPage()
        {
            var homePage = new HomePage(driver);
            var registrationPage = new RegistrationPage(driver);
            PageFactory.InitElements(this.driver, homePage);

            homePage.NavigateTo();
            homePage.RegirstratonButton.Click();

            registrationPage.AssertRegistrationPageIsOpen("Registration");
        }

        [Test]
        public void RegistraionWithoutLastName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, false, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "359883457633",
                                                         "Toni",
                                                         "naika@abv.bg",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNamesErrorMessage("This field is required");
        }

        [Test]
        public void RegistrationWithoutHobby()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] {false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "359883457633",
                                                         "username",
                                                         "naika@abv.bg",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoHobby("* This field is required");
        }

        [Test]
        public void RegistrationWithoutPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "",
                                                         "User",
                                                         "naika@abv.bg",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("This field is required");
        }

        [Test]
        public void RegistrationWithoutUsername()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "359883457633",
                                                         "",
                                                         "asdasd@asdasd.asdasd",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoUsername("* This field is required");
        }

        [Test]
        public void RegistrationWithNotEnoughDigitsOfPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "123",
                                                         "User",
                                                         "naika@abv.bg",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorInvalidNumber("* Minimum 10 Digits starting with Country Code");
        }

        [Test]
        public void RegistrationEmailAddressOnlyLetters()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "359883457633",
                                                         "User",
                                                         "samolevski",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessagageInvalidEmailAddress("* Invalid email address");
        }

        [Test]
        public void RegistrationEmailAddressOnlyDigits()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "359883457633",
                                                         "User",
                                                         "11111111111",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessagageInvalidEmailAddress("* Invalid email address");
        }

        [Test]
        public void RegistrationWithoutEmailAddress()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "359883457633",
                                                         "User",
                                                         "",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoEmailAddress("* This field is required");
        }

        [Test]
        public void RegistrationInvalidFileExtension()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "359883457633",
                                                         "User",
                                                         "toni_naika@abv.bg",
                                                         @"C:\Users\hrist\Desktop\Ceca.rar",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageInvalidFile("* Invalid File");
        }

        [Test]
        public void RegistrationWithoutPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "359883457633",
                                                         "User",
                                                         "toni_naika@abv.bg",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoPassword("* This field is required");
        }

        [Test]
        public void RegistrationShortPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "359883457633",
                                                         "User",
                                                         "toni_naika@abv.bg",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345",
                                                         "12345");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageShortPassword("* Minimum 8 characters required");
        }

        [Test]
        public void RegistrationWithoutPasswordConfirmation()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "1234567890",
                                                         "User",
                                                         "toni_naika@abv.bg",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "asdasdasd",
                                                         "");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoPasswordConfirmation("* This field is required");
        }

        [Test]
        public void RegistrationDifferentPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "8888888888",
                                                         "Buro",
                                                         "naika@abv.bg",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "11111111",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessagagePasswordsDoNotMatch("* Fields do not match");
        }

        [Test]
        public void RegistraionWithSameUsername()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, false, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "359883457633",
                                                         "toninaika",
                                                         "toninaika@abv.bg",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageExistingUsername("Error: Username already exists");
        }

        [Test]
        public void RegistraionWithSameEmailAddress()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, false, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "359883457633",
                                                         "toninaika123",
                                                         "toninaika@abv.bg",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageExistingUsername("Error: E-mail address already exists");
        }

        [Test]
        public void RegistrationWithoutUsernameAndPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "",
                                                         "",
                                                         "asdasd@asdasd.asdasd",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoUsername("* This field is required");
            regPage.AssertPhoneErrorMessage("This field is required");
        }

        [Test]
        public void RegistrationWithoutUsernameAndEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "359885656667",
                                                         "",
                                                         "",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoUsername("* This field is required");
            regPage.AssertErrorMessageNoEmailAddress("* This field is required");
        }

        [Test]
        public void RegistrationWithoutPhoneNumberandInvalidEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "",
                                                         "User",
                                                         "123sad23ds",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessagageInvalidEmailAddress("* Invalid email address");
            regPage.AssertPhoneErrorMessage("* This field is required");
        }

        [Test]
        public void RegistrationWithShortPasswordAndInvalidPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "Naika",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { true, true, true }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "231sda",
                                                         "User",
                                                         "toni_naika@abv.bg",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "123",
                                                         "123");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageShortPassword("* Minimum 8 characters required");
            regPage.AssertErrorInvalidNumber("* Minimum 10 Digits starting with Country Code");
        }

        [Test]
        public void RegistrationWithoutHobbyAndLastName()
        {
            var regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Toni",
                                                         "",
                                                         new List<bool>(new bool[] { true, false, false }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "3",
                                                         "1",
                                                         "1989",
                                                         "359883457633",
                                                         "username",
                                                         "naika@abv.bg",
                                                         @"C:\Users\hrist\Desktop\Ceca.jpg",
                                                         "OPSA",
                                                         "12345678",
                                                         "12345678");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoHobby("* This field is required");
            regPage.AssertNamesErrorMessage("* This field is required");
        }

        public void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
