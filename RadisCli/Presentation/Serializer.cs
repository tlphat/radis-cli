using System.Text;

namespace RadisCli.Presentation;

public class Serializer
{
    public static string SerializeString(string data)
    {
        return string.Format("+{0}\r\n", data);
    }

    public static string SerializeBulkString(string data)
    {
        int byteCount = ASCIIEncoding.ASCII.GetByteCount(data);
        return string.Format("${0}\r\n{1}\r\n", byteCount, data);
    }

    public static string SerializeArray(List<string> data)
    {
        StringBuilder stringBuilder = new StringBuilder(string.Format("*{0}\r\n", data.Count));
        foreach (string bulk in data)
        {
            stringBuilder.Append(SerializeBulkString(bulk));
        }
        return stringBuilder.ToString();
    }
}
