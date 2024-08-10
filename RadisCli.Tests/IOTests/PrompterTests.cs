using FluentAssertions;
using RadisCli.IO;

namespace RadisCli.Tests.IOTests;

public class PrompterTests
{
    [Fact]
    public void Prompter_CallsPrompt_ShouldReturnHostsAndPort()
    {
        Prompter prompter = new("127.0.0.1", 6379);
        string actual = prompter.Prompt();
        actual.Should().Be("127.0.0.1:6379>");
    }
}
