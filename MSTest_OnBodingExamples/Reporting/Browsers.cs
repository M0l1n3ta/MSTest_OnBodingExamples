using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Automation.FRK.Reporting;

public class Browsers
{
    private IWebDriver webDriver;
    private string baseURL;
    private string browser;
    
    public Browsers(IConfiguration configuration)
    {
        baseURL = configuration["url"];
        browser = configuration["browser"];
    }

}
