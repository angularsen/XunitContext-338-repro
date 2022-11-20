using System.Net.Http.Json;
using Api;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace XunitContext_338_repro;

public class UnitTest1 : MyTestBase, IClassFixture<WebApplicationFactory<Program>>
{
    private readonly TestServer _server;

    public UnitTest1(WebApplicationFactory<Program> factory, ITestOutputHelper output) : base(output)
    {
        _server = factory.Server;
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public async Task Test1(int x)
    {
        await Task.Delay(Random.Shared.Next(500, 1500)).ConfigureAwait(false);
        var response = await _server.CreateClient().GetAsync("WeatherForecast");
        var responseBody = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();
        responseBody.Should().NotBeEmpty().And.AllSatisfy(w => w.Summary.Should().BeOneOf(new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        }));
        // throw new InvalidOperationException("My exception");
    }
}