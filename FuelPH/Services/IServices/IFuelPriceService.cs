using FuelPH.DTOs;

namespace FuelPH.Services.IServices
{
    public interface IFuelPriceService
    {
        Task<IReadOnlyList<FuelPriceDto>> GetDieselPriceAsync();
    }
}
