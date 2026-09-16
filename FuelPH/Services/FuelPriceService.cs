using FuelPH.DTOs;
using FuelPH.Services.IServices;

namespace FuelPH.Services
{
    public class FuelPriceService : IFuelPriceService
    {
        public FuelPriceDto GetDieselPrice()
        {
            return new FuelPriceDto
            {
                FuelType = "Diesel",
                PricePerLiter = 57.20m
            };
        }
    }
}
