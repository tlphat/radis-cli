namespace RadisCli.Presentation;

public class Deserializer
{
    private const char ERROR_PREFIX = '-';
    private const char SIMPLE_STRING_PREFIX = '+';
    private const string NULL = "_";
    private const string NULL_BULK_STRING = "$-1";

    public static string Deserialize(string data)
    {
        StringReader reader = new(data);
        string header = ReadLineOrThrow(reader, new ArgumentException("Null header"));

        if (IsNull(header))
        {
            return Output.Null();
        }

        if (IsError(header))
        {
            return Output.Error(header[1..]);
        }

        if (IsSimpleString(header))
        {
            return Output.String(header[1..]);
        }

        string body = ReadLineOrThrow(reader, new ArgumentException("Null body"));
        reader.Close();

        return Output.String(body);
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

    private static bool IsSimpleString(string header)
    {
        return header.StartsWith(SIMPLE_STRING_PREFIX);
    }
}
