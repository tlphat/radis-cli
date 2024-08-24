namespace RadisCli.Presentation;

public class Deserializer
{
    private const char ERROR_PREFIX = '-';
    private const char INTEGER_PREFIX = ':';
    private const char SIMPLE_STRING_PREFIX = '+';
    private const string NULL = "_";
    private const string NULL_BULK_STRING = "$-1";

    public static string Deserialize(string data)
    {
        StringReader reader = new(data);
        string header = ReadLineOrThrow(reader, new ArgumentException("Null header"));

        Console.WriteLine(header);

        if (IsNull(header))
        {
            return Output.Null();
        }

        if (IsError(header))
        {
            return Output.Error(header[1..]);
        }

        if (IsInteger(header))
        {
            return Output.Integer(header[1..]);
        }

        if (IsSimpleString(header))
        {
            return Output.String(header[1..]);
        }

        string body = ReadLineOrThrow(reader, new ArgumentException("Null body"));
        reader.Close();

        return Output.StringInDoubleQuotes(body);
    }

    private static string ReadLineOrThrow(StringReader reader, Exception exception)
    {
        return reader.ReadLine() ?? throw exception;
    }

    private static bool IsNull(string header)
    {
        return NULL.Equals(header) || NULL_BULK_STRING.Equals(header);
    }

    private static bool IsError(string header)
    {
        return header.StartsWith(ERROR_PREFIX);
    }

    private static bool IsInteger(string header)
    {
        return header.StartsWith(INTEGER_PREFIX);
    }

    private static bool IsSimpleString(string header)
    {
        return header.StartsWith(SIMPLE_STRING_PREFIX);
    }
}
