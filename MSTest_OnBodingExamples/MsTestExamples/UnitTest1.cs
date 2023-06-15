using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Prueba_1.Models;


namespace MsTestExamples
{
    [TestClass]
    public class UnitTest
    {

       
        [TestMethod]
        public void checkList()
        {

            List<String> lista = new List<string>() {
            "Long Bow",
            "Short Bow",
            "short sword"};

            CollectionAssert.Contains(lista, "Long Bow");
        }

        

        
    }
}
