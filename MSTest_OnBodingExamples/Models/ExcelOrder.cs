using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace Prueba_1.Models
{
    public class ExcelOrder
    {
        public List<KeyValuePair<string, string>> ExpectedResponseCode { get; set; }

        public String Request{get; set;}


        public ExcelOrder() { }
        public ExcelOrder(XSSFRow row)
        {
            
            string pattern = @".* - .+";
            // Create a Regex  
            Regex rg = new Regex(pattern);
            string text = row.GetCell(1).StringCellValue;
            ExpectedResponseCode = new List<KeyValuePair<string, string>>();
            foreach (Match item in rg.Matches(text))
            {
                String[] data = item.Value.Split("-");
                ExpectedResponseCode.Add(new KeyValuePair<string, string>(data[0].Trim(), data[1].Trim()));
                            
            }
            Request = row.GetCell(3).StringCellValue;
        }
    }
}
