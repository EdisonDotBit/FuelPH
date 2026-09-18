using FuelPH.DTOs;
using FuelPH.Services.IServices;
using FuelPH.API;
using System.Text.Json;
using System.Net.Http.Json;

namespace FuelPH.Services
{
    public class FuelPriceService : IFuelPriceService
    {

        private readonly HttpClient _httpClient;

        public FuelPriceService (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }   

        public async Task<FuelPriceDto> GetDieselPrice()
        {
            // Example API call - replace with actual implementation
            HttpResponseMessage response = await _httpClient.GetAsync("todos/1");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadFromJsonAsync<TodoResponse>();

            return new FuelPriceDto
            {
                FuelType = content?.Title ?? "Diesel",
                PricePerLiter = content?.Id ?? 0 
            };


        }
    }
}
