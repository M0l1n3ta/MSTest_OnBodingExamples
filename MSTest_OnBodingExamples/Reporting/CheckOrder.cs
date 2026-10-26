using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Automation.FRK.Reporting;

[TestClass]
public class CheckOrder
{
    private ReportBase report;
    private IWebDriver driver;

    private WebDriverWait wait;

    [TestInitialize]
    public void TestInitialize()
    {
        var options = new ChromeOptions();
            
        options.AddArguments("start-maximized");
        options.AddArguments("--ignore-certificate-errors");
        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        report = new ReportBase(driver);

    }

    [TestMethod]
    public void DoLoginTest()
    { 
        report.CreateTest("Do Login");
        DoLogin();
        report.SetStepStatusPass("Step 1 - Login to Application", true);
    }

    [TestCleanup]
    public void TestCleanup()
    {
        report.extent.Flush();
        driver.Quit();
    }

    private  void DoLogin()
    {
        driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        driver.FindElement(By.CssSelector("input[type='submit']")).Click();
       
        wait.Until(d => d.FindElement(By.CssSelector("div.app_logo")).Displayed);
    }

}
