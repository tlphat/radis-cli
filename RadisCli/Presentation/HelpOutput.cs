using System.Text;

namespace RadisCli.Presentation;

public class HelpOutput(string configFilePath)
{
    private readonly string configFilePath = configFilePath;
    private string helpText = "";

    public void ParseConfig()
    {
        StreamReader reader = new(configFilePath);
        StringBuilder stringBuilder = new ();
        string? line = reader.ReadLine();
        while (line != null)
        {
            stringBuilder.AppendLine(line);
            line = reader.ReadLine();
        }
        helpText = stringBuilder.ToString();
    }

    public string HelpText()
    {
        return helpText;
    }
}
