using System;
using System.Windows.Forms;

namespace BMApp
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
                        BMUiGear.Alert("{0}: Ошибка первичной инициализации параметров", "Ошибка приложения");
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

            logger.Info("Инициализация основных компонентов приложения");

            try
            {
                BMHeartBeat bmHB = new BMHeartBeat();
                bmHB.Init();
            }
            catch (Exception ex)
            {
                logger.Fatal("Ошибка при инициализации: " + ex);
                BMUiGear.Alert("{0}: Ошибка при инициализации: " + ex, "Ошибка приложения");
                return;
            }

            logger.Info("Запуск основного рабочего экрана");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
