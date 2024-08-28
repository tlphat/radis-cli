using RadisCli.Connection;
using RadisCli.IO;
using RadisCli.Parser;
using RadisCli.Presentation.Help;

namespace RadisCli;

class Program
{
    private const string HELP_CONFIG_PATH = "Config/help-output.json";

    static void Main(string[] args)
    {
        Arguments arguments = ArgumentParser.Parse(args);

        Client client = new(arguments.Host, arguments.Port);
        client.Connect();

        HelpOutput helpOutput = LoadHelpConfig();

        Prompter prompter = new(arguments.Host, arguments.Port);
        Console.Write(prompter.Prompt());
        string? command = Console.ReadLine();
        while (command != null && !"quit".Equals(command.Trim().ToLower()))
        {
            command = command.Trim();

            if (command.ToLower().StartsWith("help"))
            {
                Command commandType = HelpCommandParser.Parse(command);
                // TODO: use hash map to store mapping between command type and output text
                if (commandType == Command.GET)
                {
                    Console.WriteLine(helpOutput.HelpGetText());
                }
                else
                {
                    Console.WriteLine(helpOutput.HelpText());
                }
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

    private static HelpOutput LoadHelpConfig()
    {
        StreamReader reader = new(HELP_CONFIG_PATH);
        HelpOutput helpOutput = new(reader);
        helpOutput.ParseConfig();
        reader.Close();
        return helpOutput;
    }
}
