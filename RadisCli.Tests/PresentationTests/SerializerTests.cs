using FluentAssertions;
using RadisCli.Presentation;

namespace RadisCli.Tests.PresentationTests;

public class SerializerTests
{
    [Fact]
    public void Serializer_GivenRequestString_ReturnsResp()
    {
        string actual = Serializer.SerializeRequest("SET x y");
        actual.Should().Be("*3\r\n$3\r\nSET\r\n$1\r\nx\r\n$1\r\ny\r\n");
    }
}
