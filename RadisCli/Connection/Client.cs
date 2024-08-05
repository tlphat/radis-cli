using System.Net;
using System.Net.Sockets;
using System.Text;
using RadisCli.Presentation;

namespace RadisCli.Connection;

public class Client
{
    private readonly IPEndPoint iPEndPoint;
    private readonly Socket socket;

    public Client(string ip, int port)
    {
        iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
        socket = new Socket(iPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    }

    public void Connect()
    {
        socket.Connect(iPEndPoint);
    }

    public void Close()
    {
        socket.Shutdown(SocketShutdown.Both);
    }

    public string Send(string command)
    {
        string respData = Serializer.SerializeArray([command]);

        socket.Send(Encoding.UTF8.GetBytes(respData));

        byte[] buffer = new byte[1024];
        int cntBytes = socket.Receive(buffer);
        string response = Encoding.UTF8.GetString(buffer, 0, cntBytes);

        return Deserializer.Deserialize(response);
    }
}
