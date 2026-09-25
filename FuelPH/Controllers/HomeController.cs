using FuelPH.Models;
using FuelPH.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FuelPH.Services.IServices;

namespace FuelPH.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFuelPriceService _fuelPriceService;
        private readonly IStationService _stationService;
        private readonly RegionService _regionService;

        public HomeController(IFuelPriceService fuelPriceService, IStationService stationService, RegionService regionService)
        {
            _fuelPriceService = fuelPriceService;
            _stationService = stationService;
            _regionService = regionService;
        }

        public async Task<IActionResult> Index(string? region)
        {
            var regions = _regionService.GetRegions();

            var selectedRegion = regions.FirstOrDefault(x =>
                x.Name.Equals(region, StringComparison.OrdinalIgnoreCase));

            selectedRegion ??= regions.First(x => x.Name == "Metro Manila");

            var stations = await _stationService.GetStationsAsync(selectedRegion);

            ViewBag.Regions = regions;
            ViewBag.SelectedRegion = selectedRegion.Name;

            return View(stations);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
