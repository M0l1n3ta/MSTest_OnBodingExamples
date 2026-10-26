using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Automation.FRK.Reporting;

[TestClass]
public class SeleniumHtmlReportTests
{
    private static ReportBase report;
    private static IWebDriver driver;

    private static WebDriverWait wait;
    private static bool loggedIn;

    [ClassInitialize]
    public static void TestInitialize(TestContext testContext)
    {
        var options = new ChromeOptions();
            
        options.AddArguments("start-maximized");
        options.AddArguments("--ignore-certificate-errors");
        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        report = new ReportBase(driver);
        loggedIn = false;
    }

    [TestInitialize]
    public void TestInitialize()
    {
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        
    }

    [TestMethod]
    [DataRow("EMP1007")]
    public void CheckEmployeeID(string expectedEmployeeID)
    { 

        DoLogin("Check Employee ID");
        
        var menuOptions = driver.FindElements(By.CssSelector("ul.oxd-main-menu li"));
        var option = menuOptions.FirstOrDefault(m => m.Text.Equals("My Info", StringComparison.OrdinalIgnoreCase));
        option?.Click();
        waitSpinnerToDisappear();
        wait.Until(d => d.FindElement(By.CssSelector("div.orangehrm-edit-employee-content")).Displayed);
        report.SetStepStatusPass("Step 2 - Navigate to Menu", true);
        var form  =  driver.FindElement(By.XPath(("//h6[text()='Personal Details']/following-sibling::form")));
        ReadOnlyCollection<IWebElement> inputList = form.FindElements(By.TagName("input"));

        var employeeIDElement = inputList.ToArray()[3].GetAttribute("value");
        var result = employeeIDElement.Equals(expectedEmployeeID);
        if (result)
        {
            Assert.IsTrue(result, $"Employee ID is not correct. Expected: {expectedEmployeeID}, Actual: {employeeIDElement}");
            report.SetStepStatusPass("Step 3 - Check Employee ID", true);
            
        }else
        {
            report.SetTestStatusFail($"Employee ID is not correct. Expected: {expectedEmployeeID}, Actual: {employeeIDElement}", true);
            Assert.Fail($"Employee ID is not correct. Expected: {expectedEmployeeID}, Actual: {employeeIDElement}");
           
        }
        
       
    }

    [TestMethod]
    [DataRow("Hugo")]
    public void checkEmployeeName(String expectedName)
    { 
        
        DoLogin("Check Employee Name");
        
        var menuOptions = driver.FindElements(By.CssSelector("ul.oxd-main-menu li"));
        var option = menuOptions.FirstOrDefault(m => m.Text.Equals("My Info", StringComparison.OrdinalIgnoreCase));
        option?.Click();
        waitSpinnerToDisappear();

        wait.Until(d => d.FindElement(By.CssSelector("div.orangehrm-edit-employee-content")).Displayed);
        report.SetStepStatusPass("Step 2 - Navigate to Menu", true);
        waitSpinnerToDisappear();
        IWebElement form  = wait.Until(d => d.FindElement(By.XPath("//h6[text()='Personal Details']/following-sibling::form")));   
        IWebElement txtName = form.FindElement(By.Name("firstName"));
        txtName.SendKeys(Keys.Control + "a");
        txtName.SendKeys(Keys.Delete);      
        txtName.SendKeys(expectedName);
        IWebElement btnSave = form.FindElement(By.CssSelector("button[type='submit']"));
        btnSave.Click();

        waitSpinnerToDisappear();
        
        var employeeNameElement = form.FindElement(By.Name("firstName")).GetAttribute("value");
        report.SetStepStatusPass("Step 3 - Check Employee Name", true);
        Assert.IsTrue(employeeNameElement.Equals(expectedName), $"Employee Name is not correct. Expected: {expectedName}, Actual: {employeeNameElement}");
       
    }


    [ClassCleanup]
    public static void Dispose()
    {
        report.extent.Flush();
        driver.Quit();
    }

    private  void DoLogin(string testName = "Login to Application")
    {
        report.CreateTest(testName);
        if(!loggedIn)
        {
            driver.FindElement(By.Name("username")).SendKeys("Admin");
            driver.FindElement(By.Name("password")).SendKeys("admin123");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
           
            loggedIn = true;
        }
        waitSpinnerToDisappear();
        wait.Until(d => d.FindElement(By.CssSelector("img.oxd-userdropdown-img")).Displayed);

        report.SetStepStatusPass("Step 1 - Login to Application", true);
    }   

    private  void waitSpinnerToDisappear()
    {
        // Locator for the spinner element (adjust selector to match your page)
        var spinner_locator = By.CssSelector("oxd-form-loader");
        wait.Until(d => 
        {
            try
            {
                var spinner = d.FindElement(spinner_locator);
                return !spinner.Displayed; // Wait until spinner is not displayed
            }
            catch (NoSuchElementException)
            {
                return true; // If spinner is not found, consider it disappeared
            }
        });
    }

}
