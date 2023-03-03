using System.Globalization;
using System.Text.Json;
using events_manager_api.Domain.Structs;

namespace events_manager_api.Infrastructure.Clients.Impl;

public class WeatherstackClient : IWeatherstackClient
{
    private readonly HttpClient _httpClient;

    private readonly string baseParamsUrl;

    public WeatherstackClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        baseParamsUrl = $"?access_key={configuration["Weatherstack:AccessKey"]}&query=";
    }



    public async Task<string?> GetTimeZoneIdByCityName(string cityName)
    {
        var response = await _httpClient.GetAsync(baseParamsUrl + cityName);

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();

        var json = JsonDocument.Parse(content);

        var timezoneId = json.RootElement.GetProperty("location").GetProperty("timezone_id").GetString();

        return timezoneId;
    }

    public async Task<Location?> GetLocationByCityName(string cityName)
    {
        var response = await _httpClient.GetAsync(baseParamsUrl + cityName);

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();

        var json = JsonDocument.Parse(content);

        var latitude = json.RootElement.GetProperty("location").GetProperty("lat").GetString();
        var latitudeAsDouble = double.Parse(latitude!, CultureInfo.InvariantCulture);

        var longitude = json.RootElement.GetProperty("location").GetProperty("lon").GetString();
        var longitudeAsDouble = double.Parse(longitude!, CultureInfo.InvariantCulture);

        return new Location(latitudeAsDouble, longitudeAsDouble);
    }
}