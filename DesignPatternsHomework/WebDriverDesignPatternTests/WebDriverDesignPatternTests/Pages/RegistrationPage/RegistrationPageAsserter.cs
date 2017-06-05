using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {
        public static void AssertRegistrationPageIsOpen(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.Header.Text);
        }

        public static void AssesrtSuccessMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.SuccessMessage.Displayed);
            Assert.AreEqual(text, page.SuccessMessage.Text);
        }

        public static void AssertNamesErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForNames.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForNames.Text);
        }

        public static void AssertPhoneErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForPhone.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForPhone.Text);
        }

        public static void AssertErrorInvalidNumber(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForPhoneNumberDigits.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForPhoneNumberDigits.Text);
        }

        public static void AssertErrorMessageNoHobby(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesNoHobby.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesNoHobby.Text);
        }
        public static void AssertErrorMessagageInvalidEmailAddress(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageInvalidEmailAddress.Displayed);
            StringAssert.Contains(text, page.ErrorMessageInvalidEmailAddress.Text);
        }
        public static void AssertErrorMessagagePasswordsDoNotMatch(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageDifferentPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessageDifferentPassword.Text);
        }
        public static void AssertErrorMessageNoEmailAddress(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageNoEmailAddress.Displayed);
            StringAssert.Contains(text, page.ErrorMessageNoEmailAddress.Text);
        }
        public static void AssertErrorMessageNoUsername(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErorMessageNoUsername.Displayed);
            StringAssert.Contains(text, page.ErorMessageNoUsername.Text);
        }
        public static void AssertErrorMessageNoPassword(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageNoPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessageNoPassword.Text);
        }
        public static void AssertErrorMessageNoPasswordConfirmation(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageNoPasswordConfirmation.Displayed);
            StringAssert.Contains(text, page.ErrorMessageNoPasswordConfirmation.Text);
        }
        public static void AssertErrorMessageShortPassword(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageShortPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessageShortPassword.Text);
        }
        public static void AssertErrorMessageInvalidFile(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageInvalidFile.Displayed);
            StringAssert.Contains(text, page.ErrorMessageInvalidFile.Text);
        }
        public static void AssertErrorMessageExistingUsername(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageExistingUsername.Displayed);
            StringAssert.Contains(text, page.ErrorMessageExistingUsername.Text);
        }
    }
}

