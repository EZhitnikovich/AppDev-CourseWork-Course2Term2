using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using VolterraEquationCalculator.Controller;
using VolterraEquationCalculator.Equation;

namespace VolterraEquationCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Color chartColor = default;

        private void button3_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private double K(double x, double s)
        {
            return 2 + (x - s) * (x + s);
        }

        private double F(double x)
        {
            return x * x;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDownH.Value = 0.05m;
            numericUpDownA.Value = 0m;
            numericUpDownB.Value = 3.5m;
            radioButton3.Checked = true;
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

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            double A = Convert.ToDouble(numericUpDownA.Value);
            double B = Convert.ToDouble(numericUpDownB.Value);
            double H = Convert.ToDouble(numericUpDownH.Value);
            VoltaireEquation voltaireEquation = new VoltaireEquation(F, K, H, A, B);
            voltaireEquation.Calculate();
            voltaireEquation.DrawChart(chart1, chartColor, 0);
        }
    }
}