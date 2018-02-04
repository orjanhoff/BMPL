using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMPL
{
    class BMController
    {
        private static List<int> srv_on = new List<int>();

        //Обработка статуса сервиса в хранилище исполняемых объектов
        public static void ChangeServiceStatus (int srvid, int status)
        {
            switch (srv_on.Contains(srvid))
            {
                case true:
                    switch (status.Equals(1))
                    {
                        case false:srv_on.Remove(srvid); break;
                    }
                    break;
                case false:
                    switch (status.Equals(1))
                    {
                        case true: srv_on.Add(srvid); break;
                    }
                    break;
            }
        }
    }
}
