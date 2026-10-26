using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace Automation.FRK.Reporting;

public class ReportBase
{
    public ExtentReports extent { get; set; }
    public ExtentTest test { get; set; }

    private IWebDriver driver;

    private string reportsFolder = Path.Combine(AppContext.BaseDirectory, "Reports"); 

    private int counter = 1; 
    public  ReportBase(IWebDriver driver)
    {
        this.driver = driver;
        Directory.CreateDirectory(reportsFolder);

        var reportPath = Path.Combine(
            reportsFolder,
            $"SeleniumTestReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");

        extent = new ExtentReports();
        var htmlReporter = new ExtentSparkReporter(reportPath);
        extent.AttachReporter(htmlReporter);

        htmlReporter.Config.ReportName = "Regression Testing";
        extent.AddSystemInfo("Application Under Test", "Cobas Application");
        extent.AddSystemInfo("Environment", "QA");
        extent.AddSystemInfo("Machine", Environment.MachineName);
        extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
    }

    public void CreateTest(string testName)
    {
        test = extent.CreateTest(testName);
    }
    public void SetStepStatusPass(string stepDescription,  bool takeScreenshot = false)
    {
        TraceEvent(Status.Pass, stepDescription, takeScreenshot);
    }

    public void SetStepStatusWarning(string stepDescription)
    {
        TraceEvent(Status.Warning, stepDescription);
    }
    public void SetTestStatusPass()
    {
        test.Pass("Test Executed Sucessfully!");
    }
    public void SetTestStatusFail(string message = null, bool takeScreenshot = false)
    {
        var printMessage = "<p><b>Test FAILED!</b></p>";
        if (!string.IsNullOrEmpty(message))
        {
            printMessage += $"Message: <br>{message}<br>"; 
        }
        TraceEvent(Status.Fail, printMessage, takeScreenshot);
       
    }
    
    public void AddTestFailureScreenshot(string base64ScreenCapture)
    {
        test.AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot on Error:");
    }
    public void SetTestStatusSkipped()
    {
        test.Skip("Test skipped!");
    }
    public void Close()
    {
        extent.Flush();
    }


 private void TraceEvent(Status status, string stepDescription, bool takeScreenshot = false)
    {
         if (takeScreenshot)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var fileName = Path.Combine(
            reportsFolder,$"Screenshot_{counter++}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(fileName);
            test.Log(status, stepDescription, MediaEntityBuilder.CreateScreenCaptureFromPath(fileName).Build());
        }
        else
        {
            test.Log(status, stepDescription);
        }
    }
}
