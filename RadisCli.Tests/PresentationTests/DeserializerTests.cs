using FluentAssertions;
using RadisCli.Presentation;

namespace RadisCli.Tests.PresentationTests;

public class DeserializerTests
{
    [Fact]
    public void Deserializer_GivenBulkStringResp_ReturnsString()
    {
        string actual = Deserializer.Deserialize("$5\r\nhello\r\n");
        actual.Should().Be("hello");
    }

    [Fact]
    public void Deserialize_GivenNullBulkStringResp_ReturnsNilString()
    {
        string actual = Deserializer.Deserialize("$-1\r\n");
        actual.Should().Be("(nil)");
    }

    [Fact]
    public void Deserialize_GivenSimpleStringResp_ReturnsString()
    {
        string actual = Deserializer.Deserialize("+OK\r\n");
        actual.Should().Be("OK");
    }

    [Fact]
    public void Deserialize_GivenNullResp_ReturnsNilString()
    {
        string actual = Deserializer.Deserialize("_\r\n");
        actual.Should().Be("(nil)");
    }

    [Fact]
    public void Deserialize_GivenErrResp_ReturnsErrorMessage()
    {
        string actual = Deserializer.Deserialize("-Error message\r\n");
        actual.Should().Be("(error) Error message");
    }
}
