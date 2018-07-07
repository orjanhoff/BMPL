using System;
using System.IO;
using System.Windows.Forms;

namespace BMApp
{
    class BMLoggingGear
    {
        public enum LEVEL
        {
            TRACE = 6,
            DEBUG = 5,
            INFO = 4,
            WARN = 3,
            ERROR = 2,
            FATAL = 1
        }

        private static readonly object sync = new object();
        private string path_to_file;
        private object l_class;

        public BMLoggingGear(object obj, string path)
        {
            l_class = obj;
            path_to_file = path;
        }

        //Запись данных в файл
        private void writeData(string text, LEVEL Level = LEVEL.INFO)
        {
            lock (sync)
            {
                try
                {
                    using (FileStream file = new FileStream(path_to_file, FileMode.Append, FileAccess.Write, FileShare.Read))
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        writer.WriteLine(string.Format("{0}:{1}:{2}: {3}", Level, DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), l_class, text));
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public void Trace(string text)
        {
            writeData(text, LEVEL.TRACE);
        }

        public void Debug(string text)
        {
            writeData(text, LEVEL.DEBUG);
        }

        public void Info(string text)
        {
            writeData(text, LEVEL.INFO);
        }

        public void Warn(string text)
        {
            writeData(text, LEVEL.WARN);
        }

        public void Error(string text)
        {
            writeData(text, LEVEL.ERROR);
        }

        public void Fatal(string text)
        {
            writeData(text, LEVEL.FATAL);
        }
    }

    public struct LEVELTEXT
    {
        public const string TRACE = "TRACE";
        public const string DEBUG = "DEBUG";
        public const string INFO = "INFO";
        public const string WARN = "WARN";
        public const string ERROR = "ERROR";
        public const string FATAL = "FATAL";

        /*
        Trace — вывод всего подряд. На тот случай, если Debug не позволяет локализовать ошибку. В нем полезно отмечать вызовы разнообразных блокирующих и асинхронных операций.
        Debug — журналирование моментов вызова «крупных» операций. Старт/остановка потока, запрос пользователя и т.п.
        Info — разовые операции, которые повторяются крайне редко, но не регулярно. (загрузка конфига, плагина, запуск бэкапа)
        Warning — неожиданные параметры вызова, странный формат запроса, использование дефолтных значений в замен не корректных. Вообще все, что может свидетельствовать о не штатном использовании.
        Error — повод для внимания разработчиков. Тут интересно окружение конкретного места ошибки.
        Fatal — тут и так понятно. Выводим все до чего дотянуться можем, так как дальше приложение работать не будет.
        */
    }
}