using System.Messaging;
using BMechanic.bmDTOProvider;
using System.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using static BMApp.BMBioEngine;

namespace BMApp
{
    class BMBHGear
    {
        //Логгер
        static BMLoggingGear logger = new BMLoggingGear(typeof(BMBHGear), BMInitGear.Bm_path_log);

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

            logger.Debug(string.Format("Обработка входящего сообщения ID:{0}", request.Id));

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
                if (handleCommandRequest(request, out response))
                {
                    sendResponse(request.Id, response);
                }
            }
        }

        private static void sendResponse(string CorellId, string xmlRs)
        {
            Message response = new Message(xmlRs);
            response.CorrelationId = CorellId;

            logger.Debug(string.Format("Отправка сообщения с CorrelationId:{0}", response.CorrelationId));

            //Отправка уведомления
            try
            {
                BMMSMQGear.getInstance.Notify(response);
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("Ошибка при отправке сообщения: {0}", ex.Message));
                return;
            }
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

                    xmlRs = bmAccessInfoDTO.Serialize(aInfo);
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
                logger.Debug(string.Format("Создание сессии для пользователя {0}", User.Username));
                var session = BMHeartBeat.SessionProvider.CreateSession(User);
                logger.Info(string.Format("Создана сессия ID:{0} для пользователя {1}", session.Sessionid, session.Username));

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
                logger.Error(string.Format("Ошибка при авторизации:{0}", ex.Message));
                return false;
            }
        }

        private static bool handleCommandRequest(Message request, out string xmlRs)
        {
            //Формирование шаблона ответа
            bmResponseDTO response = new bmResponseDTO();

            try
            {
                //Создание DTO bmCommandDTO
                bmCommandDTO cmd = bmCommandDTO.Deserialize(request.Body.ToString());

                //Валидация сессии
                if (!BMHeartBeat.SessionProvider.CheckSessionByGuid(cmd.Sessionid))
                {
                    response.Status = 104;
                    response.Message = string.Format("Ошибка обработки команды: истекло время сессии {0}", cmd.Sessionid);

                    xmlRs = bmResponseDTO.Serialize(response);
                    return true;
                }

                //Валидация сервиса
                if (!BMSrvGear.IsServiceOn(cmd.Id.ToString()))
                {
                    response.Status = 105;
                    response.Message = string.Format("Ошибка обработки команды: Сервис {0} не доступен", BMHeartBeat.Cache["service"].Select("isrvid=" + cmd.Id).First()["ssrvname"].ToString());

                    xmlRs = bmResponseDTO.Serialize(response);
                    return true;
                }

                //Валидация сервиса на клиентскую обработку
                if (!BMSrvGear.IsWorkTypeAllowed(cmd.Id.ToString(), BMSrvGear.ServiceWorkType.Client))
                {
                    response.Status = 106;
                    response.Message = string.Format("Ошибка обработки команды: Сервис {0} не доступен для обработки на клиенте", BMHeartBeat.Cache["service"].Select("isrvid=" + cmd.Id).First()["ssrvname"].ToString());

                    xmlRs = bmResponseDTO.Serialize(response);
                    return true;
                }

                //Формирование спина
                Spin spin = new Spin();

                spin.SessionId = cmd.Sessionid;
                spin.Service = cmd.Id;
                spin.Priority = new Random().Next(1,9);

                //Сохранение спина в хранилище
                BMHeartBeat.DraftSpinProducer.Produce(spin);

                //Успешный статус
                response.Status = 0;
                response.Message = "Задание поставлено в очередь на обработку";

                xmlRs = bmResponseDTO.Serialize(response);
                return true;

            }
            catch (Exception ex)
            {
                xmlRs = ex.Message;
                logger.Error(string.Format("Ошибка при обработке сообщения:{0}", ex.Message));
                return false;
            }
        }
    }
}
