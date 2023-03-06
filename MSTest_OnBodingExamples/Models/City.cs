using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_1.Models
{
    class City
    {

        public int Id { get; set; }
        public String Name { get; set; }

        public String County { get; set; }

        public String Country { get; set; }

        public City() { }
        public City(Stream stream, String sheetName, String testName)
        {
            XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
            XSSFSheet sheet = (XSSFSheet)xssWorkbook.GetSheet(sheetName);
            var rows = sheet.GetRowEnumerator();
            rows.MoveNext();
            while (rows.MoveNext()) {
                XSSFRow row = (XSSFRow)rows.Current;
                if (row.GetCell(0).StringCellValue.Equals(testName)){
                    Id = int.Parse(row.GetCell(1).StringCellValue);
                    Name = row.GetCell(2).StringCellValue;
                    County = row.GetCell(3).StringCellValue;
                    Country = row.GetCell(4).StringCellValue;
                    break;
                }

            }

        }

  
    }
}
