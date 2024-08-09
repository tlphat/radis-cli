using FluentAssertions;
using RadisCli.Connection;

namespace RadisCli.Tests.ConnectionTests;

public class ClientTests
{
    [Fact(Skip = "Only enable when Redis server is running on port 6380")]
    public void Client_GivenPing_ReturnsPong()
    {
        var client = new Client("127.0.0.1", 6380);
        client.Connect();

        string request = "PING";
        string actual = client.Send(request);

        client.Close();

        actual.Should().Be("PONG");
    }
}
