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
            this._driver = new ChromeDriver();    
        }


        [Test(Author = "Joseph Jacinto")]
        [Description("Verifies that a user can access the Login Page by clicking the Sign In button")]
        public void TC01_VerifyUserCanAcessLoginPageBySignInBtn()
        {
            try
            {
                LandingPage landingPage = new LandingPage(this._driver);
                LoginPage loginPage = new LoginPage(this._driver);

                landingPage.NavigateToLandingPage();
                landingPage.ClickSignInBtn();

                Assert.That(loginPage.CheckLoginPageAccessible(), LoginPage._errMsgPageNotAccessible);
            }
            catch (Exception e)
            {
                Assert.Fail($"Test Failed - {e.Message}");
            }           
        }


        [Test(Author = "Joseph Jacinto")]
        [Description("Verifies that a user can access the Login Page by clicking the Login from the header")]
        public void TC02_VerifyUserCanAcessLoginPageByLoginBtn()
        {
            try
            {
                LandingPage landingPage = new LandingPage(this._driver);
                Commons commons = new Commons(this._driver);
                LoginPage loginPage = new LoginPage(this._driver);

                landingPage.NavigateToLandingPage();
                commons.ClickLoginLink();

                Assert.That(loginPage.CheckLoginPageAccessible(), LoginPage._errMsgPageNotAccessible);
            }
            catch (Exception e)
            {
                Assert.Fail($"Test Failed - {e.Message}");
            }            
        }



        [Test(Author = "Joseph Jacinto")]
        [Description("Verifies that a user can successfully Log in using valid username and valid password")]
        public void TC03_VerifyLoginByValidUsernameAndValidPassword()
        {
            try
            {
                Commons commons = new Commons(this._driver);
                LandingPage landingPage = new LandingPage(this._driver);
                LoginPage loginPage = new LoginPage(this._driver);

                landingPage.NavigateToLandingPage();

                commons.ClickLoginLink();

                if (loginPage.CheckLoginPageAccessible())
                {
                    loginPage.Login(DataRead.GetUserAccount().ValidUsername, DataRead.GetUserAccount().ValidPassword);
                    Assert.That(loginPage.CheckUserIsLoggedIn(), LoginPage._errMsgLoginNotSuccesful);
                }
                else
                {
                    Assert.Fail(LoginPage._errMsgPageNotAccessible);
                }
            }
            catch(Exception e){
                Assert.Fail($"Test Failed - {e.Message}");
            }
        }



        [Test (Author = "Joseph Jacinto")]
        [Description("Verifies that a user will not be able to Log in using valid username and invalid password")]
        public void TC04_VerifyLoginByValidUsernameAndInvalidPassword()
        {
            try
            {
                Commons commons = new Commons(this._driver);
                LoginPage loginPage = new LoginPage(this._driver);

                loginPage.NavigateToLoginPage();

                if (loginPage.CheckLoginPageAccessible())
                {
                    loginPage.Login(DataRead.GetUserAccount().ValidUsername, DataRead.GetUserAccount().InvalidPassword);
                    Assert.That(loginPage.CheckErrorMsgIfVisible(), LoginPage._errMsgNotDisplayed);
                    Assert.That(!loginPage.CheckUserIsLoggedIn(), LoginPage._errMsgLoginSuccessfulInvalidPassword);
                }
                else
                {
                    Assert.Fail(LoginPage._errMsgPageNotAccessible);
                }

            }
            catch(Exception e)
            {
                Assert.Fail($"Test Failed - {e.Message}");
            }
        }



        [Test (Author = "Joseph Jacinto")]
        [Description("Verifies that a user will not be able to Log in using invalid username and valid password")]
        public void TC05_VerifyLoginByInvalidUsernameAndValidPassword()
        {
            try
            {
                Commons commons = new Commons(this._driver);
                LoginPage loginPage = new LoginPage(this._driver);

                loginPage.NavigateToLoginPage();

                if (loginPage.CheckLoginPageAccessible())
                {
                    loginPage.Login(DataRead.GetUserAccount().InvalidUsername, DataRead.GetUserAccount().ValidPassword);
                    Assert.That(loginPage.CheckErrorMsgIfVisible());
                    Assert.That(!loginPage.CheckUserIsLoggedIn(), LoginPage._errMsgLoginSuccessfulInvalidUsername);
                }
                else
                {
                    Assert.Fail(LoginPage._errMsgPageNotAccessible);
                }

            }catch(Exception e)
            {
                Assert.Fail($"Test Failed - {e.Message}");
            }
        }



        [Test (Author = "Joseph Jacinto")]
        [Description("Verifies that a user will not be able to Log in using invalid username and invalid password")]
        public void TC06_VerifyLoginByInvalidUsernameAndInvalidPassword()
        {
            try
            {
                Commons commmonss = new Commons(this._driver);
                LoginPage loginPage = new LoginPage(this._driver);

                loginPage.NavigateToLoginPage();

                if (loginPage.CheckLoginPageAccessible())
                {
                    loginPage.Login(DataRead.GetUserAccount().InvalidUsername, DataRead.GetUserAccount().InvalidPassword);
                    Assert.That(loginPage.CheckErrorMsgIfVisible());
                    Assert.That(!loginPage.CheckUserIsLoggedIn(), LoginPage._errMsgLoginSuccessfulInvalidCredentials);
                }
                else
                {
                    Assert.Fail(LoginPage._errMsgPageNotAccessible);
                }

            }
            catch (Exception e)
            {
                Assert.Fail($"Test Failed - {e.Message}");
            }
        }



        [TearDown]
        public void TearDown()
        {
            this._driver.Quit();
        }

    }
}
