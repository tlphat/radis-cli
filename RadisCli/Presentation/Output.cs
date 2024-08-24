

namespace RadisCli.Presentation;

public class Output
{
    public static string Null()
    {
        return "(nil)";
    }

    public static string Error(object errorMessage)
    {
        return string.Format("(error) {0}", errorMessage);
    }

    public static string String(string data)
    {
        return data;
    }

    public static string Integer(string data)
    {
        return string.Format("(integer) {0}", data);
    }

    public static string StringInDoubleQuotes(string data)
    {
        return string.Format("\"{0}\"", data);
    }
}
