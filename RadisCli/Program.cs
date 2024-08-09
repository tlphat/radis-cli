using RadisCli.Connection;
using RadisCli.Parser;

namespace RadisCli;

class Program
{
    static void Main(string[] args)
    {
        Arguments arguments = ArgumentParser.Parse(args);

        Client client = new(arguments.Host, arguments.Port);
        client.Connect();

        string command = "PING";
        string output = client.Send(command);
        Console.WriteLine(output);

        client.Close();
    }
}
