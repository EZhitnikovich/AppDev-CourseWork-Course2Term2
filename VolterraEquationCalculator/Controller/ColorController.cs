using System;
using System.Drawing;
using System.Reflection;

namespace VolterraEquationCalculator.Controller
{
    internal class ColorController
    {
        private static ColorController instance;

        public static ColorController Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new ColorController();
                }

                return instance;
            }
        }

        private ColorController()
        {
        }

        public Color SelectColor()
        {
            Color color = default;
            var dll = Assembly.LoadFrom("ColorPickerDLL.dll"); // подгрузка dll
            var type = dll.GetType("ColorPickerDLL.ColorPicker"); // получение типа
            var instance = Activator.CreateInstance(type); // получение объекта типа
            var methodInfo = type.GetMethod("SelectColor"); // получение информации о методе

            if (!(methodInfo is null))
            {
                color = (Color)methodInfo.Invoke(instance, null);
            }
            else
            {
                color = default;
            }

            return color;
        }
    }
}