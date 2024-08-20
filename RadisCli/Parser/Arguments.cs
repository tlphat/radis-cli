namespace RadisCli.Parser;

public struct Arguments
{
    public string Host { get; set; }
    public int Port { get; set; }

    public Arguments()
    {
        Host = "127.0.0.1";
        Port = 6379;
    }
}
