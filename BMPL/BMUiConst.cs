using System.IO;

namespace BMPL
{
    class BMUiConst
    {
        private static BMUiConst uiConst;
        private static BMUiCache.Cache cache;

        public static string bm_app_path= Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string bm_path_sep= Path.DirectorySeparatorChar.ToString();

        public static string bm_folder_data = "data";
        public static string bm_folder_sys = "system";
        public static string bm_folder_upd = "update";
        public static string bm_folder_ext = "extension";

        public static string bm_name_db = "bod.bmds.db";
        public static string bm_name_xml = "bm_init_settings.xml";
        public static string bm_name_sys = "sys_table";

        public static string bm_path_db = Path.Combine(bm_app_path, bm_folder_data, bm_name_db);
        public static string bm_path_xml = Path.Combine(bm_app_path, bm_folder_data, bm_name_xml);

        public static BMUiConst UiConst
        {
            get { return uiConst ?? (uiConst = new BMUiConst()); }
        }

        private BMUiConst()
        {
            cache = new BMUiCache.Cache(new BMDaGear());
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
