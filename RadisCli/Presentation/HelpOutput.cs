using Newtonsoft.Json;

namespace RadisCli.Presentation;

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

    private record HelpConfig
    {
        public string Global;

        public HelpConfig()
        {
            this.Global = "";
        }
    }
}
