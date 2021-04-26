using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using VoltaireEquationCalculator.Controller;
using VoltaireEquationCalculator.Equations;

namespace VoltaireEquationCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Color chartColor = default;
        private VoltaireEquation voltaireEquation;

        private void button3_Click(object sender, EventArgs e)
        {
            Equation equation = SelectEquation();
            Calculate(equation);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDownH.Value = 0.05m;
            numericUpDownA.Value = 0m;
            numericUpDownB.Value = 3.5m;
            radioButton3.Checked = true;
            radioButton4.Checked = true;
            dataGridView1.RowCount = 2;
            dataGridView1.ColumnCount = 10;
            dataGridView1.ReadOnly = true;
            dataGridView1.Rows[0].HeaderCell.Value = "x=";
            dataGridView1.Rows[1].HeaderCell.Value = "y=";
            chart1.Series[0].ChartType = SeriesChartType.Spline;
            for (int i = 0; i < 10; i++)
            {
                chart1.Series[0].Points.AddXY(i, i * i);
                dataGridView1.Rows[0].Cells[i].Value = i;
                dataGridView1.Rows[1].Cells[i].Value = i * i;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CloseApp();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CloseApp();
        }

        private void CloseApp()
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chartColor = ColorController.Instance.SelectColor();
            ((Button)sender).ForeColor = chartColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var chart1Series in chart1.Series)
            {
                chart1Series.Points.Clear();
            }

            voltaireEquation = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Equation equation = SelectEquation();
            Calculate(equation);
        }

        private void Calculate(Equation equation)
        {
            double A = Convert.ToDouble(numericUpDownA.Value);
            double B = Convert.ToDouble(numericUpDownB.Value);
            double H = Convert.ToDouble(numericUpDownH.Value);
            voltaireEquation = new VoltaireEquation(H, A, B, equation);
            voltaireEquation.Calculate();
            voltaireEquation.DrawChart(chart1, chartColor, 0);
        }

        private Equation SelectEquation()
        {
            Equation equation = null;

            if (radioButton4.Checked)
            {
                equation = new Equation();
            }
            else if (radioButton5.Checked)
            {
                equation = new EquationOneMinusX();
            }

            return equation;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AboutController.Instance.ShowHelp();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(SelectOutputType);
            thread.Start();
        }

        private void SelectOutputType()
        {
            if (radioButton1.Checked)
            {
                ExportData("word");
            }
            else if (radioButton2.Checked)
            {
                ExportData("excel");
            }
            else if (radioButton3.Checked)
            {
                ExportData("table");
            }
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportData("excel");
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportData("word");
        }

        private void таблицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportData("table");
        }

        private void ExportData(string selector)
        {
            if (voltaireEquation == null) return;

            try
            {
                switch (selector.ToLower())
                {
                    case "excel":
                        ExcelController.Instance.FillExcel("ExcelOutput", voltaireEquation.Result,
                            (double)numericUpDownH.Value); break;
                    case "word":
                        WordController.Instance.FillWord("WordOutput", voltaireEquation.Result,
                            (double)numericUpDownH.Value); break;
                    case "table":
                        DataGridController.Instance.FillDataGrid(ref dataGridView1, voltaireEquation.Result,
                            (double)numericUpDownH.Value); break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}