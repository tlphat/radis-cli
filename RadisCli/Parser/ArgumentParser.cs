namespace RadisCli.Parser;

public class ArgumentParser
{
    public static Arguments Parse(string[] args)
    {
        if (args.Length % 2 != 0)
        {
            throw new ArgumentException("An even number of arguments should be provided");
        }

        if (args.Length > 4)
        {
            throw new ArgumentException("Too many arguments");
        }

        Arguments arguments = new("127.0.0.1", 6379);
        
        for (int i = 0; i < args.Length; i += 2)
        {
            switch (args[i])
            {
                case "-h":
                    arguments.Host = args[i + 1];
                    break;
                case "-p": 
                    arguments.Port = int.Parse(args[i + 1]);
                    break;
                default:
                    throw new ArgumentException("Argument not recognizable", args[i]);
            }
        }

        return arguments;
    }
}
