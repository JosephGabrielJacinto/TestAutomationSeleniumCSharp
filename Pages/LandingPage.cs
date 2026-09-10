using MyTestAutomationSeleniumCSharp.Custom;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestAutomationSeleniumCSharp.Pages
{
    public class LandingPage
    {
        private IWebDriver _driver;
        private string _url = "https://eaapp.somee.com/";

        public LandingPage(IWebDriver driver)
        {
            this._driver = driver;
        }


        //**Page Elements for Landing Page**//
        IWebElement viewEmployeesBtn => _driver.FindElement(By.PartialLinkText("View Employees"));

        IWebElement signInBtn => _driver.FindElement(By.LinkText(" Sign In "));



        //**Page Actions / Methods for Landing Page**//

        //Method to navigate to landing page
        public void NavigateToLandingPage()
        {
            Helper.GoTo(this._driver, _url);
        }


        //Method to click View Employee button
        public void ClickViewEmployeesBtn()
        {
            Helper.ClickElement(viewEmployeesBtn);
        }


        //Method to click Sign In button
        public void ClickSignInBtn()
        {
            Helper.ClickElement(signInBtn);
        }


    }
}
