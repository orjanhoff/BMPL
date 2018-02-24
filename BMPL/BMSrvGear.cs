using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPL
{
    class BMSrvGear
    {
        //Типы обработки сервиса
        public enum ServiceWorkType { Client = 1, Server = 2 }
        
        //Управление статусом сервиса
        public static void ManageService (string srvid, string status)
        {
                //1. Обработка сущности в статической БД
                new BMDaGear().ExecuteQuery(string.Format("update service set isrvstatus={0} where isrvid={1}", status, srvid));

                //2. Обработка сущности в операционном кэше
                BMInitGear.UiConst.Cache["service"].Select("isrvid=" + srvid).First()["isrvstatus"] = status;
        }

        //Управление обработчиком сервиса
        public static void ManageWorkType(string srvid, string status, string swtype)
        {
            //1. Обработка сущности в статической БД
            new BMDaGear().ExecuteQuery(string.Format("update service_work_type set iwtstatus=={0} where isrvid={1} and isrvworktype={2}", status, srvid,swtype));

            //2. Обработка сущности в операционном кэше
            BMInitGear.UiConst.Cache["service_work_type"].Select(string.Format("isrvid={0} and isrvworktype={1}", srvid, swtype)).First()["iwtstatus"] = status;
        }

        //Получение статуса сервиса
        public static bool IsServiceOn (string srvid)
        {
            var st = BMInitGear.UiConst.Cache["service"].Select("isrvid=" + srvid).First()["isrvstatus"].ToString();

            switch (st.Equals("1"))
            {
                case true: return true;
                default: return false;
            }
        }

        //Проверка на доступность обработки
        public static bool IsWorkTypeAllowed(string srvid, ServiceWorkType swtype)
        {
            try
            {
                var st = BMInitGear.UiConst.Cache["service_work_type"].Select(string.Format("isrvid={0} and isrvworktype={1}", srvid, ((int)swtype).ToString())).First()["iwtstatus"].ToString();

                switch (st.Equals("1"))
                {
                    case true: return true;
                    default: return false;
                }
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

    }
}
