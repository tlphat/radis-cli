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
            Command.DEL => helpConfig.Del,
            Command.LPUSH => helpConfig.LPush,
            Command.RPUSH => helpConfig.RPush,
            Command.LPOP => helpConfig.LPop,
            Command.RPOP => helpConfig.RPop,
            _ => helpConfig.Global,
        };
    }

    private record HelpConfig
    {
        public string Global = "";
        public string Get = "";
        public string Set = "";
        public string Del = "";
        public string LPush = "";
        public string RPush = "";
        public string LPop = "";
        public string RPop = "";
    }
}
