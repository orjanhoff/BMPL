using BMechanic.bmMSMQProvider;
using System;
using System.Messaging;
using System.Threading;

namespace BMApp
{
    class BMMSMQGear
    {
        //Singleton
        private static BMMSMQGear instance;

        //Сервис входящих сообщений
        bmAsyncMSMQAdapter mqServer;

        //Сервис уведомлений
        bmSyncMSMQAdapter mqCLient;

        //Атрибуты управления
        bool isOn;
        bool notifyOn;
        bool receiveOn;

        private BMMSMQGear()
        {}

        public static BMMSMQGear getInstance
        {
            get { return instance ?? (instance = new BMMSMQGear()); }
        }

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

        public void Init(WaitCallback messageHandler)
        {
          //Инициализация Асинхронного листенера
          mqServer = new bmAsyncMSMQAdapter(@".\Private$\BM.MAIN.IN", messageHandler);

          //Инициализация Синхронного адаптера
          mqCLient = new bmSyncMSMQAdapter(@".\Private$\BM.MAIN.OUT");

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
