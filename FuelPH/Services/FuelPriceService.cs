using FuelPH.DTOs;
using FuelPH.Services.IServices;

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

            var json = await response.Content.ReadAsStringAsync();

            Console.WriteLine(json);

            return new FuelPriceDto
            {
                FuelType = "Diesel",
                PricePerLiter = 57.20m
            };
        }
    }
}
