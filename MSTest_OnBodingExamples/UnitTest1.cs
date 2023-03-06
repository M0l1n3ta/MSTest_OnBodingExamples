using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Prueba_1.Models;


namespace Prueba_1
{
    [TestClass]
    public class UnitTest1
    {

        private IWebDriver driver;
        private WebDriverWait wait;

        [TestInitialize]
        public void SetUp()
        {
            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
        }


        [TestCleanup]
        public void Dispose()
        {
            driver.Quit();
        }



        [TestMethod]
        public void TestMethod1()
        {

            string url = "https://lambdatest.github.io/sample-todo-app/";
            driver.Navigate().GoToUrl(url);

            // Click on First Check box
            IWebElement firstCheckBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("li1")));
            firstCheckBox.Click();


            // Click on Second Check box
            IWebElement secondCheckBox = driver.FindElement(By.Name("li2"));
            secondCheckBox.Click();


            Assert.IsTrue(true);
        }


        [TestMethod]
        public void checkList()
        {

            List<String> lista = new List<string>() {
            "Long Bow",
            "Short Bow",
            "short sword"};

            CollectionAssert.Contains(lista, "Long Bow");
        }

        

        
    }
}
