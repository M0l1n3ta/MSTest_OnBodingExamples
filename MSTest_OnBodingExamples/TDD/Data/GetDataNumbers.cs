
using System.Collections.Generic;
using System.IO;

namespace MSTest_OnBodingExamples.TDD
{

    public class GetDataNumbers{

        public static IEnumerable<object[]> GetNumbers
        {
            get{
                string[] csvLines = File.ReadAllLines("Resources/TestNumbersData.csv");
                var testCases = new List<object[]>();
                foreach(var item in csvLines)
                {
                    var values = item.Split(',');
                    var value = new object[] {double.Parse(values[0]),
                                     double.Parse(values[1]),
                                    values[2]};
                    testCases.Add(value);
                }
                return testCases;
            }
        }
    }

}