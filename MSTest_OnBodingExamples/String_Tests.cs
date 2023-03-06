using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Prueba_1
{
    [TestClass]
    [TestCategory("Strings")]
    public class String_Tests
    {

        [TestMethod]
        public void splitString() {
            string text = @"Either of these two:
                 2069 - Customer exceeds the annual transaction count limit
                 2070 - Customer exceeds the annual transaction amount limit";
            string pattern = @"\d{4} - .+";
            // Create a Regex  
            Regex rg = new Regex(pattern);

            List <string> responseCodeList = new List<string>();
            foreach (Match item in rg.Matches(text)) {
                string code = item.Value.Trim();
                Console.WriteLine(code);
                responseCodeList.Add((code.Split("-")[0]).Trim());
                
            }

            CollectionAssert.AllItemsAreNotNull(responseCodeList);

        }

	}
    
}
