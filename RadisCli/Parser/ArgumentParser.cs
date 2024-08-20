namespace RadisCli.Parser;

public class ArgumentParser
{
    private const int ARGS_LENGTH_THRESHOLD = 4;

    public static Arguments Parse(string[] args)
    {
        if (ArgsLengthOdd(args))
        {
            throw new ArgumentException("An even number of arguments should be provided");
        }

        if (args.Length > ARGS_LENGTH_THRESHOLD)
        {
            throw new ArgumentException("Too many arguments");
        }

        Arguments arguments = new();
        for (int i = 0; i < args.Length; i += 2)
        {
            string argType = args[i];
            string argValue = args[i + 1];

            switch (argType)
            {
                case "-h":
                    arguments.Host = argValue;
                    break;
                case "-p":
                    arguments.Port = int.Parse(argValue);
                    break;
                default:
                    throw new ArgumentException("Argument not recognizable", argType);
            }
        }

        return arguments;
    }

    private static bool ArgsLengthOdd(string[] args)
    {
        return args.Length % 2 != 0;
    }
}
