using Receive.Model;
using System;
using System.Messaging;
using System.Threading;

namespace Receive
{
    /// <summary>
    /// @ desc:MSMQ演示用例，使用Receive方式接收队列。
    /// @ author:yz
    /// @ date:2017-10-10
    /// </summary>
    class Program
    {
        // 队列路径
        private static string _QueuePath = string.Empty;

        // 消息队列
        private static MessageQueue localQueue;

        /// <summary>
        /// @ desc:主函数
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("MQReceive!");

            string queuename = Environment.GetCommandLineArgs()[1];

            Console.WriteLine(string.Format("You are using \"{0}\" Queue", queuename));

            _QueuePath = string.Format(@".\private$\{0}", queuename);

            ReceiveMessage<KeyModel>();

            Console.ReadKey();
        }

        /// <summary>
        /// @ desc: 验证队列 队列不存在则创建
        /// @ author:yz
        /// </summary>
        private static bool VerifyQueue()
        {
            try
            {
                // 判断队列是否存在 不存在则创建
                if (!MessageQueue.Exists(_QueuePath))
                {
                    Console.WriteLine(string.Format("\"{0}\"队列不存在", _QueuePath));
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// @ desc:接收消息
        /// @ author:yz
        /// </summary>
        private static void ReceiveMessage<T>(MessageQueueTransaction tran = null)
        {
            try
            {
                if (VerifyQueue())
                {
                    localQueue = new MessageQueue(_QueuePath);
                    localQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(MessageReceived<T>);
                    localQueue.BeginReceive();
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// @ desc:继续接收消息
        /// @ author:yz
        /// </summary>
        private static void MessageReceived<T>(object source, ReceiveCompletedEventArgs asyncResult)
        {
            bool isReceivedSucceed = true;

            try
            {
                //连接到队列
                Message m = localQueue.EndReceive(asyncResult.AsyncResult);
                m.Formatter = new XmlMessageFormatter(new Type[] { typeof(T) });

                //显示处理的消息.
                //Console.WriteLine(MSMQDemo.Tools.Json.GetJson((T)m.Body));

                ThreadPool.QueueUserWorkItem(new WaitCallback(InvokeMDAO<T>), m.Body);
            }
            catch (MessageQueueException)
            {
                isReceivedSucceed = false;
            }
            catch (Exception ex)
            {
                isReceivedSucceed = false;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (isReceivedSucceed)
                {
                    localQueue.BeginReceive();
                }
            }
        }

        /// <summary>
        /// @ desc:接收回调
        /// @ author:yz
        /// </summary>
        private static void InvokeMDAO<T>(object state)
        {
            try
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss  :") + MSMQDemo.Tools.Json.GetJson((T)state));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
