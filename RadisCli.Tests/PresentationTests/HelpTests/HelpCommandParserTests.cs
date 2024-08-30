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

    [Fact]
    public void HelpCommandParser_GivenHelpSetCommand_ReturnsSetType()
    {
        Command actual = HelpCommandParser.Parse("help set");
        actual.Should().Be(Command.SET);
    }

    [Fact]
    public void HelpCommandParser_GivenHelpDelCommand_ReturnsDelType()
    {
        Command actual = HelpCommandParser.Parse("HELP DEL");
        actual.Should().Be(Command.DEL);
    }

    [Fact]
    public void HelpCommandParser_GivenHelpLPushCommand_ReturnsLPushType()
    {
        Command actual = HelpCommandParser.Parse("help lpush");
        actual.Should().Be(Command.LPUSH);
    }

    [Fact]
    public void HelpCommandParser_GivenHelpLPopCommand_ReturnsLPopType()
    {
        Command actual = HelpCommandParser.Parse("help lpop");
        actual.Should().Be(Command.LPOP);
    }

    [Fact]
    public void HelpCommandParser_GivenHelpRPushCommand_ReturnsRPushType()
    {
        Command actual = HelpCommandParser.Parse("help rpush");
        actual.Should().Be(Command.RPUSH);
    }

    [Fact]
    public void HelpCommandParser_GivenHelpRPopCommand_ReturnsRPopType()
    {
        Command actual = HelpCommandParser.Parse("help rpop");
        actual.Should().Be(Command.RPOP);
    }
}
