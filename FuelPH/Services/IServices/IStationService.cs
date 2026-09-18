using FuelPH.DTOs;

namespace FuelPH.Services.IServices
{
    public interface IStationService
    {
        Task<IReadOnlyList<StationDto>> GetStationsAsync();
    }
}
