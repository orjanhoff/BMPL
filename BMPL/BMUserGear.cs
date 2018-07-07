using System;
using System.Data;
using System.Linq;

namespace BMApp
{
    class BMUserGear
    {
        //Типы ролей
        public enum UserRole { Operator = 1, Controller = 2, Administrator=3 }

        //Управление статусом пользователя
        public static void ManageUser(string userid, string status)
        {
            //1. Обработка сущности в статической БД
            BMHeartBeat.DbProvider.ExecuteQuery(string.Format("update user set iuserstatus={0} where iuserid={1}", status, userid));

            //2. Обработка сущности в операционном кэше
            BMHeartBeat.Cache["user"].Select("iuserid=" + userid).First()["iuserstatus"] = status;
        }

        //Управление ролью пользователя
        public static void ManageUserRole(string userid, string role)
        {
            //1. Обработка сущности в статической БД
            BMHeartBeat.DbProvider.ExecuteQuery(string.Format("update user set iuserrole={0} where iuserid={1}", role, userid));

            //2. Обработка сущности в операционном кэше
            BMHeartBeat.Cache["user"].Select("iuserid=" + userid).First()["iuserrole"] = role;
        }

        //Поиск пользователя по DomainUsername
        public static bool GetUserId (string username, out string userid)
        {
            try
            {
                userid = BMHeartBeat.Cache["user"].Select(string.Format("susername='{0}'", username)).First()["iuserid"].ToString();
                return !string.IsNullOrEmpty(userid);
            }
            catch (NullReferenceException)
            {
                userid = string.Empty;
                return false;
            }
        }

        //Получение статуса пользователя
        public static bool IsUserOn(string userid)
        {
            var st = BMHeartBeat.Cache["user"].Select("iuserid=" + userid).First()["iuserstatus"].ToString();

            switch (st.Equals("1"))
            {
                case true: return true;
                default: return false;
            }
        }

        //Получение роли пользователя
        public static UserRole GetUserRole(string userid)
        {
            var role = BMHeartBeat.Cache["user"].Select("iuserid=" + userid).First()["iuserrole"].ToString();

            return (UserRole)int.Parse(role);
        }
    }
}
