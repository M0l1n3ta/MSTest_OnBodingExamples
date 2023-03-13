using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System.Threading;
using Utils;
using System.IO;

namespace SeleniumTest;

[TestClass]
public class GetScreeShot{
    private WebDriver driver;


    [TestMethod]
    public void GetScreenShot_Edge(){

        driver   = new EdgeDriver();
        driver.Url = "https://bing.com";

        var element = driver.FindElement(By.Id("sb_form_q"));
        element.SendKeys("WebDriver");
        element.Submit();

        Thread.Sleep(1000);
        string filePath = @"D:\Logs\Imagen1.png";
        try{
            new ScreenShot().TakeScrennShot(driver,filePath);
        }catch(Exception e){
            Console.WriteLine(e.InnerException);
        }

        Assert.IsTrue(File.Exists(filePath));
    }

    [TestMethod]
    public void GetFullWebpageScreenShot_Edge(){

        driver   = new EdgeDriver();
        driver.Url = "https://stagingfxonline.riaenvia.net/External";


        Thread.Sleep(1000);
        string filePath = @"D:\Logs\Imagen3.png";
        try{
            new ScreenShot().TakeScrennShot(driver,filePath);
        }catch(Exception e){
            Console.WriteLine(e.InnerException);
        }

        Assert.IsTrue(File.Exists(filePath));
    }

    [TestCleanup]
    public void Dispose(){
        if(driver !=null)
            driver.Quit();
    }



}