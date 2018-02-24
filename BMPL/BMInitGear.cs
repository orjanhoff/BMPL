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
        private static string init_c_db, init_o_db, init_sys_table;

        public static string bm_app_path { get; } = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string bm_path_sep { get; } = Path.DirectorySeparatorChar.ToString();

        public static string bm_folder_data { get; } = "data";
        public static string bm_folder_sys  { get; } = "system";
        public static string bm_folder_upd  { get; } = "update";
        public static string bm_folder_ext  { get; } = "extension";

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

            //Построение путей к БД
            init_c_db = Path.Combine(bm_app_path, bm_folder_data, init["initial_database"]);
            init_o_db = Path.Combine(bm_app_path, bm_folder_data, init["operational_database"]);
            init_sys_table = init["sys_table"];

            //Наполнение операционного кэша
            cache = new BMUiCache.Cache(new BMDaGear(Bm_path_db));
            cache.BuildCache();
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
