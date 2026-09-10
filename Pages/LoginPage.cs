using OpenQA.Selenium;
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
            this._driver.Navigate().GoToUrl(_url);
        }

        //Action to enter value on username text field
        public void EnterUsername(string username)
        {
            usernameTxt.Clear();
            usernameTxt.SendKeys(username);
        }

        //Action to enter value on password text field
        public void EnterPassword(string password)
        {
            passwordTxt.Clear(); 
            passwordTxt.SendKeys(password);
        }

        //Action to click login button
        public void ClickLoginBtn()
        {
            loginBtn.Click();
        }

        //Action to complete login process
        public void Login()
        {

        }

    }
}
