using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest_OnBodingExamples.Models;

namespace MSTest_OnBodingExamples.TDD
{
    [TestClass]
    [TestCategory("Calculator TestCases")]
    public class TestSumClass
    {

        [TestMethod]
        [DataRow(1,2,3)]
        [TestCategory("Sum")]
        public void checkSum(double x,double y, string expected)
        {

            Calc calculator = new Calc();
            string resultado = calculator.Sum(x,y);
            Assert.AreEqual(expected, resultado);

        }
    }
}