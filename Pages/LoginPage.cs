using MyTestAutomationSeleniumCSharp.Custom;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V151.Emulation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestAutomationSeleniumCSharp.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

        private string _url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
        }


        //**Page Elements for Login Page**//
        IWebElement usernameTxt => this._driver.FindElement(By.Name("username"));
        IWebElement passwordTxt => this._driver.FindElement(By.Name("password"));
        IWebElement loginBtn => this._driver.FindElement(By.ClassName("orangehrm-login-button"));
        IWebElement forgotPassLink => this._driver.FindElement(By.ClassName("orangehrm-login-forgot-header"));


        //**Page Actions / Methods for Login Page**//
        
        //Method to navigate to login page
        public void NavigateToLoginPage()
        {
            Helper.GoTo(this._driver, _url);
        }


        //Action to enter value on username text field
        public void EnterUsername(string username)
        {
            Helper.EnterText(usernameTxt,username);
        }


        //Action to enter value on password text field
        public void EnterPassword(string password)
        {
            Helper.EnterText(passwordTxt, password);
        }


        //Action to click login button
        public void ClickLoginBtn()
        {
            loginBtn.Click();
        }


        //Action to a complete login process
        public void Login(string username, string password)
        {
            Helper.EnterText(usernameTxt, username);
            Helper.EnterText(passwordTxt, password);
            Helper.ClickElement(loginBtn);
        }

    }
}
