using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BMPL
{
    class BMQueueGear
    {
    }

    class RBSPQueueConnection
    {
        private IPAddress ip;
        private int port;

        public RBSPQueueConnection (string ip, string port)
        {
            this.ip = IPAddress.Parse(ip);
            this.port = int.Parse(port);
        }

        public IPAddress Ip { get { return ip; } }
        public int Port { get { return port; } }
    }

    class RBSPQueueManager
    {
        static volatile bool isopen;
        List<RBSPQueue> queues;
        RBSPQueueServer qServer;

        public RBSPQueueManager(RBSPQueueConnection connection)
        {
            //Инициализация хранилища очередей
            queues = new List<RBSPQueue>();
            
            //Заведение очередей
            queues.Add(new RBSPQueue("BM.IN"));
            queues.Add(new RBSPQueue("BM.OUT"));

            //Заведение TCP сервера
            qServer = new RBSPQueueServer(connection, QueueProceed);
        }

        private void QueueProceed(object state)
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            if (!isopen)
            {
                qServer.Start();
                isopen = true;
            }
        }

        public void Close()
        {
            if (isopen)
            {
                qServer.Stop();
                isopen = false;
            }
        }

        private void QueueProceed()
        {
            //ToDO логика обработки сообщений
        }
    }

    class RBSPQueueServer
    {
        TcpListener server = null;
        RBSPQueueConnection connection;
        WaitCallback callback;

        Thread worker;

        public RBSPQueueServer (RBSPQueueConnection Connection, WaitCallback Callback)
        {
            connection = Connection;
            callback = Callback;
        }

        volatile bool istarted = false;
        int MaxThreadsCount;

        public bool Status
        {
            get { return istarted; }
        }

        public void Start()
        {
            try
            {
                MaxThreadsCount = Environment.ProcessorCount * 4;
                ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);
                ThreadPool.SetMinThreads(2, 2);

                server = new TcpListener(connection.Ip, connection.Port);
                server.Start();

                istarted = true;

                worker = new Thread(mqSrvListen);
                worker.IsBackground = true;
                worker.Start();
                //Neutrino.log(typeof(qServer).Name, "mq server is running", log4mq.LEVEL.INFO);
            }
            catch (Exception ex)
            {
                //Neutrino.log(typeof(qServer).Name, ex.Message, log4mq.LEVEL.ERROR);
                //throw new NeutrinoException(ex.Message, ex.InnerException);
            }
        }

        public void Stop()
        {
            if (istarted)
            {
                istarted = false;
                server.Stop();
            }
        }

        private void mqSrvListen()
        {
            try
            {
                while (istarted)
                {
                    ThreadPool.QueueUserWorkItem(callback, server.AcceptTcpClient());
                }
            }
            catch (SocketException ex)
            {
                if (istarted) throw new Exception(ex.Message, ex.InnerException);
            }
        }
     }

    class RBSPQueue:ConcurrentQueue<object>
    {
        string queueName;
        System.Timers.Timer timer;

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            dequeueDeadMessages();
        }

        private void dequeueDeadMessages()
        {
            this.ToList().Clear();
        }

        public RBSPQueue(string name)
        {
            queueName = name;

            //Управление TTL
            timer = new System.Timers.Timer(5000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
        }

    }
}
