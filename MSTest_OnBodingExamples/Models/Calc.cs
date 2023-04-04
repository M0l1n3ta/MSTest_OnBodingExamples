using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTest_OnBodingExamples.Models
{
    public class Calc
    {
        public string result { get; set; }

        public string Sum(double x, double y)
        {
            return (x + y).ToString();
        }

        public string rest(double x, double y) {
            return String.Format("{0:0.#}", (x-y));

        }

        public string Mult(double x, double y)
        {
            return String.Format("{0:0.#}", (x * y));
        }
    }
}
