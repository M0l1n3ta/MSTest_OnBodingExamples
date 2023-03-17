using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace SeleniumTest
{
    [TestClass]
    public class EdgeIEMode
    {
        private WebDriver driver;
        [TestMethod]
        public void TestMethod1()
        {

            var ieOptions = new InternetExplorerOptions();
            ieOptions.AttachToEdgeChrome = true;
            //change the path accordingly
            ieOptions.EdgeExecutablePath = "C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe";
            ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

            driver = new InternetExplorerDriver(ieOptions);
            driver.Navigate().GoToUrl("https://stagingfxonline.riaenvia.net/External/Login.aspx?ReturnUrl=%2f");
        
        }


        [TestCleanup]
        public void Dispose(){
            if(driver != null)  
                driver.Quit();
        } 
    }
}
