namespace RadisCli.IO;

public class Prompter(string host, int port)
{
    private readonly string host = host;
    private readonly int port = port;

    public string Prompt()
    {
        return string.Format("{0}:{1}>", host, port);
    }
}
