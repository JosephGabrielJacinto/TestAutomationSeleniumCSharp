using MyTestAutomationSeleniumCSharp.Custom;
using MyTestAutomationSeleniumCSharp.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestAutomationSeleniumCSharp.Tests
{
    public class EmployeeTest : UiBaseTest
    {

        [Test(Author = "Joseph Jacinto")]
        [Description("Verifies that user can access employees page")]
        public void Test_Emp_01_VerifyUserCanAccessEmployeePage()
        {
            try
            {
                LoginPage loginPage = new LoginPage(driver);
                Commons commons = new Commons(driver);
                EmployeePage empPage = new EmployeePage(driver);

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
                LoginPage loginPage = new LoginPage(driver);
                Commons commons = new Commons(driver);
                EmployeePage empPage = new EmployeePage(driver);

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


        [Test (Author = "Joseph Jacinto")]
        [Description ("Verify that user can add new employee record")]
        public void Test_Emp_03_VerifySuccessfulAdditionOfNewEmployee()
        {
            try
            {
                LoginPage loginPage = new LoginPage(driver);

                loginPage.NavigateToLoginPage();

                if (loginPage.CheckLoginPageAccessible())
                {
                    loginPage.Login(DataRead.GetUserAccount().ValidUsername, DataRead.GetUserAccount().ValidPassword);

                    if (loginPage.CheckUserIsLoggedIn())
                    {
                        Commons commons = new Commons(driver);
                        commons.ClickEmployeeLink();

                        EmployeePage empPage = new EmployeePage(driver);
                        if (empPage.CheckIfEmployeePageIsAccesible())
                        {
                            empPage.NavigateToCreateEmpPage();

                            CreateEmployeePage createEmpPage = new CreateEmployeePage(driver);

                            if (createEmpPage.VerifyAddNewEmpPageIsDisplayed())
                            {
                                createEmpPage.AddNewEmployee(DataRead.GetEmployee());
                                
                                IWebElement addedEmp = empPage.SearchEmployeeByName(DataRead.GetEmployee().Name);

                                if (addedEmp != null)
                                {
                                    empPage.DeleteEmployee(addedEmp);
                                }

                                Assert.That((addedEmp != null), CreateEmployeePage._errMsgAddingNewEmpFailed);                                
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Assert.Fail($"Test Failed - {e.Message}");
            }
        }

    }
}
