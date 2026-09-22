using MyTestAutomationSeleniumCSharp.Custom;
using MyTestAutomationSeleniumCSharp.Pages;

namespace MyTestAutomationSeleniumCSharp.Tests
{
    public class AuthenticationTest : UiBaseTest
    {

        [Test(Author = "Joseph Jacinto")]
        [Description("Verifies that a user can access the Login Page by clicking the Sign In button")]
        public void TC01_VerifyUserCanAcessLoginPageBySignInBtn()
        {
            LandingPage landingPage = new LandingPage(this.driver);
            LoginPage loginPage = new LoginPage(this.driver);

            landingPage.NavigateToLandingPage();
            landingPage.ClickSignInBtn();

            Assert.That(loginPage.CheckLoginPageAccessible(), LoginPage._errMsgPageNotAccessible);
        }


        [Test(Author = "Joseph Jacinto")]
        [Description("Verifies that a user can access the Login Page by clicking the Login from the header")]
        public void TC02_VerifyUserCanAcessLoginPageByLoginBtn()
        {
            LandingPage landingPage = new LandingPage(this.driver);
            Commons commons = new Commons(this.driver);
            LoginPage loginPage = new LoginPage(this.driver);

            landingPage.NavigateToLandingPage();
            commons.ClickLoginLink();

            Assert.That(loginPage.CheckLoginPageAccessible(), LoginPage._errMsgPageNotAccessible);
        }



        [Test(Author = "Joseph Jacinto")]
        [Description("Verifies that a user can successfully Log in using valid username and valid password")]
        public void TC03_VerifyLoginByValidUsernameAndValidPassword()
        {
            Commons commons = new Commons(this.driver);
            LandingPage landingPage = new LandingPage(this.driver);
            LoginPage loginPage = new LoginPage(this.driver);

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



        [Test(Author = "Joseph Jacinto")]
        [Description("Verifies that a user will not be able to Log in using valid username and invalid password")]
        public void TC04_VerifyLoginByValidUsernameAndInvalidPassword()
        {
            Commons commons = new Commons(this.driver);
            LoginPage loginPage = new LoginPage(this.driver);

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



        [Test(Author = "Joseph Jacinto")]
        [Description("Verifies that a user will not be able to Log in using invalid username and valid password")]
        public void TC05_VerifyLoginByInvalidUsernameAndValidPassword()
        {
            Commons commons = new Commons(this.driver);
            LoginPage loginPage = new LoginPage(this.driver);

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
        }



        [Test(Author = "Joseph Jacinto")]
        [Description("Verifies that a user will not be able to Log in using invalid username and invalid password")]
        public void TC06_VerifyLoginByInvalidUsernameAndInvalidPassword()
        {
            Commons commmonss = new Commons(this.driver);
            LoginPage loginPage = new LoginPage(this.driver);

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

    }
}
