using RadisCli.Connection;
using RadisCli.IO;
using RadisCli.Parser;
using RadisCli.Presentation.Help;

namespace RadisCli;

class Program
{
    private const string HELP_CONFIG_PATH = "Config/help-output.json";
    private const string QUIT_COMMAND = "quit";
    private const string HELP_COMMAND = "help";

    static void Main(string[] args)
    {
        Arguments arguments = ArgumentParser.Parse(args);

        Client client = new(arguments.Host, arguments.Port);
        client.Connect();

        HelpOutput helpOutput = LoadHelpConfig();

        Prompter prompter = new(arguments.Host, arguments.Port);
        Console.Write(prompter.Prompt());
        string? command = Console.ReadLine();
        while (command != null && !QUIT_COMMAND.Equals(command.Trim().ToLower()))
        {
            command = command.Trim();

            if (command.ToLower().StartsWith(HELP_COMMAND))
            {
                Command commandType = HelpCommandParser.Parse(command);
                string output = helpOutput.PrintHelpOfCommand(commandType);
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

    private static HelpOutput LoadHelpConfig()
    {
        StreamReader reader = new(HELP_CONFIG_PATH);
        HelpOutput helpOutput = new(reader);
        helpOutput.ParseConfig();
        reader.Close();
        return helpOutput;
    }
}
