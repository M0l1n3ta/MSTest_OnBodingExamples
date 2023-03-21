
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;

namespace  BenchMark{

    [TestClass]
  
    public class BenchMarkTest{

        [TestMethod]
        [TestCategory("BenchMark")]
        public void TestHashesRate(){
            var summary = BenchmarkRunner.Run<Md5VsSha256>(
                ManualConfig.Create(DefaultConfig.Instance)
                .WithOptions(ConfigOptions.DisableOptimizationsValidator)
            );
            Assert.IsTrue(summary.Reports.Length > 0);
        }
    }
}

