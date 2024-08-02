using FluentAssertions;
using RadisCli.Presentation;

namespace RadisCli.Tests.PresentationTests;

public class SerializerTests
{
    [Fact]
    public void Serializer_GivenSimpleString_ReturnsRespString()
    {
        string actual = Serializer.SerializeString("OK");
        actual.Should().Be("+OK\r\n");
    }

    [Fact]
    public void Serializer_GivenBulkString_ReturnsRespString()
    {
        string actual = Serializer.SerializeBulkString("hello");
        actual.Should().Be("$5\r\nhello\r\n");
    }

    [Fact]
    public void Serializer_GivenArray_ReturnsResp()
    {
        string actual = Serializer.SerializeArray(new List<string>{"GET", "x", "y"});
        actual.Should().Be("*3\r\n$3\r\nGET\r\n$1\r\nx\r\n$1\r\ny\r\n");
    }
}
