using MyTestAutomationSeleniumCSharp.Custom;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;

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
        public static readonly string _errMsgEmployeeLinkNotAccessible = "Employee Page is not accessible";
        public static readonly string _errBadgeCountTableRecordNotEqual = "Number of employees in Employee Badge is incorrect";



        //**Page Elements for Employee Page**//
        IWebElement addNewEmpBtn => this._driver.FindElement(By.LinkText("+ New Employee"));
        IWebElement empTable => this._driver.FindElement(By.CssSelector("div.employee-table-card > table"));
        IWebElement searchByNameTxt => this._driver.FindElement(By.Name("searchTerm"));
        IWebElement searchByEmailTxt => this._driver.FindElement(By.Name("emailTerm"));
        IWebElement gradeFilterSelect => this._driver.FindElement(By.Name("gradeFilter"));
        IWebElement searchBtn => this._driver.FindElement(By.ClassName("btn-search"));
        IWebElement pageNavBtn => this._driver.FindElement(By.ClassName("page-btn"));
        IWebElement empCountBadge => this._driver.FindElement(By.CssSelector("span.stat-badge"));
        IWebElement deleteBtn => this._driver.FindElement(By.CssSelector("table > tbody > tr > td > div > a.btn-del"));

        //**Methods for Emplyee Page**//
        public bool CheckIfEmployeePageIsAccesible()
        {
            try
            {
                return (addNewEmpBtn.Displayed && empTable.Displayed) ? true : false;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
        }



        public bool CheckBadgeCountByTableRecordCount()
        {
            try
            {
                int ctr = 0, tableRowsPerNav = 0;
                bool hasNext = true;
                string[] badgeCount = empCountBadge.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                do
                {
                    tableRowsPerNav = empTable.FindElement(By.TagName("tbody")).FindElements(By.TagName("tr")).Count;
                    ctr = ctr + tableRowsPerNav;

                    try
                    {
                        IWebElement nextBtn = this._driver.FindElement(By.PartialLinkText("Next"));

                        if (nextBtn.GetAttribute("class").Contains("disabled"))
                        {
                            hasNext = false;
                        }
                        else
                        {
                            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                            ((IJavaScriptExecutor)this._driver).ExecuteScript("arguments[0].scrollIntoView(true);", nextBtn);
                            ((IJavaScriptExecutor)this._driver).ExecuteScript("arguments[0].click();", nextBtn);
                        }
                    }
                    catch (NoSuchElementException e)
                    {
                        hasNext = false;
                    }
                }while (hasNext);

                return (ctr == int.Parse(badgeCount[1])) ? true : false;

            }
            catch (Exception e)
            {
                return false;
            }
        }


        public void NavigateToCreateEmpPage()
        {
            Helper.ClickElement(addNewEmpBtn);
        }


        public IWebElement SearchEmployeeByName(string empName)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                bool elementIsVisible = wait.Until(_driver =>
                {
                    var searchTxt = searchByNameTxt;
                    return searchTxt.Displayed ? true : false;
                });

                if (elementIsVisible)
                {
                    Helper.EnterText(searchByNameTxt, empName);
                    Helper.ClickElement(searchBtn);

                    IWebElement searchResult = empTable.FindElement(By.CssSelector("span.emp-name"));
                    return searchResult;
                }
                else { return null; }
            }
            catch (Exception e)
            {
                return null;
            }
            
        }


        public bool DeleteEmployee(IWebElement emp)
        {
            try
            {
                Helper.ClickElement(deleteBtn);
                DeleteEmployeePage deleteEmpPage = new DeleteEmployeePage(_driver);
                deleteEmpPage.ConfirmDeleteEmployee();

                return true;                
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
