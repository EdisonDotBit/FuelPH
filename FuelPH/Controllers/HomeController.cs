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

        public HomeController(IFuelPriceService fuelPriceService)
        {
            _fuelPriceService = fuelPriceService;
        }

        public async Task<IActionResult> Index()
        {
            var price = await _fuelPriceService.GetDieselPriceAsync();
            return View(price);
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
