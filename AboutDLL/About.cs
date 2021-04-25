using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AboutDLL
{
    public class About
    {
        public void Start()
        {
            var form = new Form();
            InitForm(form);

            form.ShowDialog();
        }

        private void InitForm(Form form)
        {
            form.Size = new Size(400, 300);
            form.MaximumSize = form.Size;
            form.MinimumSize = form.Size;

            TextBox textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Size = new Size(350, 200);
            textBox.WordWrap = true;
            textBox.Location = new Point(15, 0);
            textBox.Enabled = false;
            textBox.Font = new Font("Arial", 12);
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.Text = "Курсовая работа студента 2 курса гр.10701219 Житниковича Евгения. " +
                           "Вычисление интегрального уравнение Вольтерра первого рода.";

            Button button = new Button();
            button.Size = new Size(350, 20);
            button.Location = new Point(15, 230);
            button.Click += ButtonOnClick;
            button.Text = "Помощь";

            form.Controls.Add(textBox);
            form.Controls.Add(button);
        }

        private void ButtonOnClick(object sender, EventArgs e)
        {
            Help.ShowHelp((Button)sender, "Help.chm");
        }
    }
}
