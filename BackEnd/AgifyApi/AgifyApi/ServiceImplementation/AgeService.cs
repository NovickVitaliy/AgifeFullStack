using System.Text.Json;
using AgifyApi.ServiceContracts;

namespace AgifyApi.ServiceImplementation;

public class AgeService : IAgeService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AgeService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<Dictionary<string, object>?> GetAge(string? name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException();
        
        using (var client = _httpClientFactory.CreateClient())
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri($"https://api.agify.io?name={name}"),
                Method = HttpMethod.Get
            };
            var resposen = await client.SendAsync(request);
            var json = await resposen.Content.ReadAsStringAsync();
            Dictionary<string, object>? data = JsonSerializer.Deserialize<Dictionary<string, object>?>(json);
            return data;
        }
    }
}