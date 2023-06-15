using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest
{
    [TestClass]
    public class Chrome_TestDriver
    {

        private IWebDriver driver;
        [TestMethod]
        public void ChromeDriver_Test()
        {

            var options = new ChromeOptions();
            
            options.AddArguments("start-maximized");
            options.AddArguments("--ignore-certificate-errors");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("https://stagingfxonline.riaenvia.net/External/Login.aspx?ReturnUrl=%2f");
            

            Assert.IsTrue(driver.Title.Equals("Ria - FxOnline Login"));
        }

        [TestCleanup]
        public void Dispose(){
            if(driver != null){
                driver.Quit();
            }
        }
    }
}