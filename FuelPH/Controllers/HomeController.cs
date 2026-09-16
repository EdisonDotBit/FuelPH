using FuelPH.DTOs;
using FuelPH.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FuelPH.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var price = new FuelPriceDto
            {
                FuelType = "Diesel",
                PricePerLiter = 2.50m
            };
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
