using FluentAssertions;
using RadisCli.Presentation.Help;

namespace RadisCli.Tests.PresentationTests.HelpTests;

public class HelpCommandParserTests
{
    [Fact]
    public void HelpCommandParser_GivenHelpCommand_ReturnsGlobalType()
    {
        Command actual = HelpCommandParser.Parse("help");
        actual.Should().Be(Command.GLOBAL);
    }

    [Fact]
    public void HelpCommandParser_GivenHelpCommandWithExtraSpaces_ReturnsGlobalType()
    {
        Command actual = HelpCommandParser.Parse("  help  ");
        actual.Should().Be(Command.GLOBAL);
    }

    [Fact]
    public void HelpCommandParser_GivenHelpGetCommand_ReturnsGetType()
    {
        Command actual = HelpCommandParser.Parse("help get");
        actual.Should().Be(Command.GET);
    }

    [Fact]
    public void HelpCommandParser_GivenHelpGetCommandWithExtraSpaces_ReturnsGlobalType()
    {
        Command actual = HelpCommandParser.Parse("  help    get   ");
        actual.Should().Be(Command.GET);
    }
}
