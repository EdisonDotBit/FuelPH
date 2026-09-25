using FuelPH.Services.IServices;
using FuelPH.API;
using FuelPH.DTOs;
using System.Net.Http.Json;
using FuelPH.Models;


namespace FuelPH.Services
{
    public class StationService : IStationService
    {
        private readonly HttpClient _httpClient;

        public StationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyList<StationDto>> GetStationsAsync(FuelRegion region)
        {
            var query = $"""
            [out:json][timeout:25];
            node["amenity"="fuel"](
                {region.South},
                {region.West},
                {region.North},
                {region.East}
            );
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
