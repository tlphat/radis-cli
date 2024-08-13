namespace RadisCli.Presentation;

public class Deserializer
{
    public static string Deserialize(string data)
    {
        StringReader reader = new StringReader(data);
        string header = ReadLineOrThrow(reader, new ArgumentException("Null header"));

        // Parse null and null bulk string
        if ("_".Equals(header) || "$-1".Equals(header))
        {
            return "(nil)";
        }

        // Parse error
        if (header.StartsWith('-'))
        {
            return string.Format("(error) {0}", header[1..]);
        }

        // Parse simple string
        if (header.StartsWith('+'))
        {
            return header[1..];
        }

        string body = ReadLineOrThrow(reader, new ArgumentException("Null body"));
        reader.Close();

        return body;
    }

    private static string ReadLineOrThrow(StringReader reader, Exception exception)
    {
        return reader.ReadLine() ?? throw exception;
    }
}
