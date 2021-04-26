using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace VoltaireEquationCalculator.Controller
{
    class ExcelController
    {
        private static ExcelController instance;

        public static ExcelController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExcelController();
                }

                return instance;
            }
        }

        private ExcelController()
        {
        }

        public void FillExcel<T>(string name, IEnumerable<T> values, double step)
        {
            Excel.Application ex = new Excel.Application();

            ex.Visible = true;
            ex.SheetsInNewWorkbook = 1;
            var workBook = ex.Workbooks.Add(Type.Missing);

            var sheet = (Excel.Worksheet) ex.Worksheets.Item[1];
            sheet.Name = name;

            sheet.Cells[1, 1] = "x";
            sheet.Cells[2, 1] = "y";

            for (int i = 1; i < values.Count() + 1; i++)
            {
                sheet.Cells[1, i + 1] = step*(i-1);
                sheet.Cells[2, i + 1] = values.ElementAt(i-1);
            }
        }
    }
}
