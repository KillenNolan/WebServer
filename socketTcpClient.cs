using System;
using System.Net.Sockets;
using System.Text;


public class Program {
	static void  Main(){
		   // Console.WriteLine("Hello");

            try
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
                        for (int i = 0; i <= buffer.Length/100; i++)
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
                        Console.WriteLine("Receive data:{0}",data  );
                    }
                }

                client.Close(); 

            }
            catch (Exception ex)
            {
            }
            finally
            {

            }
	}
}


 