using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject2.Utilities
{
    internal class ExcelUtility
    {
        public static List<string> ReadExcelFile(string excelFilePath, string sheetName, int columnNumber)
        {
            List<string> laptopModels = new List<string>();
            try
            {
                FileInfo fileInfo = new FileInfo(excelFilePath);

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetName];
                    int rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        string laptopModel = worksheet.Cells[row, columnNumber].Value?.ToString();
                        laptopModels.Add(laptopModel);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading Excel file: {ex.Message}");
            }
            return laptopModels;
        }
    }
}


        
