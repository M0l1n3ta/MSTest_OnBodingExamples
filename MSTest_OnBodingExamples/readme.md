using System;


## Run test categories from command line

```
dotnet test --filter "TestCategory=Calculator TestCases"

```


## Web Drivers

### Add ChromeDriver

dotnet add package Selenium.WebDriver.ChromeDriver --version 114.0.5735.9000

### Add Firefox webdriver

dotnet add package Selenium.WebDriver.GeckoDriver.Win64 --version 0.33.0


## Add edge webdriver

dotnet add package Selenium.WebDriver.MSEdgeDriver --version 110.0.1587.50


## Add Benchmarking package

dotnet add package BenchmarkDotNet

### Runnig Benchmark test

dotnet test -c Release --filter "TestCategory=BenchMark"


### PDf Funtions

```
dotnet add package System.Drawing.Common --version 7.0.0
dotnet add package PDFsharp --version 6.0.0-preview-2

```