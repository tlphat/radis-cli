using RadisCli.Connection;
using RadisCli.IO;
using RadisCli.Parser;

namespace RadisCli;

class Program
{
    static void Main(string[] args)
    {
        Arguments arguments = ArgumentParser.Parse(args);

        Client client = new(arguments.Host, arguments.Port);
        client.Connect();

        Prompter prompter = new(arguments.Host, arguments.Port);
        Console.Write(prompter.Prompt());
        string? command = Console.ReadLine();
        while (command != null && !"quit".Equals(command.ToLower()))
        {
            if (!"".Equals(command.Trim()))
            {
                string output = client.Send(command);
                Console.WriteLine(output);
            }

            Console.Write(prompter.Prompt());
            command = Console.ReadLine();
        }

        client.Close();
    }
}
