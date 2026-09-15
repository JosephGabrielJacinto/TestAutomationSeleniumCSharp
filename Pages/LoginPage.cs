using MyTestAutomationSeleniumCSharp.Custom;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V151.Emulation;
using OpenQA.Selenium.Support.UI;
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


        //** Error Messages ** //

        public static readonly string _errMsgNotDisplayed = "Alert Error Message is not displayed.";
        public static readonly string _errMsgPageNotAccessible = "Accessing Login Page Not Successful";
        public static readonly string _errMsgLoginNotSuccesful = "User is unable to login successfully";
        public static readonly string _errMsgLoginSuccessfulInvalidUsername = "User is able to logged in using invalid username";
        public static readonly string _errMsgLoginSuccessfulInvalidPassword = "User is able to logged in using invalid password";
        public static readonly string _errMsgLoginSuccessfulInvalidCredentials = "User is able to logged in using invalid username and invalid password";


        //**Page Elements for Login Page**//
        IWebElement usernameTxt => this._driver.FindElement(By.Id("UserName"));
        
        IWebElement passwordTxt => this._driver.FindElement(By.Id("Password"));
        
        IWebElement loginBtn => this._driver.FindElement(By.ClassName("btn-signin"));
        
        IWebElement forgotPassLink => this._driver.FindElement(By.LinkText("Forgot password?"));

        IWebElement rememberMeCheckbox => this._driver.FindElement(By.Id("RememberMe"));

        IWebElement errorMsg => this._driver.FindElement(By.CssSelector(".alert-danger > ul > li"));

        IWebElement employeeDetailsLink => this._driver.FindElement(By.CssSelector("ul > li > a[href='/EmployeeDetails']"));

        IWebElement helloLink => this._driver.FindElement(By.PartialLinkText("Hello"));

        IWebElement logoutBtn => this._driver.FindElement(By.CssSelector("ul > li > form > button"));




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

        public bool CheckLoginPageAccessible()
        {
            try
            {
                if(usernameTxt.Displayed && passwordTxt.Displayed)
                    return true;

                return false;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }   
        }


        public bool CheckErrorMsgIfVisible()
        {
            try
            {
                if (errorMsg.Displayed)
                    return true;

                return false;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }




        //Method to chekc if user is logged in
        public bool CheckUserIsLoggedIn()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                bool elementIsVisible = wait.Until(_driver =>
                {
                    var empDetails = employeeDetailsLink;
                    var logout = logoutBtn;

                    return (empDetails.Displayed && logout.Displayed) ? true : false;
                });

                return elementIsVisible;

            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
