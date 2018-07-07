using System.Messaging;
using BMechanic.bmDTOProvider;
using System.Data;
using System.Linq;
using System;
using System.Collections.Generic;

namespace BMApp
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
            string response;

            //I.Запрос на авторизацию
            if (bmMessageType.AUTHORIZATION.Equals((bmMessageType)int.Parse(request.Label)))
            {
                if (handleAuthorization(request, out response))
                {
                    sendResponse(request.Id, response);
                }
            }
            //II. Запрос на исполнение команды
            else if (bmMessageType.EXECUTECMD.Equals((bmMessageType)int.Parse(request.Label)))
            {

            }
        }

        private static void sendResponse(string CorellId, string xmlRs)
        {
            Message response = new Message(xmlRs);
            response.CorrelationId = CorellId;

            //Отправка уведомления
            BMMSMQGear.getInstance.Notify(response);
        }

        private static bool handleAuthorization(Message request, out string xmlRs)
        {
            //Формирование шаблона ответа
            bmAccessInfoDTO aInfo = new bmAccessInfoDTO();

            try
            {
                //Создание DTO bmUserDTO
                bmUserDTO User = bmUserDTO.Deserialize(request.Body.ToString());

                //Валидация пользовательских данных
                string userid;

                if (!BMUserGear.GetUserId(User.Username, out userid))
                {
                    aInfo.State = 101;
                    aInfo.Accessmessage = string.Format("Ошибка авторизации: Пользователь {0} не зарегистрирован", User.Username);

                    xmlRs= bmAccessInfoDTO.Serialize(aInfo);
                    return true;
                }

                if (!BMUserGear.IsUserOn(userid))
                {
                    aInfo.State = 102;
                    aInfo.Accessmessage = "Ошибка авторизации: Пользователь заблокирован";

                    xmlRs = bmAccessInfoDTO.Serialize(aInfo);
                    return true;
                }

                //Обогащение DTO
                User.Id = int.Parse(userid);
                User.Role = (int)BMUserGear.GetUserRole(userid);

                //Сбор доступного функционала
                DataRow[] services = BMHeartBeat.Cache["service_work_type"].Select("isrvworktype=1 and iwtstatus=1");

                if (services.Length.Equals(0))
                {
                    aInfo.State = 103;
                    aInfo.Accessmessage = "Нет доступных команд";

                    xmlRs = bmAccessInfoDTO.Serialize(aInfo);
                    return true;
                }

                aInfo.Commands = new bmCommands();
                aInfo.Commands.CommandsList = new List<bmCommand>();

                foreach (DataRow crow in services)
                {
                    bmCommand bmC = new bmCommand();

                    bmC.Id = int.Parse(crow["isrvid"].ToString());
                    bmC.Name = BMHeartBeat.Cache["service"].Select("isrvid=" + @crow["isrvid"]).First()["ssrvname"].ToString();
                    bmC.Description = BMHeartBeat.Cache["service"].Select("isrvid=" + @crow["isrvid"]).First()["ssrvdescription"].ToString();

                    aInfo.Commands.CommandsList.Add(bmC);
                }

                //Создание сессии пользователя
                var session = BMHeartBeat.SessionProvider.CreateSession(User);

                //Данные сессии
                aInfo.Session = session;

                //Успешный статус
                aInfo.State = 0;

                xmlRs = bmAccessInfoDTO.Serialize(aInfo);
                return true;
            }
            catch (Exception ex)
            {
                xmlRs = ex.Message;
                return false;
            }
        }
    }
}

