using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestAutomationSeleniumCSharp.Pages
{
    public class EmployeePage
    {
        private IWebDriver _driver;


        public EmployeePage(IWebDriver driver)
        {
            this._driver = driver;
        }


        //**Error Messages for Employee Page**//


        //**Page Elements for Employee Page**//
        IWebElement addNewEmpBtn => this._driver.FindElement(By.LinkText("+ New Employee"));
        IWebElement empTable => this._driver.FindElement(By.CssSelector("div.employee-table-card > table"));



        //**Methods for Emplyee Page**//
        public bool CheckIfEmployeePageIsAccesible()
        {
            try
            {
                return (addNewEmpBtn.Displayed && empTable.Displayed) ? true : false;
            }
            catch(NoSuchElementException e)
            {
                return false;
            }
        }



    }
}
