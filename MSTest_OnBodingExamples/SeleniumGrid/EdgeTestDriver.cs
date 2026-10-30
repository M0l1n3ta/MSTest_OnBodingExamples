using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;

namespace SeleniumGrid;

[TestClass]
public class Edge_TestDriver
{

    private IWebDriver driver;
    [TestInitialize]
    public void Setup()
    {
        var options = new EdgeOptions();
        
        options.AddArguments("start-maximized");
        options.AddArguments("--ignore-certificate-errors");
        driver = new RemoteWebDriver(new Uri("http://localhost:4444/"), options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        

        Assert.IsTrue(driver.Title.Equals("OrangeHRM"));
    }

    [TestMethod]
    public void DoLogin()
    {

        driver.FindElement(By.Name("username")).SendKeys("Admin");
        driver.FindElement(By.Name("password")).SendKeys("admin123");
        driver.FindElement(By.CssSelector("button[type='submit']")).Click();
        var dashBoardElement = driver.FindElement(By.CssSelector("img.oxd-userdropdown-img"));
        Assert.IsTrue(dashBoardElement.Displayed);
    }

    [TestCleanup]
    public void Dispose(){
        if(driver != null){
            driver.Quit();
        }
    }
}
