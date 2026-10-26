using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    [TestClass]
    public class Chrome_TestDriver
    {
        private IWebDriver driver;
        [TestInitialize]
        public void Setup()
        {
            var options = new ChromeOptions();
            
            options.AddArguments("start-maximized");
            options.AddArguments("--ignore-certificate-errors");
            driver = new ChromeDriver(options);
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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(d => d.FindElement(By.CssSelector("img.oxd-userdropdown-img")).Displayed);
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
}