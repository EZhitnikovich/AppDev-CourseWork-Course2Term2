using System.Drawing;
using System.Windows.Forms;

namespace ColorPickerDLL
{
    internal class ColorPicker
    {
        public Color SelectColor()
        {
            var colorDialog = new ColorDialog();
            return colorDialog.ShowDialog() == DialogResult.Cancel ? default : colorDialog.Color;
        }
    }
}