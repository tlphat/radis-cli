using FluentAssertions;
using RadisCli.Presentation.Help;

namespace RadisCli.Tests.PresentationTests.HelpTests;

public class HelpOutputTests
{
    [Fact]
    public void HelpOutput_GivenGlobalCommand_ReturnsGlobalHelpText()
    {
        StreamReader reader = new StreamReaderMock();
        HelpOutput helpOutput = new(reader);
        helpOutput.ParseConfig();
        reader.Close();

        string actual = helpOutput.PrintHelpOfCommand(Command.GLOBAL);

        actual.Should().Be("global help");
    }

    [Fact]
    public void HelpOutput_GivenGetCommand_ReturnsGetHelpText()
    {
        StreamReader reader = new StreamReaderMock();
        HelpOutput helpOutput = new(reader);
        helpOutput.ParseConfig();
        reader.Close();

        string actual = helpOutput.PrintHelpOfCommand(Command.GET);

        actual.Should().Be("get help");
    }

    [Fact]
    public void HelpOutput_GivenSetCommand_ReturnsSetHelpText()
    {
        StreamReader reader = new StreamReaderMock();
        HelpOutput helpOutput = new(reader);
        helpOutput.ParseConfig();
        reader.Close();

        string actual = helpOutput.PrintHelpOfCommand(Command.SET);

        actual.Should().Be("set help");
    }

    [Fact]
    public void HelpOutput_GivenDelCommand_ReturnsDelHelpText()
    {
        StreamReader reader = new StreamReaderMock();
        HelpOutput helpOutput = new(reader);
        helpOutput.ParseConfig();
        reader.Close();

        string actual = helpOutput.PrintHelpOfCommand(Command.DEL);

        actual.Should().Be("set del");
    }

    [Fact]
    public void HelpOutput_GivenLPushCommand_ReturnsLPushHelpText()
    {
        StreamReader reader = new StreamReaderMock();
        HelpOutput helpOutput = new(reader);
        helpOutput.ParseConfig();
        reader.Close();

        string actual = helpOutput.PrintHelpOfCommand(Command.LPUSH);

        actual.Should().Be("set lpush");
    }

    [Fact]
    public void HelpOutput_GivenLPopCommand_ReturnsLPopHelpText()
    {
        StreamReader reader = new StreamReaderMock();
        HelpOutput helpOutput = new(reader);
        helpOutput.ParseConfig();
        reader.Close();

        string actual = helpOutput.PrintHelpOfCommand(Command.LPOP);

        actual.Should().Be("set lpop");
    }

    [Fact]
    public void HelpOutput_GivenRPushCommand_ReturnsRPushHelpText()
    {
        StreamReader reader = new StreamReaderMock();
        HelpOutput helpOutput = new(reader);
        helpOutput.ParseConfig();
        reader.Close();

        string actual = helpOutput.PrintHelpOfCommand(Command.RPUSH);

        actual.Should().Be("set rpush");
    }

    [Fact]
    public void HelpOutput_GivenRPopCommand_ReturnsRPopHelpText()
    {
        StreamReader reader = new StreamReaderMock();
        HelpOutput helpOutput = new(reader);
        helpOutput.ParseConfig();
        reader.Close();

        string actual = helpOutput.PrintHelpOfCommand(Command.RPOP);

        actual.Should().Be("set rpop");
    }

    private class StreamReaderMock : StreamReader
    {
        public StreamReaderMock() : base(Stream.Null)
        {
        }

        public override string ReadToEnd()
        {
            return @"{
                ""Global"": ""global help"",
                ""Get"": ""get help"",
                ""Set"": ""set help"",
                ""Del"": ""set del"",
                ""LPush"": ""set lpush"",
                ""LPop"": ""set lpop"",
                ""RPush"": ""set rpush"",
                ""RPop"": ""set rpop"",
            }";
        }
    }
}
