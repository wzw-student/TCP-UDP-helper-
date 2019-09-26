using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Communication
{
    public delegate void UpdateEventHander(object str, EventArgs e);//更新数据处理器

    public class MyTcpServer
    {
        public event UpdateEventHander updataRevMsg;//声明事件，更新接收消息，将来在外部挂接

        public Socket tcpServerSocket;
        private Socket tcpBackSocket;
        private IPAddress ipAdr;
        private IPEndPoint ipEp;
        private Thread tcpServerThd;
        private string str;


        public MyTcpServer(string IpAdr, int PortNum )
        {
            //获得关键参数，端口号和ip地址
            ipAdr = IPAddress.Parse(IpAdr);
            ipEp = new IPEndPoint(ipAdr, PortNum);
        }

        public void StartThreadTcpServer()
        {
            tcpServerThd = new Thread(StartTcpServer);
            tcpServerThd.IsBackground = true;
            tcpServerThd.Start();
        }
        public void StopThreadTcpServer()
        {
            try
            {
                //关闭两个套接字
                tcpServerSocket.Dispose();
                if(tcpBackSocket != null)
                   tcpBackSocket.Dispose();
                if (tcpServerThd != null)
                    tcpServerThd.Abort();

                Console.WriteLine("服务器已关闭");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private void StartTcpServer()
        {
            byte[] readBuff = new byte[1024];//接收缓冲区

            //设置socket参数
            tcpServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定端口号
            tcpServerSocket.Bind(ipEp);
            //开启监听，用函数listen()
            tcpServerSocket.Listen(1000);             
            Console.WriteLine("服务器 start listening");

            while (true)
            {
                try
                {
                    //阻塞等待接收信息
                    tcpBackSocket = tcpServerSocket.Accept();
                    if (this.updataRevMsg != null)
                    {
                        this.updataRevMsg.Invoke("新客户端接入", null);//触发更新事件
                    }

                    Console.WriteLine("服务器 start accepting");

                    while (tcpBackSocket.Connected )
                    {
                        //阻塞等待，将数据放置在接收缓冲区
                        int count = tcpBackSocket.Receive(readBuff);
                        if (count > 0)
                        {
                            str = Encoding.UTF8.GetString(readBuff, 0, count);  //将数据进行转换

                            Console.WriteLine("接收到的数据为：{0}", str);

                            if (this.updataRevMsg != null)
                            {
                                //this.updataRevMsg.Invoke("接收->"+str, null);//触发更新事件  
                                updataRevMsg("接收->"+str, null);//触发更新事件  
                            }                        
                        }
                        //若木有接收到数据，则表示对方关闭了socket，重新开始accept
                        else
                        {
                            tcpBackSocket.Dispose();
                            if (this.updataRevMsg != null)
                            {
                                this.updataRevMsg.Invoke("客户端关闭", null);//触发更新事件
                            }
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    //System.Windows.Forms.MessageBox.Show("start TCP服务失败", "提示", MessageBoxButtons.OKCancel);  
                    Console.WriteLine(e);
                    break;
                }
            }               
        }

        public void SendData(string strSend)
        {
            if (strSend == "")
            {
                updataRevMsg("发送不能为空", null);//让界面显示发送数据
                return;
            }            
            //新建一个线程，用于发送数据
            Thread sendThd = new Thread(new ParameterizedThreadStart(sendDataforThd));
            sendThd.IsBackground = true;
            sendThd.Start(strSend);//给线程传一个参数，这是要发送的数据
        }
        private void sendDataforThd(object strSend)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes((string)strSend + "\r\n");
            int count = 0;
            try
            {
                if(tcpBackSocket != null)
                    count = tcpBackSocket.Send(bytes);
                if (count == 0)
                    throw new Exception("未发送成功");

                updataRevMsg("发送->" + (string)strSend, null);//让界面显示发送数据
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

