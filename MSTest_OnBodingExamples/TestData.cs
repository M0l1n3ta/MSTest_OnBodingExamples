using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System;
using NPOI.XSSF.UserModel;
using Prueba_1.Models;
using CrossCutting.Mappers;
using System.Xml.Linq;
using Prueba_1.Enums;
using System.Linq;
using System.Reflection;

namespace Prueba_1
{
    [TestClass]
    [TestCategory("LoadExcelData")]
    public class TestData
    {
        public static TestDataDTO testData;

        [TestMethod]
        public void TestLoadData()
        {
            Models.City data = ReadExcel("Resources/TestData.xlsx");
            Assert.AreEqual(data.Name, "San Sebastian de los Reyes");
        }


        [TestMethod]
        public void TestLoadOrders()
        {
            List<TestDataDTO> res = new List<TestDataDTO>();
            List<ExcelOrder> data = ReadExcel("Resources/Input_Orders_Response_Code_Tests.xlsx","Orders");
            foreach (ExcelOrder item in data)
            {
                res.Add(ParseOrders(item));
            }
            InitializeMapper.InitializeAutoMapper();
            CollectionAssert.AllItemsAreNotNull(data);
        }


        [TestMethod]
        public void ParseXML2Object()
        {
            List<TestDataDTO> res = new List<TestDataDTO>();
            List<ExcelOrder> data = ReadExcel("Resources/Input_Orders_Response_Code_Tests.xlsx", "Orders");
            XDocument doc = XDocument.Parse(data[0].Request);
            IEnumerable<InputOrder> result = from c in doc.Descendants("Order")
                                                  select new InputOrder(c);
            Assert.AreEqual(result.ToList()[0].OrderId, "86640");
        }


        static Models.City ReadExcel(string res)
        {

            City dato = new City();
            using (var stream = new FileStream(res, FileMode.Open))
            {
                dato = new City(stream, "Data", "ES_001");
            }

            return dato;
        }

        static List<ExcelOrder> ReadExcel(string res,string sheetName){

            List<ExcelOrder> data = new List<ExcelOrder>();
            using (var stream = new FileStream(res, FileMode.Open))
            {
                XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                XSSFSheet sheet = (XSSFSheet)xssWorkbook.GetSheet(sheetName);
                var rows = sheet.GetRowEnumerator();
                rows.MoveNext();
                while (rows.MoveNext())
                {
                    data.Add(new ExcelOrder((XSSFRow)rows.Current));
                }
            }
            return data;
        }

        static TestDataDTO ParseOrders(ExcelOrder o) {

            testData = new TestDataDTO();
            testData.ServiceType = ServiceModel.Soap;
        
                XDocument doc = XDocument.Parse(o.Request);

            //doc.Descendants().Where(x => x.Name.LocalName == "Order")
            var elements = doc.Descendants("Order").Select(y => new {
                    OrderId = (string)y.Elements().Where(z => z.Name.LocalName == "OrderNo").FirstOrDefault(),
                    SalesDate = (String)y.Elements().Where(z => z.Name.LocalName == "SalesDate").FirstOrDefault(),
                    CountryFrom = (string)y.Elements().Where(z => z.Name.LocalName == "CountryFrom").FirstOrDefault(),
                    CountryTo = (string)y.Elements().Where(z => z.Name.LocalName == "CountryTo").FirstOrDefault(),
                }).ToList();
            

        
            return testData;
        }

        
    }   
}
