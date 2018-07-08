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

        public bool IsOn
        { get { return isOn; } }

        public bool IsReceiveOn
        { get { return receiveOn; } }

        public bool IsNotifyOn
        { get { return notifyOn; } }

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

        public void SwitchReceive (bool state)
        {
            if (state)
            {
                StartListener();
            }
            else
            {
                StopListener();
            }
        }

        public void SwitchNotify (bool state)
        {
            turnNotify(state);
        }

        public void SwitchAll (bool state)
        {
            if (state)
            {
                turnNotify(state);
                turnOn(state);

                StartListener();
            }
            else
            {
                turnOn(state);
                StopListener();
            }
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
        }

        public void StartListener()
        {
            turnReceive(true);

            if (isOn && receiveOn)
                mqServer.StartListening();
            else
                throw new SystemException("Интеграционное взаимодействие отключено");
        }

        public void StopListener()
        {
            turnReceive(false);

            if (!receiveOn)
            {
                mqServer.StopListening();
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
