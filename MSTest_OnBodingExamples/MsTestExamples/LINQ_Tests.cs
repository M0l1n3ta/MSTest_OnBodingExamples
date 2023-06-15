using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTestExamples
{

    [TestClass]
    [TestCategory("LINQ")]
    public class LINQ_Tests
    {
        [TestMethod]
        public void testLabdaExpresion() {

            string[] names = new string[] { "John", "Paul", "George", "Ringo" };
            var name = names.Where(s => s.StartsWith("P")).ToList();
            CollectionAssert.Contains(name, "Paul");
        }

       
    }
}
