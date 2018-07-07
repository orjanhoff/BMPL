using BMechanic.bmSessionProvider;
using BMechanic.V4Net;
using System;

namespace BMApp
{
    //Координатор основных сущностей
    class BMHeartBeat
    {
        //SQLite DA провайдер
        private static BMDaGear dbProvider;
        //RunTime кэш
        private static BMUiCache.Cache cache;
        //Провайдер сессий
        private static bmSessionProvider sProvider;

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
            
            //Инициализация V4NET DA-провайдера
            bmVDaProvider.DaProvider.InitDataBase(BMInitGear.Bm_path_odb);

            //Инициализация и наполнение операционного кэша
            cache = new BMUiCache.Cache(dbProvider);
            cache.BuildCache();

            //Инициализация узла интеграции
            BMMSMQGear.getInstance.Init(BMBHGear.MessageHandler);
            BMMSMQGear.getInstance.StartListener();

            //Инициализация провайдера сессий
            sProvider= new bmSessionProvider(bmVDaProvider.DaProvider);
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
    }
}
