using FluentAssertions;
using RadisCli.Connection;
namespace RadisCli.Tests.ConnectionTests;

public class ClientTests
{
    [Fact]
    public void Client_GivenPing_ReturnsPong()
    {
        var client = new Client("127.0.0.1", 6379);
        client.Connect();

        string request = "PING";
        string actual = client.Send(request);

        client.Close();

        actual.Should().Be("PONG");
    }

    [Fact]
    public void Client_GivenGetNonExistingKey_ReturnsNull()
    {
        Client client = new("127.0.0.1", 6379);
        client.Connect();

        string request = "GET x";
        string actual = client.Send(request);

        client.Close();

        actual.Should().Be("(nil)");
    }

    [Fact]
    public void Client_GivenGetNonExistingKeyWithRedundantSpace_ReturnsNull()
    {
        Client client = new("127.0.0.1", 6379);
        client.Connect();

        string request = "GET  x";
        string actual = client.Send(request);

        client.Close();

        actual.Should().Be("(nil)");
    }

    [Fact]
    public void Client_GivenSetKey_ReturnsOk()
    {
        Client client = new("127.0.0.1", 6379);
        client.Connect();

        string request = "SET y 11";
        string actual = client.Send(request);

        client.Close();

        actual.Should().Be("OK");
    }
}
