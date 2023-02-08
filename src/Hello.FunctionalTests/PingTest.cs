namespace Hello.FunctionalTests;

public class PingTest
{
    [Fact]
    public async Task Ping()
    {
        var url = Environment.GetEnvironmentVariable("WEBAPP_URL");
        Assert.NotNull(url);
        Assert.StartsWith("http", url);
        var client = new HttpClient();
        var response = await client.GetAsync(url);
        Assert.True(response.IsSuccessStatusCode);
        var content = await response.Content.ReadAsStringAsync();
        Assert.NotNull(content);
        Assert.Contains("Hello Phoenix", content);
    }
}