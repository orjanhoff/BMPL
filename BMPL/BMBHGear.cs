using System;
using System.Messaging;
using BMechanic.bmDTOProvider;
using BMechanic.bmMSMQProvider;

namespace BMPL
{
    class BMBHGear
    {
        public enum bmMessageType
        {
            AUTHORIZATION = 1,
            EXECUTECMD = 2,
            PUBLISH = 3,
            REQUEST = 4,
            RESPONSE = 5,
            ROUTE = 6
        }

        public static void MessageHandler(object message)
        {
            Message request = message as Message;
            Console.WriteLine(request.Label);

            if (bmMessageType.AUTHORIZATION.Equals((bmMessageType)int.Parse(request.Label)))
            {
                //Создание DTO bmUserDTO
                bmUserDTO User = bmUserDTO.Deserialize(request.Body.ToString());
                Console.WriteLine("UserName: " + User.Username);

                //Создание сессии пользователя
                var cGuid = BMSessionGear.SessionProvider.CreateSession(User);

                Console.WriteLine(cGuid);
                Console.WriteLine(BMSessionGear.SessionProvider.CheckSessionByGuid(cGuid));

                //Формирование ответа
                bmAccessInfoDTO aInfo = new bmAccessInfoDTO();

                //Данные сессии
                aInfo.Session = new bmSessionInfo();
                aInfo.Session.Sessionid = BMSessionGear.SessionProvider.GetSession(cGuid).SessionGuid;
                aInfo.Session.Userrole = BMSessionGear.SessionProvider.GetSession(cGuid).UserRole;
                aInfo.Session.Begin = BMSessionGear.SessionProvider.GetSession(cGuid).Begin;
                aInfo.Session.Expiration = BMSessionGear.SessionProvider.GetSession(cGuid).Expiration;

                //Доступные команды
                aInfo.State = -100;
                aInfo.Accessmessage = "Нет доступных команд";

                string msg = bmAccessInfoDTO.Serialize(aInfo);

                Message response = new Message(msg);
                response.CorrelationId = request.Id;

                //Инициализация Синхронного адаптера
                bmSyncMSMQAdapter mqCLient = new bmSyncMSMQAdapter(@".\Private$\BM.MAIN.OUT");
                mqCLient.NotifyCall(response);
            }
        }
    }
}
