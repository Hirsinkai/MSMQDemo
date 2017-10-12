using Peek.Model;
using System;
using System.Messaging;

namespace Peek
{
    /// <summary>
    /// @ desc:MSMQ演示用例，使用Peek方式接收队列。
    /// @ author:yz
    /// @ date:2017-10-10
    /// </summary>
    class Program
    {
        // 队列路径
        private static string _QueuePath = string.Empty;

        /// <summary>
        /// @ desc:主函数
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("MQPeek!");

            string queuename = Environment.GetCommandLineArgs()[1];

            Console.WriteLine(string.Format("You are using \"{0}\" Queue", queuename));
            _QueuePath = string.Format(@".\private$\{0}", queuename);

            ReceiveMessageByPeek<KeyModel>();
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
        /// @ desc: 采用Peek方式查看消息
        /// @ author:yz
        /// </summary>
        public static void ReceiveMessageByPeek<T>(MessageQueueTransaction tran = null)
        {
            try
            {
                if (VerifyQueue())
                {
                    // 初始化消息队列
                    MessageQueue localQueue = new MessageQueue(_QueuePath);
                    localQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(T) });

                    Message msg = localQueue.Peek();

                    Console.WriteLine(MSMQDemo.Tools.Json.GetJson((T)msg.Body));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
