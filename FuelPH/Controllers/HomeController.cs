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
            var stations = await _stationService.GetStationsAsync();
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
