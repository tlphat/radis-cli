using RadisCli.Connection;
using RadisCli.IO;
using RadisCli.Parser;
using RadisCli.Presentation;

namespace RadisCli;

class Program
{
    private const string HELP_CONFIG_PATH = "Config/help-output.json";

    static void Main(string[] args)
    {
        Arguments arguments = ArgumentParser.Parse(args);

        Client client = new(arguments.Host, arguments.Port);
        client.Connect();

        HelpOutput helpOutput = new(HELP_CONFIG_PATH);
        helpOutput.ParseConfig();

        Prompter prompter = new(arguments.Host, arguments.Port);
        Console.Write(prompter.Prompt());
        string? command = Console.ReadLine();
        while (command != null && !"quit".Equals(command.ToLower()))
        {
            command = command.Trim();

            if ("help".Equals(command.ToLower()))
            {
                string output = helpOutput.HelpText();
                Console.WriteLine(output);
            }
            else if (!"".Equals(command))
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
