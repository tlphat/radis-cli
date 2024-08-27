using Newtonsoft.Json;

namespace RadisCli.Presentation.Help;

public class HelpOutput(string configFilePath)
{
    private readonly string configFilePath = configFilePath;
    private HelpConfig helpConfig = new();

    public void ParseConfig()
    {
        StreamReader reader = new(configFilePath);
        string json = reader.ReadToEnd();
        helpConfig = JsonConvert.DeserializeObject<HelpConfig>(json) ?? new();
    }

    public string HelpText()
    {
        return helpConfig.Global;
    }

    public string HelpGetText()
    {
        return helpConfig.Get;
    }

    private record HelpConfig
    {
        public string Global;
        public string Get;

        public HelpConfig()
        {
            Global = "";
            Get = "";
        }
    }
}
