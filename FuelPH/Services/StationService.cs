using FuelPH.Services.IServices;
using FuelPH.API;
using FuelPH.DTOs;
using System.Net.Http.Json;


namespace FuelPH.Services
{
    public class StationService : IStationService
    {
        private readonly HttpClient _httpClient;

        public StationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyList<StationDto>> GetStationsAsync()
        {
            var query = """
            [out:json][timeout:25];
            node["amenity"="fuel"](14.55,121.00,14.65,121.10);
            out;
            """;

            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["data"] = query
            });

            var response = await _httpClient.PostAsync("api/interpreter", content);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<OverpassResponse>();

            if (result is null)
            {
                return [];
            }

            return result.Elements
                .Select(element => new StationDto
                {
                    Name = element.Tags?.GetValueOrDefault("name") ?? "Unnamed station",
                    Latitude = element.Lat,
                    Longitude = element.Lon
                })
                .ToList();
        }
    }
}
