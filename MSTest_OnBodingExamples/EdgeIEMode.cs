using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace MSTest_OnBodingExamples
{
    [TestClass]
    public class EdgeIEMode
    {
        [TestMethod]
        public void TestMethod1()
        {

            var ieOptions = new InternetExplorerOptions();
            ieOptions.AttachToEdgeChrome = true;
            //change the path accordingly
            ieOptions.EdgeExecutablePath = "C:/Program Files (x86)/Microsoft/Edge/Application/msedge.exe";
            ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

            var driver = new InternetExplorerDriver(ieOptions);
            driver.Navigate().GoToUrl("https://stagingfxonline.riaenvia.net/External/Login.aspx?ReturnUrl=%2f");
            

            driver.Quit();
        }
    }
}
