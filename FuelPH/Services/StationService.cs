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
            // We'll put the Overpass request here next.
            return [];
        }
    }
}
