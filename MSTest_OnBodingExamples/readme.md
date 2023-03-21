using System;


## Run test categories from command line

```
dotnet test --filter "TestCategory=Calculator TestCases"

```


## Web Drivers

### Add Firefox webdriver

dotnet add package Selenium.WebDriver.GeckoDriver --version 0.32.2


## Add edge webdriver

dotnet add package Selenium.WebDriver.MSEdgeDriver --version 110.0.1587.50


## Add Benchmarking package

dotnet add package BenchmarkDotNet

### Runnig Benchmark test

dotnet test -c Release --filter "TestCategory=BenchMark"