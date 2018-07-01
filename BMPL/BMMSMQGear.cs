using BMechanic.bmMSMQProvider;
using System;
using System.Messaging;
using System.Threading;

namespace BMPL
{
    class BMMSMQGear
    {
        //Сервис входящих сообщений
        bmAsyncMSMQAdapter mqServer;

        //Сервис уведомлений
        bmSyncMSMQAdapter mqCLient;

        //Атрибуты управления
        bool isOn;
        bool notifyOn;
        bool receiveOn;

        private void turnOn(bool state)
        {
            if (!isOn.Equals(state))
            { isOn = state; }
            else { return; }

            if (!isOn)
            {
                notifyOn = false; receiveOn = false;
            }
        }

        private void turnNotify(bool state)
        {
            notifyOn = state;
        }

        private void turnReceive(bool state)
        {
            receiveOn = state;
        }

        public BMMSMQGear(WaitCallback messageHandler)
        {
          //Инициализация Асинхронного листенера
          mqServer = new bmAsyncMSMQAdapter(@".\Private$\BM.MAIN.IN", messageHandler);

          //Инициализация Синхронного адаптера
          mqCLient = new bmSyncMSMQAdapter(@".\Private$\BM.MAIN.OUT");
        }

        public void Init()
        {
            //Инициализация параметров управления
            turnOn(true);
            turnNotify(true);
            turnReceive(true);
        }

        public void StartListener()
        {
            if (isOn && receiveOn)
                mqServer.StartListening();
            else
                throw new SystemException("Интеграционное взаимодействие отключено");
        }

        public void StopListener()
        {
            if (receiveOn)
            {
                mqServer.StopListening();
                turnReceive(false);
            }
        }

        public void Notify(Message message)
        {
            if (isOn && notifyOn)
                mqCLient.NotifyCall(message);
            else
                throw new SystemException("Отправка уведомлений отключена");
        }
     }
 }
