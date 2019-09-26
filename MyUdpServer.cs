using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communication
{
    public class MyUdpServer
    {
        public event UpdateEventHander updataRevMsg;//声明事件，更新接收消息，将来在外部挂接

        private UdpClient RecClient;
        private Socket sendSocket;
        private IPAddress ipAdr;
        private IPEndPoint ipEp;
        private IPEndPoint sendIpep;
        private Thread reciveThd;
        private Thread sendThd;

        byte[] readBuff = new byte[1024];

        public MyUdpServer(string IpAdr, int PortNum)
        {
            //获得关键参数，端口号和ip地址
            ipAdr = IPAddress.Parse(IpAdr);
            sendIpep = new IPEndPoint(ipAdr,PortNum);
            ipEp = new IPEndPoint(IPAddress.Any ,PortNum);
        }
        public void StartThreadUdp()
        {
            RecClient = new UdpClient(ipEp);

            reciveThd = new Thread(startUdp);
            reciveThd.IsBackground = true;
            reciveThd.Start();
        }
        public void StopThreadUdp()
        {
            try
            {
                if (RecClient != null)
                    RecClient.Dispose();
                if (sendSocket != null)
                    sendSocket.Dispose();
                if (reciveThd != null)
                    reciveThd.Abort();
                if (sendThd != null)
                    sendThd.Abort();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private void startUdp()
        {
            sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            try
            {
                while (true)
                {
                    // 接收阻塞等待
                    readBuff = RecClient.Receive(ref ipEp);
                    if (readBuff.Length> 0)
                    {
                        string recStr = Encoding.ASCII.GetString(readBuff, 0, readBuff.Length);
                        Console.WriteLine(recStr);
                        updataRevMsg("接收->" + recStr, null);//将接收到的数据显示在窗口
                    }
                    else
                    {
                        Console.WriteLine("连接已经断开");
                        break;
                    }
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
            sendThd = new Thread(new ParameterizedThreadStart(sendDataforThd));
            sendThd.IsBackground = true;
            sendThd.Start(strSend);//给线程传一个参数，这是要发送的数据
        }
        private void sendDataforThd(object strSend)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes((string)strSend + "\r\n");
            
            try
            {
                int count = sendSocket.SendTo(bytes, sendIpep);
                if (count > 0)
                {
                    updataRevMsg("发送->" + (string)strSend, null);//让界面显示发送数据
                }
                else
                {
                    //Console.WriteLine("未发送");
                    updataRevMsg("发送失败" , null);//让界面显示发送数据
                }          
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
