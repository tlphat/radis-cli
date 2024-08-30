namespace RadisCli.Presentation.Help;

public class HelpCommandParser
{
    private static readonly Dictionary<string, Command> commandMapping = new() 
    {
        { "get", Command.GET },
        { "set", Command.SET },
        { "del", Command.DEL },
        { "lpush", Command.LPUSH },
        { "lpop", Command.LPOP },
        { "rpush", Command.RPUSH },
        { "rpop", Command.RPOP },
    };

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

        if (!commandMapping.TryGetValue(tokens[1].ToLower(), out Command commandType))
        {
            throw new ArgumentException("help does not support the given command", tokens[1]);
        }
        return commandType;
    }
}
