using MSMQDemo.Model;
using System;
using System.Diagnostics;
using System.Messaging;
using System.Windows.Forms;

namespace MSMQDemo
{
    /// <summary>
    /// @ desc:MSMQ演示用例，包括队列的连接、验证、创建、删除、消息发送、接受。
    /// @ author:yz
    /// @ date:2017-10-10
    /// </summary>
    public partial class main : Form
    {

        // 操作类型 1：Peek 2：Receive
        public int type = 0;

        // 队列地址
        public string queueputh = string.Empty;

        // 队列名称
        public string queuename = string.Empty;

        /// <summary>
        /// @ desc:主函数
        /// </summary>
        public main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// @ desc:发送
        /// @ author:yz
        /// </summary>
        private void Send_Click(object sender, EventArgs e)
        {
            string queuename = Queue.Text;

            int count = trackBar.Value;

            try
            {
                if (string.IsNullOrEmpty(queuename))
                {
                    MessageBox.Show("请输入队列！");
                    return;
                }

                if (count == 0)
                {
                    MessageBox.Show("请设置发送数量！");
                    return;
                }

                string _QueuePath = string.Format(@".\private$\{0}", queuename);

                if (!MessageQueue.Exists(_QueuePath))
                {
                    if (MessageBox.Show(string.Format("队列\"{0}\"不存在是否创建？", queuename), string.Format("创建队列"), MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                    {
                        // 创建队列
                        MessageQueue.Create(_QueuePath);

                        if (MessageBox.Show(string.Format("队列\"{0}\"成功，是否继续发送数据？", queuename), string.Format("发送数据"), MessageBoxButtons.YesNo, MessageBoxIcon.None) != DialogResult.Yes)
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                // 开始生产数据

                for (int i = 0; i < count; i++)
                {
                    MessageQueue localQueue = new MessageQueue(_QueuePath);

                    System.Messaging.Message msg = new System.Messaging.Message()
                    {
                        Body = new KeyModel() { guid = Guid.NewGuid(), time = DateTime.Now },
                        Formatter = new XmlMessageFormatter(new Type[] { typeof(KeyModel) })
                    };

                    localQueue.Send(msg);
                }

                MessageBox.Show(string.Format("成功发送 {0} 条消息到\"{1}\"队列！", count, queuename));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// @ desc:使用Receive方式获取队列
        /// @ author:yz
        /// </summary>
        private void Receive_Click(object sender, EventArgs e)
        {
            if (verify(2))
            {
                Process.Start(Application.StartupPath + @"\Receive.exe", queuename);
            }
        }

        /// <summary>
        /// @ desc:使用Peek方式查看队列
        /// @ author:yz
        /// </summary>
        private void Peek_Click(object sender, EventArgs e)
        {
            if (verify(1))
            {
                Process.Start(Application.StartupPath + @"\Peek.exe", queuename);
            }
        }

        /// <summary>
        /// @ desc:删除队列
        /// @ author:yz
        /// </summary>
        private void Delete_Click(object sender, EventArgs e)
        {
            if (verify(0))
            {
                if (MessageBox.Show(string.Format("确认删除\"{0}\"队列？", queuename), string.Format("删除队列"), MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                {
                    MessageQueue.Delete(queueputh);

                    MessageBox.Show("删除成功！");
                }
            }
        }

        /// <summary>
        /// @ desc:滑动条选择发送数量
        /// @ author:yz
        /// </summary>
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar.Value.ToString();
        }

        /// <summary>
        /// @ desc:验证数据
        /// @ author:yz
        /// </summary>
        /// <param name="_type">类型</param>
        /// <returns></returns>
        private bool verify(int _type)
        {
            queuename = Queue.Text;

            if (string.IsNullOrEmpty(queuename))
            {
                MessageBox.Show("请输入队列！");
                return false;
            }

            type = _type; queueputh = string.Format(@".\private$\{0}", queuename);

            if (!MessageQueue.Exists(queueputh))
            {
                MessageBox.Show(string.Format("队列\"{0}\"不存在！", queuename));
                return false;
            }

            return true;
        }

    }
}
