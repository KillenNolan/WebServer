using System;
using System.Net.Sockets;
using System.Text;


public class Program {
	static void  Main(){
		   // Console.WriteLine("Hello");

            try
           using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows;





namespace WpfApplication2
{


    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            socketTcpClient();
            //InitializeComponent();
        }

        void socketTcpServer()
        { }

        void socketTcpClient()
        {
            try
            {
                {
                    //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //if (socket.Connected)
                    //{
                    //    Console.WriteLine("Connect Successful!");
                    //}

                    //socket.Connect("163.177.151.110", 443);
                    //string sendMsg = "GET / HTTP/1.1\r\nHost: www.baidu.com\r\n";

                    //socket.Receive()



                    TcpClient client = new TcpClient("163.177.151.110", 443);
                    if (client.Connected)
                    {
                        Console.WriteLine("Connect Successful!");
                    }

                    using (NetworkStream sendToRemote = client.GetStream())
                    {
                        string sendMsg = "GET / HTTP/1.1\r\nHost: www.baidu.com\r\n";
                        byte[] buffer = Encoding.Unicode.GetBytes(sendMsg);
                        lock (sendToRemote)
                        {
                            for (int i = 0; i <= buffer.Length / 100; i++)
                            {
                                sendToRemote.Write(buffer, 0, buffer.Length);
                                Console.WriteLine("Send data:\r\n {0}", Encoding.ASCII.GetString(buffer));
                            }

                        }



                        //接收服务器数据
                        int bufferSize = 1024;
                        buffer = new byte[bufferSize];
                        lock (sendToRemote)
                        {
                            var readBytes = sendToRemote.Read(buffer, 0, bufferSize);
                            var data = Encoding.Unicode.GetString(buffer, 0, readBytes);
                            Console.WriteLine("Receive data:{0}", data);
                        }
                    }

                    client.Close();

                }
                {
                    Console.WriteLine("Hello");

                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect("www.baidu.com", 443);
                    if (socket.Connected)
                    {
                        Console.WriteLine("Connect Successful!");
                    }

                    string sendMsg = "GET / HTTP/1.1\r\n" +
                        "Host:www.baidu.com\r\n" +
                        //"Content-Length: 1107\r\n" +
                        //"Content-Type: text/plain;charset=UTF-8\r\n" +
                        //"Connection: keep-alive\r\n" +
                        //"user-agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.45 Safari/537.36\r\n" +
                        "\r\n";

                    using (var myNetStream = new NetworkStream(socket))
                    {

                        byte[] sendBytes = Encoding.Default.GetBytes(sendMsg);
                        //socket.Send(sendBytes);
                        Console.WriteLine("SendToServer:{0}", sendMsg);
                        myNetStream.Write(sendBytes, 0, sendBytes.Length);
                        myNetStream.Flush();

                        byte[] Receivebuffer = new byte[1024];
                        int receiveLen = myNetStream.Read(Receivebuffer, 0, 1024);
                        Console.WriteLine("ReceiveDataFromServer:{0}", Encoding.Unicode.GetString(Receivebuffer, 0, receiveLen));
                    }
                    socket.Close();
                }

                {
                    TcpClient client = new TcpClient("www.baidu.com", 443);
                    if (client.Connected)
                    {
                        Console.WriteLine("Connect Successful!");
                    }

                    using (NetworkStream sendToRemote = client.GetStream())
                    {
                        string sendMsg = "GET / HTTP/1.1\r\n" +
                    "Host: www.baidu.com\r\n" +  
                    "\r\n";

                        StreamWriter writeStream = new StreamWriter(sendToRemote);
                        writeStream.Write(sendMsg);
                        writeStream.Flush(); 

                        String text = "";
                        byte[] buffer = new byte[1024];
                        int recLen = 0;
                        while ((recLen = sendToRemote.Read(buffer, 0, 1024)) > 0)
                        {
                            text += Encoding.UTF8.GetString(buffer);
                        }
                        Console.WriteLine(text);
                        //byte[] buffer = Encoding.Unicode.GetBytes(sendMsg);
                        //lock (sendToRemote)
                        //{
                        //    for (int i = 0; i <= buffer.Length / 100; i++)
                        //    {
                        //        sendToRemote.Write(buffer, 0, buffer.Length);
                        //        Console.WriteLine("Send data:\r\n {0}", Encoding.ASCII.GetString(buffer));
                        //    }

                        //}



                        ////接收服务器数据
                        //int bufferSize = 1024;
                        //buffer = new byte[bufferSize];
                        //lock (sendToRemote)
                        //{
                        //    var readBytes = sendToRemote.Read(buffer, 0, bufferSize);
                        //    var data = Encoding.Unicode.GetString(buffer, 0, readBytes);
                        //    Console.WriteLine("Receive data:{0}", data);
                        //}
                    }

                    client.Close();



                }


            }
            catch (Exception ex)
            {
            }
            finally
            {

            }

        }
    }
}

            catch (Exception ex)
            {
            }
            finally
            {

            }
	}
}


 
