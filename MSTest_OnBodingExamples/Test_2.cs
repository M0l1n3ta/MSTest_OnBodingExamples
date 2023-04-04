using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MSTest_OnBodingExamples.Models;

namespace MSTest_OnBodingExamples
{
    [TestClass]
    [TestCategory("Calculator TestCases")]
    public class TestSumClass
    {

        [TestMethod]
        [TestCategory("Sum")]
        public void checkSum()
        {

            Calc calculator = new Calc();
            string resultado = calculator.Sum(10.2,10.4);
            Assert.AreEqual("20.6", resultado);

        }

        [TestMethod]
        [TestCategory("Rest")]
        public void checkRest()
        {

            Calc calculator = new Calc();
            string resultado = calculator.rest(20.6, 10.4);
            Assert.AreEqual("10.2", resultado);

        }

        [TestMethod]
        [TestCategory("Mult")]
        public void checkMult()
        {

            Calc calculator = new Calc();
            string resultado = calculator.Mult(10.2, 3);
            Assert.AreEqual("30.6", resultado);

        }



    }
}
