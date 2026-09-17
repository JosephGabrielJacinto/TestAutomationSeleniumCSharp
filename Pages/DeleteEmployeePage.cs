using MyTestAutomationSeleniumCSharp.Custom;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestAutomationSeleniumCSharp.Pages
{
    public class DeleteEmployeePage
    {

        private IWebDriver _driver;

        public DeleteEmployeePage(IWebDriver driver)
        {
            this._driver = driver;
        }


        IWebElement deleteBtn => this._driver.FindElement(By.ClassName("btn-danger"));

        IWebElement cancelBtn => this._driver.FindElement(By.LinkText("Cancel"));


        public void ConfirmDeleteEmployee()
        {
            Helper.ClickElement(deleteBtn);
        }


    }
}
