using FuelPH.DTOs;

namespace FuelPH.Services.IServices
{
    public interface IFuelPriceService
    {
        Task<FuelPriceDto> GetDieselPrice();
    }
}
