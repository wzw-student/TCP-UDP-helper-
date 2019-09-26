using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Communication
{
    public class MyTcpClient
    {
        public event UpdateEventHander updataRevMsg;//声明事件，更新接收消息，将来在外部挂接

        public Socket tcpClientSocket;
        private IPAddress ipAdr;
        private IPEndPoint ipEp;
        private Thread tcpClientThd;

        private byte[] readBuff = new byte[1024];

        public MyTcpClient(string IpAdr, int PortNum )
        {
            //获得关键参数，端口号和ip地址
            ipAdr = IPAddress.Parse(IpAdr);
            ipEp = new IPEndPoint(ipAdr, PortNum);
        }
        public void StartThreadTcpClient()
        {
            tcpClientThd = new Thread(startTcpClient);
            tcpClientThd.IsBackground = true;
            tcpClientThd.Start();
        }
        public void StopThreadTcpClient()
        {
            try
            {
                if (tcpClientSocket != null)
                    tcpClientSocket.Dispose();
                if (tcpClientThd != null)
                    tcpClientThd.Abort();
                Console.WriteLine("客户端已关闭");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        private void startTcpClient()
        {
            try
            { 
                //1.创建套接字
                tcpClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2.连接服务器
                tcpClientSocket.Connect(ipEp);//在此处会阻塞等待
                Console.WriteLine("客户端已开启");
                
                //发送数据,显示已经连接
                string str = "Hello Server,i am user!";
                byte[] bytes = System.Text.Encoding.Default.GetBytes(str);
                tcpClientSocket.Send(bytes);

                while (tcpClientSocket.Connected == true)
                {
                    int count = tcpClientSocket.Receive(readBuff);
                    string RecStr = Encoding.UTF8.GetString(readBuff, 0, count);
                    updataRevMsg("接收->" + RecStr, null);//让界面显示接收数据
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void SendData(string strSend)
        {
            //新建一个线程，用于发送数据
            Thread sendThd = new Thread(new ParameterizedThreadStart(sendDataforThd));
            sendThd.IsBackground = true;
            sendThd.Start(strSend);//给线程传一个参数，这是要发送的数据
        }
        private void sendDataforThd(object strSend)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes((string)strSend +"\r\n");
            try
            {
                int count = tcpClientSocket.Send(bytes);
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
