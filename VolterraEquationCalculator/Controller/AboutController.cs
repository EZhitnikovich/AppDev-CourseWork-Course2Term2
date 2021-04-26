using System;
using System.Reflection;

namespace VoltaireEquationCalculator.Controller
{
    internal class AboutController
    {
        private static AboutController instance;

        public static AboutController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AboutController();
                }

                return instance;
            }
        }

        private AboutController()
        {
        }

        public void ShowHelp()
        {
            var dll = Assembly.LoadFrom("AboutDLL.dll"); // подгрузка dll
            var type = dll.GetType("AboutDLL.About"); // получение типа
            var instance = Activator.CreateInstance(type); // получение объекта типа
            var methodInfo = type.GetMethod("Start"); // получение информации о методе

            if (methodInfo != null)
                methodInfo.Invoke(instance, null);
        }
    }
}