using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace Communication
{
    public partial class MainForm : Form
    {
        private bool server_func_sign = false;       
        private bool client_func_sign = false;
        private bool udp_func_sign = false;

        public MyTcpServer TcpServer;
        public MyTcpClient TcpClient;
        public MyUdpServer UdpServer;

        public MainForm()
        {
            InitializeComponent();

            //获得本机ip地址，并添加到comboBox_IPNum 的 item中
            string name = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);
            foreach (IPAddress ipa in ipadrlist)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                {
                    comboBox_IPNum.Items.Add(ipa.ToString());
                }                  
            }
            //选择默认属性值
            comboBox_select_func.SelectedIndex = 1;
            comboBox_IPNum.SelectedIndex = 1;
        }

        //连接按钮事件
        private void Button_connect_Click(object sender, EventArgs e)
        {
            string server_type = comboBox_select_func.Text.ToString();//获得当前功能

            switch (server_type)//根据当前功能选择
            {
                case "TCP客户端":
                    if (client_func_sign == false)
                    {
                        client_func_sign = true;
                        Button_connect_pushed();
                        start_TcpClient();
                    }
                    else
                    {
                        client_func_sign = false;
                        Button_connect_recover();
                        stop_TcpClient();
                    }

                    break;

                case "TCP服务端":
                    if (server_func_sign == false)//要求开启服务器
                    {
                        server_func_sign = true;
                        Button_connect_pushed();
                        start_TcpServer();
                    }
                    else
                    {
                        server_func_sign = false;
                        Button_connect_recover();
                        stop_TcpServer();
                    }
                    break;

                case "UDP服务":
                    if (udp_func_sign == false)
                    {
                        udp_func_sign = true;
                        Button_connect_pushed();
                        start_UdpClient();
                    }
                    else
                    {
                        udp_func_sign = false;
                        Button_connect_recover();
                        stop_UdpClient();
                    }

                    break;

                default:
                    MessageBox.Show("选择服务类型未知，请从新选择", "错误提示", MessageBoxButtons.OKCancel);
                    Button_connect_recover();
                    server_func_sign = false;
                    break;
            }
        }
        //发送按钮事件
        private void Button_send_Click(object sender, EventArgs e)
        {
            try
            {
                string server_type = comboBox_select_func.Text.ToString();//获得当前功能
                string strSend = textBox_send.Text.ToString();//获得要发送的数据
                if (strSend == null)
                {
                    MessageBox.Show("发送不能为空", "错误提示", MessageBoxButtons.OKCancel);
                    return;
                }

                switch (server_type)//根据当前功能选择
                {
                    case "TCP客户端":
                        TcpClient.SendData(strSend);
                        break;

                    case "TCP服务端":
                        TcpServer.SendData(strSend);
                        break;

                    case "UDP服务":
                        UdpServer.SendData(strSend);
                        server_func_sign = false;
                        break;

                    default:
                        MessageBox.Show("选择服务类型未知，请从新选择", "错误提示", MessageBoxButtons.OKCancel);
                        Button_connect_recover();
                        server_func_sign = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //tcp服务器相关操作
        public void start_TcpServer()
        {
            textBox_receive.AppendText("TCP服务器开启" + "\r\n");

            try
            {
                //获得界面上的参数
                string ipNum = comboBox_IPNum.Text.ToString();
                int portNum = Convert.ToInt32(comboBox_PortNum.Text.ToString());

                //判断参数是否为非法，非法则抛出异常
                if (ipNum == null && portNum <= 0)
                {
                    throw new Exception();
                }

                //创建一个tcp_server实例，
                TcpServer = new MyTcpServer(ipNum,portNum);
                TcpServer.updataRevMsg += this.ShowMsg;

                //开始执行相关功能
                TcpServer.StartThreadTcpServer();   
            }
            catch (Exception e)
            {
                MessageBox.Show("TCP参数错误，请检查输入内容", "错误提示", MessageBoxButtons.OKCancel);
                Button_connect_recover();
                Console.WriteLine(e);
            }
        }
        public void stop_TcpServer()
        {
            try
            {
                //关闭线程
                TcpServer.StopThreadTcpServer();
                textBox_receive.AppendText("TCP服务器已关闭\r\n");
            }
            catch (Exception e)
            {
                //MessageBox.Show("TCP参数错误，请检查输入内容", "错误提示", MessageBoxButtons.OKCancel);
                Button_connect_recover();
                Console.WriteLine(e);
            }
        }

        //tcp客户端相关操作
        public void start_TcpClient()
        {
            textBox_receive.AppendText("TCP客户端已开启" + "\r\n");

            try
            {
                //获得界面上的参数
                string ipNum = comboBox_IPNum.Text.ToString();
                int portNum = Convert.ToInt32(comboBox_PortNum.Text.ToString());

                //判断参数是否为非法，非法则抛出异常
                if (ipNum == null && portNum <= 0)
                {
                    throw new Exception();
                }
                //创建一个tcp_server实例，
                TcpClient = new MyTcpClient(ipNum,portNum);
                TcpClient.updataRevMsg += this.ShowMsg;

                //开始执行相关功能
                TcpClient.StartThreadTcpClient();
            }
            catch (Exception e)
            {
                MessageBox.Show("TCP参数错误，请检查输入内容", "错误提示", MessageBoxButtons.OKCancel);
                Button_connect_recover();
                Console.WriteLine(e);
            }
        }
        private void stop_TcpClient()
        {
            try
            {
                //关闭线程
                if (TcpClient != null )
                {
                    TcpClient.StopThreadTcpClient();
                }               
                textBox_receive.AppendText("TCP客户端已关闭\r\n");
            }
            catch (Exception e)
            {
                Button_connect_recover();
                Console.WriteLine(e);
            }
        }

        //UDP相关操作
        public void start_UdpClient()
        {
            textBox_receive.AppendText("UDP已开启" + "\r\n");

            try
            {
                //获得界面上的参数
                string ipNum = comboBox_IPNum.Text.ToString();
                int portNum = Convert.ToInt32(comboBox_PortNum.Text.ToString());

                //判断参数是否为非法，非法则抛出异常
                if (ipNum == null && portNum <= 0)
                {
                    throw new Exception();
                }
                //创建一个tcp_server实例，
                UdpServer = new MyUdpServer(ipNum, portNum);
                UdpServer.updataRevMsg += this.ShowMsg;

                //开始执行相关功能
               UdpServer.StartThreadUdp();
            }
            catch (Exception e)
            {
                MessageBox.Show("T参数错误，请检查输入内容", "错误提示", MessageBoxButtons.OKCancel);
                Button_connect_recover();
                Console.WriteLine(e);
            }
        }
        private void stop_UdpClient()
        {
            try
            {
                //关闭线程
                if (UdpServer != null)
                {
                    UdpServer.StopThreadUdp();
                }
                textBox_receive.AppendText("UDP服务已关闭\r\n");
            }
            catch (Exception e)
            {
                Button_connect_recover();
                Console.WriteLine(e);
            }
        }

        //更新接收信息功能
        private void ShowMsg(object str, EventArgs e)
        {
            //在文本框中追加内容
            this.Invoke(new Action(() =>
            {
                textBox_receive.AppendText((string)str + "\r\n");
            }));
        }
        
        //按钮状态显示功能
        private void Button_connect_recover()
        {
            button_connect.BackColor = Color.YellowGreen;
            button_connect.Text = "连接";
            button_send.Enabled = false;
            comboBox_select_func.Enabled = true;
        }
        private void Button_connect_pushed()
        {
            button_connect.BackColor = Color.Yellow;
            button_connect.Text = "断开";
            button_connect.Refresh();
            button_send.Enabled = true;
            comboBox_select_func.Enabled = false;
        }

        private void Button_MessageClear_Click(object sender, EventArgs e)
        {
            textBox_receive.Text = "";
        }

        private void Button_MessageSave_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName =DateTime.Now.ToLongTimeString().ToString().Replace(":","0") + ".txt";
                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);//创建写入文件
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(textBox_receive.Text.ToString());
                    sw.Close();
                }
                fs.Close();
                ShowMsg("保存成功!  ", null);
            }
            catch (Exception)
            {
                ShowMsg("保存失败，请重试",null);
            }

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("help.txt", Encoding.GetEncoding("gb2312")))
                {
                    while (!sr.EndOfStream)
                    {
                        string strReadLine = sr.ReadLine(); //读取每行数据
                        Console.WriteLine(strReadLine); //屏幕打印每行数据
                        ShowMsg(strReadLine, null);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMsg("打开帮助失败，请重试", null);
                Console.WriteLine(ex);
            }
        }
    }
}
