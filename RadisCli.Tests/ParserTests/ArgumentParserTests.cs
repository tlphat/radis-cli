using FluentAssertions;
using RadisCli.Parser;

namespace RadisCli.Tests.ParserTests;

public class ArgumentParserTests
{
    [Fact]
    public void ArgumentParser_GivenHostAndPort_ReturnsArguments()
    {
        string[] args = ["-h", "127.0.0.1", "-p", "6380"];

        Arguments parsedArgument = ArgumentParser.Parse(args);

        parsedArgument.Host.Should().Be("127.0.0.1");
        parsedArgument.Port.Should().Be(6380);
    }

    [Fact]
    public void ArgumentParser_GivenPort_ReturnsArgumentsWithLocalHost()
    {
        string[] args = ["-p", "6380"];

        Arguments parsedArgument = ArgumentParser.Parse(args);

        parsedArgument.Host.Should().Be("127.0.0.1");
        parsedArgument.Port.Should().Be(6380);
    }

    [Fact]
    public void ArgumentParser_GivenHost_ReturnsArgumentsWithPort6379()
    {
        string[] args = ["-h", "127.0.0.1"];

        Arguments parsedArgument = ArgumentParser.Parse(args);

        parsedArgument.Host.Should().Be("127.0.0.1");
        parsedArgument.Port.Should().Be(6379);
    }

    [Fact]
    public void ArgumentParser_GivenUnrecognizedArguments_ThrowsArgumentException()
    {
        string[] args = ["-k", "127.0.0.1"];
        Action act = () => ArgumentParser.Parse(args);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ArgumentParser_GivenTooManyArguments_ThrowsArgumentException()
    {
        string[] args = ["-a", "something", "-b", "something", "-c", "something"];
        Action act = () => ArgumentParser.Parse(args);
        act.Should().Throw<ArgumentException>();
    }
}
