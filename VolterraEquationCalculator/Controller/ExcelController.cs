using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
            sheet.Cells[1, 2] = "y";

            for (int i = 1; i < values.Count() + 1; i++)
            {
                sheet.Cells[i + 1, 1] = step*(i-1);
                sheet.Cells[i + 1, 2] = values.ElementAt(i-1);
            }

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)sheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(110, 0, 350, 250);
            Excel.Chart chart = myChart.Chart;
            Excel.SeriesCollection seriesCollection = (Excel.SeriesCollection)chart.SeriesCollection(Type.Missing);
            Excel.Series series = seriesCollection.NewSeries();
            series.XValues = sheet.get_Range("A2", "A"+(values.Count()+1).ToString());
            series.Values = sheet.get_Range("B2", "B" + (values.Count() + 1).ToString());
            chart.ChartType = Excel.XlChartType.xlXYScatterSmooth;
        }
    }
}
