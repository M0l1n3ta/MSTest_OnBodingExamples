

using System.Collections.Generic;

namespace MSTest_OnBodingExamples.TDD
{
    public class TestNumbersData{

        public static IEnumerable<object[]> GetNumbers()
        {
            
            return new List<object[]>{
                    new object[] {11.2,11.2,"22.4"},
                    new object[]{ 2,3,"5"},
                    new object[] {12,13,"25"}
            };
        
        }
    }

}