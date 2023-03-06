using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace RunningAdditionalCode{

    [TestClass]
    public class LifeCycle{

        

        [ClassInitialize]
        public static void LifeCycleClassInitilize(TestContext context){
            Console.WriteLine("         Class Initialize");
        }

        [TestInitialize]
        public void LifeCycleInet(){
            Console.WriteLine("         Test Initialize");
        }
        [TestMethod]
        public void TestA(){
            Console.WriteLine("         Test A starting");

        }

        [TestMethod]
        public void TestB(){
            Console.WriteLine("         Test B starting");
        }


        [TestCleanup]
        public void LifeCycleClean(){
            Console.WriteLine("         TestCleanup Lifecycle");
        }

        [ClassCleanup]
        public static void LifeCycleClassCleanup(){
            Console.WriteLine("         Class cleanup");
        }

    }

}