using MyTestAutomationSeleniumCSharp.Custom;
using MyTestAutomationSeleniumCSharp.Pages;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestAutomationSeleniumCSharp.Tests
{
    public class AuthenticationTest
    {

        #pragma warning disable CA1859
        #pragma warning disable NUnit1032
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();    
        }

        [Test]
        public void TC01_VerifyUserCanAcessLoginPage()
        {
            LandingPage landingPage = new LandingPage(_driver);
            LoginPage loginPage = new LoginPage(_driver);

            landingPage.NavigateToLandingPage();
            landingPage.ClickSignInBtn();

            Assert.That(loginPage.CheckLoginPageAccessible(), "Test Failed - Accessing Login Page Not Successful");
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

    }
}
