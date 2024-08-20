using System.Text;

namespace RadisCli.Presentation;

public class Serializer
{
    private const char ARRAY_PREFIX = '*';
    private const char BULK_STRING_PREFIX = '$';

    public static string SerializeRequest(string request)
    {
        string[] arrayData = Array.FindAll(request.Split(' '), segment => segment.Trim().Length > 0);
        return SerializeArray([.. arrayData]);
    }

    private static string SerializeArray(List<string> data)
    {
        StringBuilder stringBuilder = new(string.Format("{0}{1}\r\n", ARRAY_PREFIX, data.Count));
        foreach (string bulk in data)
        {
            stringBuilder.Append(SerializeBulkString(bulk));
        }
        return stringBuilder.ToString();
    }

    private static string SerializeBulkString(string data)
    {
        int byteCount = Encoding.ASCII.GetByteCount(data);
        return string.Format("{0}{1}\r\n{2}\r\n", BULK_STRING_PREFIX, byteCount, data);
    }
}
