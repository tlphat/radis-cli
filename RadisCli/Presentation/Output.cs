

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
}
