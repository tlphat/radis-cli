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

        string request = "GET a";
        string actual = client.Send(request);

        client.Close();

        actual.Should().Be("(nil)");
    }

    [Fact]
    public void Client_GivenGetNonExistingKeyWithRedundantSpace_ReturnsNull()
    {
        Client client = new("127.0.0.1", 6379);
        client.Connect();

        string request = "GET  a";
        string actual = client.Send(request);

        client.Close();

        actual.Should().Be("(nil)");
    }

    [Fact]
    public void Client_GivenSetKey_ReturnsOk()
    {
        Client client = new("127.0.0.1", 6379);
        client.Connect();

        string request = "SET b 11";
        string actual = client.Send(request);

        // Clean up
        client.Send("DEL b");
        client.Close();

        actual.Should().Be("OK");
    }

    [Fact]
    public void Client_GivenDeleteKey_ReturnsNumberOfDeletedElements()
    {
        Client client = new("127.0.0.1", 6379);
        client.Connect();
        client.Send("SET c 11");

        string request = "DEL c";
        string actual = client.Send(request);

        client.Close();

        actual.Should().Be("(integer) 1");
    }

    [Fact]
    public void Client_GivenLeftPushKey_ReturnsNumberOfElementsInList()
    {
        Client client = new("127.0.0.1", 6379);
        client.Connect();
        client.Send("LPUSH d 18");

        string request = "LPUSH d 18";
        string actual = client.Send(request);
        
        // Clean up
        client.Send("DEL d");
        client.Close();

        actual.Should().Be("(integer) 2");
    }
}
