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

        public async Task<IReadOnlyList<FuelPriceDto>> GetDieselPriceAsync()
        {
            var todos = await _httpClient.GetFromJsonAsync<List<TodoResponse>>("todos");

            if (todos is null)
            {
                return [];
            }

            return todos.Take(3).Select(todo =>
                new FuelPriceDto
                {
                    FuelType = todo.Title,
                    PricePerLiter = todo.Id
                }).ToList();
        }
    }
}
