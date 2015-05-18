
using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;

public class NetClient 
{
    public string tcpURL = "127.0.0.1";
    public int tcpPort = 10000;
    private TcpClient tcpClient;
    public void Connect()
    {
        tcpClient = new TcpClient(); //创建一个本地连接 端口是10000的
        tcpClient.Connect(tcpURL, tcpPort);
        Console.WriteLine("Connect...");
    }

    public void RecieveData()
    {
        NetworkStream clientStream = tcpClient.GetStream(); //获取stream. 通过stream可以收数据和发数据
        byte[] message = new byte[4096];
        int bytesRead;
        bytesRead = 0;
        bytesRead = clientStream.Read(message, 0, 4096); //收到数据 "hello world!"

        UTF8Encoding encoder = new UTF8Encoding();
        Console.Write(encoder.GetString(message, 0, bytesRead)); //转化数据为utf8字符串并打印出来        
    }

    public void SendData(string data)
    {
        NetworkStream clientStream = tcpClient.GetStream(); //获取stream. 通过stream可以收数据和发数据
        byte[] outStream = Encoding.UTF8.GetBytes(data); //发送一个包给服务器.
        clientStream.Write(outStream, 0, outStream.Length);
        clientStream.Flush();
    }

    public void Disconnect()
    {
        tcpClient.Close(); //关闭连接
    }
}
