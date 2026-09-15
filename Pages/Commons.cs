using MyTestAutomationSeleniumCSharp.Custom;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestAutomationSeleniumCSharp.Pages
{
    public class Commons
    {
        private IWebDriver _driver;


        public Commons(IWebDriver driver)
        {
            this._driver = driver;
        }


        //**Page Elements for Common**//
        IWebElement homeLink => this._driver.FindElement(By.PartialLinkText("Home"));
        
        IWebElement employeesLink => this._driver.FindElement(By.PartialLinkText("Employees"));

        IWebElement dashboardLink => this._driver.FindElement(By.PartialLinkText("Dashboard"));
        
        IWebElement aboutLink => this._driver.FindElement(By.PartialLinkText("About"));
        
        IWebElement registerLink => this._driver.FindElement(By.LinkText("Register"));
        
        IWebElement loginLink => this._driver.FindElement(By.CssSelector("ul > li > a[href='/Account/Login']"));



        //**Page Actions / Methods for Common Page**//

        //Method to click Home Link
        public void ClickHomeLink()
        {
            Helper.ClickElement(homeLink);
        }


        //Method to click Employee Link
        public void ClickEmployeeLink()
        {
            Helper.ClickElement(employeesLink);
        }


        //Method to click Dashboard Link
        public void ClickDashboardLink()
        {
            Helper.ClickElement(dashboardLink);
        }


        //Method to click About Link
        public void ClickAboutLink()
        {
            Helper.ClickElement(aboutLink);
        }


        //Method to click Register Link
        public void ClickRegisterLink()
        {
            Helper.ClickElement(registerLink);
        }


        //Method to click Login link
        public void ClickLoginLink()
        {
            Helper.ClickElement(loginLink);
        }

    }
}
