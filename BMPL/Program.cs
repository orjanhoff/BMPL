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
            try
            {
                switch (BMInitGear.UiConst.Equals(null))
                {
                    case true:
                        BMUiGear.Alert("{0}: Ошибка при построении кэша", "Ошибка приложения");
                        break;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                BMUiGear.Alert("{0}: Ошибка при инициализации: " + ex, "Ошибка приложения");
                return;
            }

            BMLoggingGear logger = new BMLoggingGear(typeof(Program), BMInitGear.Bm_path_log);
            logger.Trace("Запуск основного рабочего экрана");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BM_main());
        }
    }
}
