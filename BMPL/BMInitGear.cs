using BMechanic.bmSessionProvider;
using BMechanic.V4Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace BMPL
{
    class BMInitGear
    {
        private static BMInitGear initGear;
        private static BMUiCache.Cache cache;
        private static Dictionary<string, string> init;
        private static string init_c_db, init_o_db, init_sys_table, init_log;

        public static string bm_app_path { get; } = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string bm_path_sep { get; } = Path.DirectorySeparatorChar.ToString();

        public static string bm_folder_data { get; } = "data";
        public static string bm_folder_sys  { get; } = Path.Combine(bm_app_path, "system");
        public static string bm_folder_upd  { get; } = Path.Combine(bm_app_path, "update");
        public static string bm_folder_ext  { get; } = Path.Combine(bm_app_path, "extension");
        public static string bm_folder_log  { get; } = Path.Combine(bm_app_path, "logs");

        private static string bm_name_xml { get; } = "bm_init_settings.xml";
        private static string bm_path_xml { get; } = Path.Combine(bm_app_path, bm_folder_data, bm_name_xml);

        public static string Bm_name_sys
        { get
            { return init_sys_table; }
        }

        public static string Bm_path_db
        { get
            { return init_c_db; }
        }

        public static string Bm_path_nosql
        { get
            { return init_o_db; }
        }

        public static string Bm_path_log
        {
            get
            { return init_log; }
        }

        private void initParams()
        {
            XmlDocument xml_doc = new XmlDocument();

            xml_doc.Load(bm_path_xml);

            string xpath = string.Format("//section");

            foreach (XmlNode node in xml_doc.DocumentElement.SelectNodes(xpath))
            {
                xpath = string.Format("//section[@name='{0}']/setting", node.Attributes["name"].Value);

                foreach (XmlNode innode in node.SelectNodes(xpath))
                {
                    init.Add(innode.Attributes["name"].Value, innode.Attributes["value"].Value);
                }
            }
        }

        public static BMInitGear UiConst
        {
            get { return initGear ?? (initGear = new BMInitGear()); }
        }

        private BMInitGear()
        {
            //Первичная инициализация
            init = new Dictionary<string, string>();
            initParams();

            //Создание рабочих директорий
            Directory.CreateDirectory(bm_folder_sys);
            Directory.CreateDirectory(bm_folder_upd);
            Directory.CreateDirectory(bm_folder_ext);
            Directory.CreateDirectory(bm_folder_log);

            //Инициализация логирования
            init_log = Path.Combine(bm_folder_log, init["log_file"]);
            init_log=init_log.Replace("gggg", DateTime.Now.Year.ToString()).Replace("mm", DateTime.Now.Month.ToString("0#")).Replace("dd", DateTime.Now.Day.ToString("0#"));

            //Построение путей к БД
            init_c_db = Path.Combine(bm_app_path, bm_folder_data, init["initial_database"]);
            init_o_db = Path.Combine(bm_app_path, bm_folder_data, init["operational_database"]);
            init_sys_table = init["sys_table"];

            //Наполнение операционного кэша
            cache = new BMUiCache.Cache(new BMDaGear(Bm_path_db));
            cache.BuildCache();

            //Инициализация операционных компонентов
            string pathRODB = "K:/Projects/Бизнес Механика (Business Mechanics)/BMDL/bm/bm.rodb.vdb";

            //Инициализация DA-провайдера
            bmVDaProvider.DaProvider.InitDataBase(pathRODB);
        }

        public BMUiCache.Cache Cache
        {
            get
            {
                return cache;
            }
        }
    }
}
