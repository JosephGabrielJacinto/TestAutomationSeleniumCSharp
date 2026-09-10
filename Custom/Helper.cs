using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestAutomationSeleniumCSharp.Custom
{
    public class Helper
    {
        //** Helper methods that can be use by page object classes **//

        //Method for navigating to specified url
        public static void GoTo(IWebDriver driver, string url) {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        //Method for entering text to a field (clearing first before entering text)
        public static void EnterText(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        //Method for clicking an element (buttons, links)
        public static void ClickElement(IWebElement element)
        {
            element.Click();
        }


    }
}
