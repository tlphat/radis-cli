using Newtonsoft.Json;

namespace RadisCli.Presentation.Help;

public class HelpOutput(StreamReader reader)
{
    private readonly StreamReader reader = reader;
    private HelpConfig helpConfig = new();

    public void ParseConfig()
    {
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

    public string PrintHelpOfCommand(Command command)
    {
        return command switch
        {
            Command.GET => helpConfig.Get,
            Command.SET => helpConfig.Set,
            _ => helpConfig.Global,
        };
    }

    private record HelpConfig
    {
        public string Global = "";
        public string Get = "";
        public string Set = "";
    }
}
