namespace RadisCli.Presentation.Help;

public class HelpCommandParser
{
    public static Command Parse(string command)
    {
        string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (tokens.Length > 2)
        {
            throw new ArgumentException("Invalid number of arguments for help command");
        }

        if (tokens.Length == 1)
        {
            return Command.GLOBAL;
        }

        if ("get".Equals(tokens[1].ToLower()))
        {
            return Command.GET;
        }

        throw new ArgumentException("help does not support the given command", tokens[1]);
    }
}
