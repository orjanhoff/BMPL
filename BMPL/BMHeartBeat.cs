using BMechanic.bmSessionProvider;
using BMechanic.V4Net;
using System;
using static BMApp.BMBioEngine;

namespace BMApp
{
    //Координатор основных сущностей
    class BMHeartBeat
    {
        //Логирование
        BMLoggingGear logger = new BMLoggingGear(typeof(BMHeartBeat), BMInitGear.Bm_path_log);

        //SQLite DA провайдер
        private static BMDaGear dbProvider;
        //RunTime кэш
        private static BMUiCache.Cache cache;
        //Провайдер сессий
        private static bmSessionProvider sProvider;

        //Хранилище Draft-спинов
        private static SpinStorage draftSpinStorage;
        //Продюсер Draft-спинов
        private static SpinProducer draftProducer;
        //Обработчик Draft-спинов
        private static SpinConsumer draftConsumer;

        //Хранилище Done-спинов
        private static SpinStorage doneSpinStorage;
        //Продюсер Done-спинов
        private static SpinProducer doneProducer;
        //Обработчик Done-спинов
        private static SpinConsumer doneConsumer;


        public BMHeartBeat()
        {
            if (string.IsNullOrEmpty(BMInitGear.Bm_path_cdb) || string.IsNullOrEmpty(BMInitGear.Bm_path_odb))
            {
                throw new NullReferenceException("Не определены пути к рабочим экземплярам баз данных");
            }
        }

        public void Init()
        {
            //Инициализация SQLite DA-провайдера
            dbProvider = new BMDaGear(BMInitGear.Bm_path_cdb);
            logger.Info("SQLite DA-провайдер инициализирован");
            
            //Инициализация V4NET DA-провайдера
            bmVDaProvider.DaProvider.InitDataBase(BMInitGear.Bm_path_odb);
            logger.Info("V4NET DA-провайдер инициализирован");

            //Инициализация и наполнение операционного кэша
            cache = new BMUiCache.Cache(dbProvider);
            cache.BuildCache();
            logger.Info("Операционный кэш создан");

            //Инициализация узла интеграции
            BMMSMQGear.getInstance.Init(BMBHGear.MessageHandler);
            logger.Info("Узел интеграции инициализирован");
            BMMSMQGear.getInstance.StartListener();
            logger.Info("Асинхронный MSMQ адаптер запущен");

            //Инициализация провайдера сессий
            sProvider = new bmSessionProvider(bmVDaProvider.DaProvider);
            logger.Info("Провайдер сессий инициализирован");

            //*Done-спины*\\
            //Инициализация хранилища Done-спинов
            doneSpinStorage = new SpinStorage(bmSpinStorageType.OUTCOME);
            logger.Info("Хранилище Done-спинов инициализировано");

            //Инициализация продюсера Done-спинов
            doneProducer = new SpinProducer(doneSpinStorage);
            logger.Info("Продюсер Done-спинов инициализирован");

            //Инициализация обработчика Done-спинов
            doneConsumer = new SpinConsumer(doneSpinStorage);
            //doneConsumer.BeginConsume();
            logger.Info("Обработчик Done-спинов инициализирован");

            //*Draft-спины*\\
            //Инициализация хранилища Draft-спинов
            draftSpinStorage = new SpinStorage(bmSpinStorageType.INCOME);
            logger.Info("Хранилище Draft-спинов инициализировано");

            //Инициализация продюсера Draft-спинов
            draftProducer = new SpinProducer(draftSpinStorage);
            logger.Info("Продюсер Draft-спинов инициализирован");

            //Инициализация обработчика Draft-спинов + Done-продюсер
            draftConsumer = new SpinConsumer(draftSpinStorage, doneProducer);
            draftConsumer.BeginConsume();
            logger.Info("Обработчик Draft-спинов инициализирован");
        }

        public static BMUiCache.Cache Cache
        {
            get
            {
                return cache;
            }
        }

        public static BMDaGear DbProvider
        {
            get
            {
                return dbProvider;
            }
        }

        public static bmSessionProvider SessionProvider
        {
            get
            {
                return sProvider;
            }
        }
        public static SpinStorage DraftSpinStorage
        {
            get
            {
                return draftSpinStorage;
            }
        }

        public static SpinProducer DraftSpinProducer
        {
            get
            {
                return draftProducer;
            }
        }

        public static SpinConsumer DraftSpinConsumer
        {
            get
            {
                return draftConsumer;
            }
        }

        public static SpinStorage DoneSpinStorage
        {
            get
            {
                return doneSpinStorage;
            }
        }

        public static SpinProducer DoneSpinProducer
        {
            get
            {
                return doneProducer;
            }
        }

        public static SpinConsumer DoneSpinConsumer
        {
            get
            {
                return doneConsumer;
            }
        }
    }
}
