using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPL
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            switch (BMUiConst.UiConst.Equals(null))
            {
                case true:
                    BMUiCustomControls.UIException.Alert("{0}: Ошибка при построении кэша", "Ошибка приложения");
                    break;
                default: break;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BM_main());
        }
    }
}
