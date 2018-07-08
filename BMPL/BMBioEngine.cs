using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BMApp
{
    //Основная платформа приложения
    class BMBioEngine
    {
        //Статус служебного задания
        public enum bmSpinStatus
        {
            DRAFT = 0,
            DONE = 1
        }

        //Типизация хранилищ
        public enum bmSpinStorageType
        {
            INCOME = 0,
            OUTCOME = 1
        }

        //Базовая сущность служебного задания
        public class Spin
        {
            public string SessionId;
            public string Id;
            public int Priority;
            public int Service;
            public DateTime TimeBegin;
            public DateTime TimeEnd;
            public bmSpinStatus Status;

            public Spin ()
            {
                Id = Guid.NewGuid().ToString();
            }
        }

        //Хранилище служебных заданий
        public class SpinStorage: SortedList<int, Spin>
        {
            private bmSpinStorageType storageType;

            private static readonly object locker = new object();

            public SpinStorage(bmSpinStorageType Type)
            {
                storageType = Type;
            }

            public bmSpinStorageType StorageType
            {
                get { return storageType; }
            }

            public void Enqueue (Spin Task)
            {
                lock (locker)
                {
                    Task.TimeBegin = DateTime.Now;

                    //Тут должно быть персистирование

                    //Расчет позиции
                    int key = Count;

                    //Добавление объекта
                    Add(key++, Task);
                }
            }

            public bool TryDequeue (out Spin Task)
            {

                if (Count > 0 && StorageType.Equals(bmSpinStorageType.INCOME))
                {
                    //Выборка максимального приоритета
                    int maxPriority = this.OrderByDescending(p => p.Value.Priority).FirstOrDefault().Key;
                    //Выбор задачи
                    Task = this[maxPriority];
                    //Удаление задачи из очереди
                    Remove(maxPriority);
                    //Возврат успешного выполнения
                    return true;
                }
                else if (Count > 0 && StorageType.Equals(bmSpinStorageType.OUTCOME))
                {
                    //Реализация принципа FIFO
                    int keyFirst = this.Min(p => p.Key);
                    //Выбор задачи
                    Task = this[keyFirst];
                    //Удаление задачи из очереди
                    Remove(keyFirst);
                    //Возврат успешного выполнения
                    return true;
                }
                else
                {
                    Task = null;
                    return false;
                }
            }
        }

        //Продюсер спинов
        public class SpinProducer
        {
            //Хранилище
            SpinStorage storage;

            //Логгер
            BMLoggingGear logger = new BMLoggingGear(typeof(SpinProducer), BMInitGear.Bm_path_log);

            public SpinProducer(SpinStorage spins)
            {
                storage = spins;
            }

            public void Produce(Spin Task)
            {
                logger.Trace(string.Format("Добавление задачи ID: {0} с приоритетом {1} в очередь {2} сообщений обработчика", Task.Id, Task.Priority, storage.StorageType));
                Task.TimeBegin = DateTime.Now;

                if (storage.StorageType.Equals(bmSpinStorageType.INCOME))
                { Task.Status = bmSpinStatus.DRAFT; }
                else
                { Task.Status = bmSpinStatus.DONE; }

                storage.Enqueue(Task);
                logger.Debug(string.Format("Задача ID: {0} с приоритетом {1} добавлена в очередь {2} сообщений обработчика", Task.Id, Task.Priority, storage.StorageType));
            }
        }

        //Обработчик спинов
        public class SpinConsumer
        {
            //Хранилище
            SpinStorage storage;
            //Поток обработки
            Thread worker;
            //Продюсер Done-спинов
            SpinProducer doneProducer;
            //Флаг контроля за выполнением
            private volatile bool flag;

            //Логгер
            BMLoggingGear logger = new BMLoggingGear(typeof(SpinConsumer), BMInitGear.Bm_path_log);

            public SpinConsumer(SpinStorage spins)
            {
                storage = spins;
            }

            public SpinConsumer(SpinStorage spins, SpinProducer producer)
            {
                storage = spins;
                doneProducer = producer;
            }

            public void BeginConsume()
            {
                //Включение флага
                flag = true;
                
                //Инициализация рабочего потока
                worker = new Thread(ConsumeSpins);
                worker.IsBackground = true;
                worker.Start();
            }

            public void StopConsume()
            {
                //Выключение флага
                flag = false;
            }

            private void ConsumeSpins()
            {
                while (flag)
                {
                    Spin Task;

                    //Прослушка очереди спинов
                    if (storage.TryDequeue(out Task))
                    { 
                        logger.Info(string.Format("Задача ID: {0} с приоритетом {1} взята в обработку", Task.Id, Task.Priority));

                        //ToDo: Добавить обработку спинов
                        Thread.Sleep(5000);

                        Task.TimeEnd = DateTime.Now;

                        logger.Info(string.Format("Задача ID: {0} обработана", Task.Id));

                        //Отправка Done-спина в исходящую очередь
                        if (!doneProducer.Equals(null))
                        {
                            doneProducer.Produce(Task);
                        }
                    }
                }
            }
        }
    }
}
