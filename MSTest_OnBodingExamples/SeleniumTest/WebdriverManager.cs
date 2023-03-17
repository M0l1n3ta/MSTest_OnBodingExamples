using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumTest;

[TestClass]
public class WebdriverManager{
    private WebDriver driver;


    [TestMethod]
    public void Setup_Firefox()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
        driver = new FirefoxDriver(); 

        driver.Navigate().GoToUrl("https://stagingfxonline.riaenvia.net/External/Login.aspx?ReturnUrl=%2f");
            
        Assert.IsTrue(driver.Title.Equals("Ria - FxOnline Login"));
    }

    [TestCleanup]
    public void Dispose(){
        if(driver != null)
            driver.Quit();
    }

}