using System;
using System.IO;
using System.Net.Sockets;
using System.Text;


public class Program
{
    static void Main()
    {
        socketTcpClient();

    }

  static  void socketTcpClient()
    {
        try
        {
            {///Socket
                {
                    //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
                    //socket.Connect("163.177.151.110", 80);
                    //if (socket.Connected)
                    //{
                    //    Console.WriteLine("Connect Successful!");
                    //}
                    //string sendMsg = "GET / HTTP/1.1\r\nHost: www.baidu.com\r\n";
                    //byte[] sendBytes = Encoding.Default.GetBytes(sendMsg);
                    //socket.Send(sendBytes);

                    //byte[] Receivebuffer = new byte[1024*1024];//卡在这里了
                    //int receiveLen = socket.Receive(Receivebuffer );
                    //Console.WriteLine("ReceiveDataFromServer:{0}", Encoding.UTF8.GetString(Receivebuffer, 0, receiveLen));
                    //Console.WriteLine();

                }
                {

                    Console.WriteLine("Hello");

                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect("www.baidu.com", 80);
                    if (socket.Connected)
                    {
                        Console.WriteLine("Connect Successful-1!");
                    }

                    string sendMsg = "GET / HTTP/1.1\r\n" +
                        "Host:www.baidu.com\r\n" +
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
                        Console.WriteLine("ReceiveDataFromServer:{0}", Encoding.UTF8.GetString(Receivebuffer, 0, receiveLen));
                    }
                    socket.Close();
                    Console.WriteLine();
                }
            }
            {///TcpClient
                {
                    TcpClient client = new TcpClient("163.177.151.110", 80);
                    if (client.Connected)
                    {
                        Console.WriteLine("Connect Successful-2!");
                    }

                    using (NetworkStream sendToRemote = client.GetStream())
                    {
                        string sendMsg = "GET / HTTP/1.1\r\nHost: www.baidu.com\r\n\r\n";
                        byte[] buffer = Encoding.Default.GetBytes(sendMsg);
                        lock (sendToRemote)
                        {

                            sendToRemote.Write(buffer, 0, buffer.Length);
                            Console.WriteLine("Send data:\r\n {0}", Encoding.ASCII.GetString(buffer));
                        }


                        //接收服务器数据
                        int bufferSize = 1024;
                        buffer = new byte[bufferSize];
                        lock (sendToRemote)
                        {
                            var readBytes = sendToRemote.Read(buffer, 0, bufferSize);
                            var data = Encoding.Default.GetString(buffer, 0, readBytes);
                            Console.WriteLine("Receive data:{0}", data);
                        }
                    }

                    client.Close();
                    Console.WriteLine();
                }
                {
                    TcpClient client = new TcpClient("www.baidu.com", 80);
                    if (client.Connected)
                    {
                        Console.WriteLine("Connect Successful-3!");
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
                    }
                    client.Close();
                    Console.WriteLine();
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


