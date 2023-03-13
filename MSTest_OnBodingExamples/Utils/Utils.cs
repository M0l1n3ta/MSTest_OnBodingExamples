using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace Utils;

public class ScreenShot{
    

   
    public void TakeScrennShot(WebDriver driver,string filePath){
        driver.GetScreenshot().SaveAsFile(filePath,ScreenshotImageFormat.Png);
        
    }
    //combine two pictures
    public static Bitmap combineImages(Image image1, Image image2)
    {
        Bitmap bitmap = new Bitmap(image1.Width, image1.Height + image2.Height);
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            g.DrawImage(image1, 0, 0);
            g.DrawImage(image2, 0, image1.Height);
        }

        return bitmap;
    }


   /**
   Dosn't work for dotnet 5> and Selenium 4
   **/
   public void TakeFullWebpageScreenShot(WebDriver driver, string filePath ){
        // Use the VerticalCombineDecorator to capture entire page:
        var vcs = new VerticalCombineDecorator(new ScreenshotMaker());
        var screen = driver.TakeScreenshot(vcs);

        //Coverting a byte array to an image:
        using (Image image = Image.FromStream(new MemoryStream(screen)))
        {
            var a = image.Size;
            image.Save(filePath, ImageFormat.Png);  
        }
   }

    
}