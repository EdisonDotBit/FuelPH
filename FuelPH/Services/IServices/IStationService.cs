using FuelPH.DTOs;
using FuelPH.Models;

namespace FuelPH.Services.IServices
{
    public interface IStationService
    {
        Task<IReadOnlyList<StationDto>> GetStationsAsync(FuelRegion region);
    }
}
