using RadisCli.Connection;

namespace RadisCli;

class Program
{
    static void Main(string[] args)
    {
        Client client = new Client("127.0.0.1", 6380);
        client.Connect();

        string command = "PING";
        string output = client.Send(command);
        Console.WriteLine(output);

        client.Close();
    }
}
