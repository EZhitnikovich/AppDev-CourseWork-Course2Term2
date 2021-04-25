using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VolterraEquationCalculator.Controller
{
    class DataGridController
    {
        private static DataGridController instance;

        public static DataGridController Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new DataGridController();
                }

                return instance;
            }
        }

        private DataGridController()
        {
        }

        public void FillDataGrid<T>(DataGridView dataGrid, IEnumerable<T> values, double step)
        {
            dataGrid.ColumnCount = values.Count();
            dataGrid.RowCount = 2;
            for (int i = 0; i < values.Count(); i++)
            {
                dataGrid.Rows[0].Cells[i].Value = i * step;
                dataGrid.Rows[1].Cells[i].Value = values.ElementAt(i);
            }
        }
    }
}
