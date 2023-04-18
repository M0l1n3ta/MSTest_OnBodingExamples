using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest_OnBodingExamples.Models;

namespace MSTest_OnBodingExamples.TDD
{
    [TestClass]
    [TestCategory("Calculator TestCases")]
    public class TestSumClass
    {

        Calc calculator;

        public static List<object[]> Numeros
        {
            get{
                return new List<object[]>{
                     new object[] {11.2,11.2,"22.4"},
                     new object[]{ 2,3,"5"}
                };
            }
        }

        public static IEnumerable<object[]> GetNumbers()
        {
            
            return new List<object[]>{
                    new object[] {11.2,11.2,"22.4"},
                    new object[]{ 2,3,"5"},
                    new object[] {12,13,"25"}
            };
        
        }

        [TestInitialize]
        public void Testinitialize(){
            calculator = new Calc();
        }

        [TestMethod]
        [DataRow(1,2,"3")]
        [DataRow(12.5,13.4,"25.9")]
        [TestCategory("Sum")]
        public void checkSum(double x,double y, string expected)
        {

            string resultado = calculator.Sum(x,y);
            Assert.AreEqual(expected, resultado);

        }

        [TestMethod]
        [DynamicData(nameof(Numeros))]
        [TestCategory("Sum")]
        public void checkSum_2(double x,double y, string expected)
        {

            string resultado = calculator.Sum(x,y);
            Assert.AreEqual(expected, resultado);

        }


        
        [TestMethod]
        [DynamicData(nameof(GetNumbers),DynamicDataSourceType.Method)]
        [TestCategory("Sum")]
        public void checkSum_3(double x,double y, string expected)
        {
            string resultado = calculator.Sum(x,y);
            Assert.AreEqual(expected, resultado);

        }

        [TestMethod]
        [DynamicData(nameof(TestNumbersData.GetNumbers),typeof(TestNumbersData),DynamicDataSourceType.Method)]
        [TestCategory("Sum")]
        public void checkSum_4(double x,double y, string expected)
        {

            string resultado = calculator.Sum(x,y);
            Assert.AreEqual(expected, resultado);

        }

        [TestMethod]
        [DynamicData(nameof(GetDataNumbers.GetNumbers),typeof(GetDataNumbers))]
        [TestCategory("Sum")]
        public void checkSum_5(double x,double y, string expected)
        {

    
            string resultado = calculator.Sum(x,y);
            Assert.AreEqual(expected, resultado);

        }
    
    }
}