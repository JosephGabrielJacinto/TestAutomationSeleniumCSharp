using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestAutomationSeleniumCSharp.Tests
{
    public class UiBaseTest
    {

        #pragma warning disable CA1859
        #pragma warning disable NUnit1032
        protected IWebDriver driver;
        protected TestContext textContext;


        [SetUp]
        protected void Setup()
        {
            this.driver = new ChromeDriver();
            this.textContext = TestContext.CurrentContext;
        }

        
        [TearDown]
        protected void TearDown()
        {
            //Takes Screeenshot of Test that failed its assertion
            if (textContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                try {

                    string ssDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
                    Directory.CreateDirectory(ssDir);

                    string fileName = $"{textContext.Test.Name}.png";
                    string filePath = Path.Combine(ssDir, fileName);

                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    screenshot.SaveAsFile(filePath);

                }catch(Exception ex)
                {
                    TestContext.WriteLine($"[Screenshot Error] {ex.Message}");
                }
            }
            this.driver.Quit();
        }

    }
}
