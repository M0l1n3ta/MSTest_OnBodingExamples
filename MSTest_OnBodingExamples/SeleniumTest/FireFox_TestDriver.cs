using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.IO;

namespace SeleniumTest
{
    [TestClass]
    public class FireFox_TestDriver
    {

        private WebDriver driver;

        [TestMethod]
        public void FireFoxDriverWithoutArguments_Test()
        {
            FirefoxProfile profile = new FirefoxProfile();
            

            var options = new FirefoxOptions(){
                AcceptInsecureCertificates = true,
                Profile = profile
            };
            
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            driver = new FirefoxDriver(service,options);
            driver.Navigate().GoToUrl("https://stagingfxonline.riaenvia.net/External/Login.aspx?ReturnUrl=%2f");
            

            Assert.IsTrue(driver.Title.Equals("Ria - FxOnline Login"));
        }


        [TestMethod]
        public void FireFoxDriver_Test()
        {
            
            FirefoxProfile firefoxProfile = new FirefoxProfile(@"D:\Datos\FirefoxProfile\u57pdt3h.selenium");
            firefoxProfile.DeleteAfterUse = false;
            firefoxProfile.WriteToDisk();
            
            FirefoxProfile profile = new FirefoxProfile();
            string pathToCurrentUserProfiles = @"D:\Datos\FirefoxProfile\"; // Path to profile
            string[] pathsToProfiles = Directory.GetDirectories(pathToCurrentUserProfiles, "*.selenium", SearchOption.TopDirectoryOnly);
            if (pathsToProfiles.Length != 0)
                 profile = new FirefoxProfile(pathsToProfiles[0]);
        
            var options = new FirefoxOptions(){
                Profile = profile
            };
            
            options.AddArguments("start-maximized");
            //options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--disable-popup-blocking");
            //options.AddArgument("--no-default-browser-check");
            options.AddArgument("--allow-no-sandbox-job");
        
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            driver = new FirefoxDriver(service,options);
            driver.Navigate().GoToUrl("https://stagingfxonline.riaenvia.net/External/Login.aspx?ReturnUrl=%2f");
            

            Assert.IsTrue(driver.Title.Equals("Ria - FxOnline Login"));
        }


        [TestMethod]
        public void FireFoxDriverUsingProfile_Test()
        {
           
            var options = new FirefoxOptions();
            

            options.AddArguments("start-maximized");
            //options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-popup-blocking");
            //options.AddArgument("--no-default-browser-check");
            options.AddArgument("--allow-no-sandbox-job");
            options.AddAdditionalOption("-profile",@"D:\Datos\FirefoxProfile\u57pdt3h.selenium");
            
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            driver = new FirefoxDriver(service,options);
            driver.Navigate().GoToUrl("https://stagingfxonline.riaenvia.net/External/Login.aspx?ReturnUrl=%2f");
            

            Assert.IsTrue(driver.Title.Equals("Ria - FxOnline Login"));
        }

        [TestMethod]
        public void FireFoxDriverUsingProfileManager_Test()
        {
           
            var profileManager = new FirefoxProfileManager();
            var profile = profileManager.GetProfile("selenium");
            profile.SetPreference("webdriver.firefox.profile", "selenium");
            profile.WriteToDisk();

            var options = new FirefoxOptions();
            
            
            options.AddArguments("start-maximized");
            //options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--disable-popup-blocking");
            //options.AddArgument("--no-default-browser-check");
            options.AddArgument("--allow-no-sandbox-job");
            
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            driver = new FirefoxDriver(service,options);
            driver.Navigate().GoToUrl("https://stagingfxonline.riaenvia.net/External/Login.aspx?ReturnUrl=%2f");
            

            Assert.IsTrue(driver.Title.Equals("Ria - FxOnline Login"));
        }


        [TestMethod]
        public void TestInitProfile()
        {
            var options = new FirefoxOptions();
            options.SetPreference("webdriver.firefox.profile", "selenium");

            options.AddArguments("start-maximized");
            //options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--disable-popup-blocking");
            //options.AddArgument("--no-default-browser-check");
            //options.AddArgument("--allow-no-sandbox-job");
            
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            driver = new FirefoxDriver(service,options);
            driver.Navigate().GoToUrl("https://stagingfxonline.riaenvia.net/External/Login.aspx?ReturnUrl=%2f");
            

            Assert.IsTrue(driver.Title.Equals("Ria - FxOnline Login"));
        }



        [TestCleanup]
        public void Dispose(){
            if(driver != null)
                driver.Quit();
        }
    }
}