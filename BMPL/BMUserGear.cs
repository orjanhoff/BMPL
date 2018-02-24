using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPL
{
    class BMUserGear
    {
        //Типы обработки сервиса
        public enum UserRole { Operator = 1, Controller = 2, Administrator=3 }

        //Управление статусом пользователя
        public static void ManageUser(string userid, string status)
        {
            //1. Обработка сущности в статической БД
            new BMDaGear().ExecuteQuery(string.Format("update user set iuserstatus={0} where iuserid={1}", status, userid));

            //2. Обработка сущности в операционном кэше
            BMInitGear.UiConst.Cache["user"].Select("iuserid=" + userid).First()["iuserstatus"] = status;
        }

        //Управление ролью пользователя
        public static void ManageUserRole(string userid, string role)
        {
            //1. Обработка сущности в статической БД
            new BMDaGear().ExecuteQuery(string.Format("update user set iuserrole={0} where iuserid={1}", role, userid));

            //2. Обработка сущности в операционном кэше
            BMInitGear.UiConst.Cache["user"].Select("iuserid=" + userid).First()["iuserrole"] = role;
        }

        //Получение роли пользователя
        public static bool IsUserOn(string userid)
        {
            var st = BMInitGear.UiConst.Cache["user"].Select("iuserid=" + userid).First()["iuserstatus"].ToString();

            switch (st.Equals("1"))
            {
                case true: return true;
                default: return false;
            }
        }

        //Получение статуса пользователя
        public static UserRole GetUserRole(string userid)
        {
            var role = BMInitGear.UiConst.Cache["user"].Select("iuserid=" + userid).First()["iuserrole"].ToString();

            return (UserRole)int.Parse(role);
        }
    }
}
