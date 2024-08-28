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

    private class StreamReaderMock : StreamReader
    {
        public StreamReaderMock() : base(Stream.Null)
        {
        }

        public override string ReadToEnd()
        {
            return @"{
                ""Global"": ""global help"",
                ""Get"": ""get help""
            }";
        }
    }
}
