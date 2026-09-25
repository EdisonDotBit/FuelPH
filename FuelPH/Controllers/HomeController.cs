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


        public HomeController(IFuelPriceService fuelPriceService, IStationService stationService)
        {
            _fuelPriceService = fuelPriceService;
            _stationService = stationService;
        }

        public async Task<IActionResult> Index()
        {

            var metroManila = new FuelRegion
            {
                Name = "Metro Manila",
                South = 14.60,
                West = 121.00,
                North = 14.65,
                East = 121.05
            };

            var stations = await _stationService.GetStationsAsync(metroManila);
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
