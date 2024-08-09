namespace RadisCli.Parser;

public struct Arguments(string host, int port)
{
    public string Host { get; set; } = host;
    public int Port { get; set; } = port;
}
