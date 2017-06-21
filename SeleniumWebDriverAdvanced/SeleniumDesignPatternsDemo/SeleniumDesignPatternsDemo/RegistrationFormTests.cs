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
using DesignPattern.Models;

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
        [Property("Negative tests for Registration page",1)]
        public void NavigateToHomePage()
        {
            var homePage = new HomePage(driver);
            PageFactory.InitElements(this.driver, homePage);

            homePage.NavigateTo();

            homePage.AssertHomePageIsOpen("Home");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
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
        [Property("Negative tests for Registration page", 1)]
        public void RegistraionWithoutLastName()
        {
            var registrationPage = new RegistrationPage(driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutLastName");

            registrationPage.NavigateTo();
            registrationPage.FillRegistrationForm(user);

            registrationPage.AssertNamesErrorMessage("This field is required");

        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationWithoutHobby()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationWithoutHobby");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoHobby("* This field is required");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationWithoutPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationWithoutPhoneNumber");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPhoneErrorMessage("This field is required");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationWithoutUsername()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationWithoutUsername");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoUsername("* This field is required");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationWithNotEnoughDigitsOfPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationWithNotEnoughDigitsOfPhoneNumber");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorInvalidNumber("* Minimum 10 Digits starting with Country Code");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationEmailAddressOnlyLetters()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationEmailAddressOnlyLetters");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessagageInvalidEmailAddress("* Invalid email address");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationEmailAddressOnlyDigits()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationEmailAddressOnlyDigits");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessagageInvalidEmailAddress("* Invalid email address");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationWithoutEmailAddress()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationWithoutEmailAddress");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoEmailAddress("* This field is required");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationInvalidFileExtension()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationInvalidFileExtension");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageInvalidFile("* Invalid File");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationWithoutPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationWithoutPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoPassword("* This field is required");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationShortPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationShortPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageShortPassword("* Minimum 8 characters required");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationWithoutPasswordConfirmation()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationWithoutPasswordConfirmation");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoPasswordConfirmation("* This field is required");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationDifferentPassword()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationDifferentPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessagagePasswordsDoNotMatch("* Fields do not match");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistraionWithSameUsername()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistraionWithSameUsername");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageExistingUsername("Error: Username already exists");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistraionWithSameEmailAddress()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistraionWithSameEmailAddress");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageExistingUsername("Error: E-mail address already exists");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationWithoutUsernameAndPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationWithoutUsernameAndPhoneNumber");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoUsername("* This field is required");
            regPage.AssertPhoneErrorMessage("This field is required");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationWithoutUsernameAndEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationWithoutUsernameAndEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoUsername("* This field is required");
            regPage.AssertErrorMessageNoEmailAddress("* This field is required");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationWithoutPhoneNumberandInvalidEmail()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationWithoutPhoneNumberandInvalidEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessagageInvalidEmailAddress("* Invalid email address");
            regPage.AssertPhoneErrorMessage("* This field is required");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationWithShortPasswordAndInvalidPhoneNumber()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationWithShortPasswordAndInvalidPhoneNumber");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageShortPassword("* Minimum 8 characters required");
            regPage.AssertErrorInvalidNumber("* Minimum 10 Digits starting with Country Code");
        }

        [Test]
        [Property("Negative tests for Registration page", 1)]
        public void RegistrationWithoutHobbyAndLastName()
        {
            var regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegistrationWithoutHobbyAndLastName");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertErrorMessageNoHobby("* This field is required");
            regPage.AssertNamesErrorMessage("* This field is required");
        }

       
    }
}
