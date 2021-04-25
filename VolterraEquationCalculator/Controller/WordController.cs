using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using Word = Microsoft.Office.Interop.Word;

namespace VolterraEquationCalculator.Controller
{
    class WordController
    {
        private static WordController instance;

        public static WordController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WordController();
                }

                return instance;
            }
        }

        private WordController()
        {
        }

        public void FillWord<T>(string name, IEnumerable<T> values, double step)
        {
            Word.Application wd = new Word.Application();

            wd.Visible = true;
            var document = wd.Documents.Add(Type.Missing);

            var table = document.Tables.Add(document.Range(), values.Count(), 2);

            table.set_Style("Сетка таблицы");

            for (int i = 1; i < values.Count()+1; i++)
            {
                table.Cell(i, 1).Range.Text = ((i - 1) * step).ToString();
                table.Cell(i, 2).Range.Text = values.ElementAt(i - 1).ToString();
            }
        }
    }
}
