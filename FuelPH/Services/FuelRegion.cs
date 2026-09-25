using FuelPH.Models;

namespace FuelPH.Services;

public class RegionService
{
    public IReadOnlyList<FuelRegion> GetRegions()
    {
        return
        [
            new FuelRegion
            {
                Name = "Metro Manila",
                South = 14.60,
                West = 121.00,
                North = 14.65,
                East = 121.05
            },

            new FuelRegion
            {
                Name = "CALABARZON",
                South = 13.80,
                West = 120.70,
                North = 14.30,
                East = 121.60
            },

            new FuelRegion
            {
                Name = "Central Luzon",
                South = 14.80,
                West = 120.30,
                North = 15.50,
                East = 121.50
            }
        ];
    }
}