using FluentAssertions;
using RadisCli.Presentation;

namespace RadisCli.Tests.PresentationTests;

public class DeserializerTests
{
    [Fact]
    public void Deserializer_GivenBulkStringResp_ReturnsString()
    {
        string actual = Deserializer.Deserialize("$5\r\nhello\r\n");
        actual.Should().Be("\"hello\"");
    }

    [Fact]
    public void Deserializer_GivenNullBulkStringResp_ReturnsNilString()
    {
        string actual = Deserializer.Deserialize("$-1\r\n");
        actual.Should().Be("(nil)");
    }

    [Fact]
    public void Deserializer_GivenSimpleStringResp_ReturnsString()
    {
        string actual = Deserializer.Deserialize("+OK\r\n");
        actual.Should().Be("OK");
    }

    [Fact]
    public void Deserializer_GivenNullResp_ReturnsNilString()
    {
        string actual = Deserializer.Deserialize("_\r\n");
        actual.Should().Be("(nil)");
    }

    [Fact]
    public void Deserializer_GivenErrResp_ReturnsErrorMessage()
    {
        string actual = Deserializer.Deserialize("-Error message\r\n");
        actual.Should().Be("(error) Error message");
    }

    [Fact]
    public void Deserializer_GivenIntegerResp_ReturnsInteger()
    {
        string actual = Deserializer.Deserialize(":12\r\n");
        actual.Should().Be("(integer) 12");
    }
}
