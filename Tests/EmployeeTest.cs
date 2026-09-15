using MyTestAutomationSeleniumCSharp.Custom;
using MyTestAutomationSeleniumCSharp.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestAutomationSeleniumCSharp.Tests
{
    public class EmployeeTest
    {

        #pragma warning disable CA1859
        #pragma warning disable NUnit1032
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            this._driver = new ChromeDriver();
        }



        [Test(Author = "Joseph Jacinto")]
        [Description("Verifies that user can access employees page")]
        public void Test_Emp_01_VerifyUserCanAccessEmployeePage()
        {
            try
            {
                LoginPage loginPage = new LoginPage(_driver);
                Commons commons = new Commons(_driver);
                EmployeePage empPage = new EmployeePage(_driver);

                loginPage.NavigateToLoginPage();

                if (loginPage.CheckLoginPageAccessible())
                {
                    loginPage.Login(DataRead.GetUserAccount().ValidUsername, DataRead.GetUserAccount().ValidPassword);

                    if (loginPage.CheckUserIsLoggedIn())
                    {
                        commons.ClickEmployeeLink();

                        Assert.That(empPage.CheckIfEmployeePageIsAccesible(), EmployeePage._errMsgEmployeeLinkNotAccessible);
                    }
                    else
                    {
                        Assert.Fail(LoginPage._errMsgLoginNotSuccesful);
                    }
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


        [Test (Author = "Joseph Jacinto")]
        [Description("Verifies that the Count displayed on the badge is correct based on the total record count on the employee table")]
        public void Test_Emp_02_VerifyEmployeeCountOnBadge()
        {
            try
            {
                LoginPage loginPage = new LoginPage(_driver);
                Commons commons = new Commons(_driver);
                EmployeePage empPage = new EmployeePage(_driver);

                loginPage.NavigateToLoginPage();

                if (loginPage.CheckLoginPageAccessible())
                {
                    loginPage.Login(DataRead.GetUserAccount().ValidUsername, DataRead.GetUserAccount().ValidPassword);

                    if (loginPage.CheckUserIsLoggedIn())
                    {
                        commons.ClickEmployeeLink();

                        Assert.That(empPage.CheckBadgeCountByTableRecordCount, EmployeePage._errBadgeCountTableRecordNotEqual);
                    }
                    else
                    {
                        Assert.Fail(LoginPage._errMsgLoginNotSuccesful);
                    }
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
        public void Teardown()
        {
            this._driver.Quit();
        }


    }
}
