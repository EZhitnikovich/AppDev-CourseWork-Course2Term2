using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VolterraEquationCalculator.Controller
{
    internal class DataGridController
    {
        private static DataGridController instance;
        private readonly object dataGridLock = new object();

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

        public void FillDataGrid<T>(ref DataGridView dataGrid, IEnumerable<T> values, double step)
        {
            lock (dataGridLock)
            {
                dataGrid.ColumnCount = 1;
                dataGrid.Columns[0].HeaderText = "i = 0";
                dataGrid.RowCount = 2;
                for (int i = 0; i < values.Count(); i++)
                {
                    if (i < values.Count() - 1)
                        dataGrid.Columns.Add("Column" + i.ToString(), "i = " + (i + 1).ToString());

                    dataGrid.Rows[0].Cells[i].Value = i * step;
                    dataGrid.Rows[1].Cells[i].Value = values.ElementAt(i);
                }
            }
        }
    }
}