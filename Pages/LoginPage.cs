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

        private string _url = "https://eaapp.somee.com/Account/Login";

        public LoginPage(IWebDriver driver)
        {
            this._driver = driver;
        }


        //**Page Elements for Login Page**//
        IWebElement usernameTxt => this._driver.FindElement(By.Id("UserName"));
        
        IWebElement passwordTxt => this._driver.FindElement(By.Id("Password"));
        
        IWebElement loginBtn => this._driver.FindElement(By.ClassName("btn-signin"));
        
        IWebElement forgotPassLink => this._driver.FindElement(By.LinkText("Forgot password?"));

        IWebElement rememberMeCheckbox => this._driver.FindElement(By.Id("RememberMe"));


        
        
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
