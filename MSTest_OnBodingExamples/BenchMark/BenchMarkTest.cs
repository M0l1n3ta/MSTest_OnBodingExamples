
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BenchmarkDotNet.Running;

namespace  BenchMark{

    [TestClass]
    public class BenchMarkTest{

        [TestMethod]
        public void TestHashesRTate(){
            var summary = BenchmarkRunner.Run<Md5VsSha256>();
            Assert.IsTrue(summary.Reports.Length > 0);
        }
    }
}

