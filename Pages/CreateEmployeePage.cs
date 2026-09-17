using MyTestAutomationSeleniumCSharp.Custom;
using MyTestAutomationSeleniumCSharp.DataModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestAutomationSeleniumCSharp.Pages
{
    public class CreateEmployeePage
    {

        private IWebDriver _driver;

        public CreateEmployeePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public static readonly string _errMsgAddingNewEmpFailed = "Adding of new employee record is unsuccessful.";

        //** Elements of Create Employee Page **//
        IWebElement empNameTxt => this._driver.FindElement(By.Id("Name"));
        IWebElement ageTxt => this._driver.FindElement(By.Id("Age"));
        IWebElement durationTxt => this._driver.FindElement(By.Id("DurationWorked"));
        IWebElement salaryTxt => this._driver.FindElement(By.Id("Salary"));
        IWebElement gradeSelect => this._driver.FindElement(By.Id("Grade"));
        IWebElement emailTxt => this._driver.FindElement(By.Id("Email"));
        IWebElement submitBtn => this._driver.FindElement(By.ClassName("btn-submit"));
        IWebElement cancelBtn => this._driver.FindElement(By.ClassName("btn-cancel"));




        //** Methods for Create Employee Page **//
        public bool VerifyAddNewEmpPageIsDisplayed()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                bool elementsAreVisible = wait.Until(_driver =>
                {
                    var empName = empNameTxt;
                    var age = ageTxt;
                    var duration = durationTxt;
                    var salary = salaryTxt;
                    var grade = gradeSelect;
                    var email = emailTxt;
                    var submitBt = submitBtn;
                    var cancelBt = cancelBtn;

                    return (empName.Displayed && age.Displayed && duration.Displayed && salary.Displayed && grade.Displayed && email.Displayed && submitBt.Displayed && cancelBt.Displayed) ? true : false;
                });
               
                return elementsAreVisible;

            }
            catch(Exception e)
            {
                return false;
            }
        }



        public void AddNewEmployee(Employee employee)
        {
            Helper.EnterText(empNameTxt, employee.Name);
            Helper.EnterText(ageTxt, employee.Age.ToString());
            Helper.EnterText(durationTxt, employee.Duration.ToString());
            Helper.EnterText(salaryTxt, employee.Salary.ToString());
            Helper.EnterText(emailTxt, employee.Email);

            var gradeSelect = new SelectElement(this.gradeSelect);
            gradeSelect.SelectByValue(employee.Grade.ToString());

            ((IJavaScriptExecutor)this._driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitBtn);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            ((IJavaScriptExecutor)this._driver).ExecuteScript("arguments[0].click();", submitBtn);
        }



    }
}
