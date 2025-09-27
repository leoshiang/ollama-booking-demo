using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OllamaBookingDemo.Models;
using OllamaBookingDemo.Services;

// 引用服務

namespace OllamaBookingDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOllamaService _ollamaService;

        public HomeController(IOllamaService ollamaService)
        {
            _ollamaService = ollamaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProcessQuery(string query)
        {
            BookingIntent result = null;
            if (!string.IsNullOrWhiteSpace(query))
            {
                result = await _ollamaService.GetBookingIntentAsync(query);
            }

            // 將查詢和結果傳回給 View
            ViewBag.Query = query;
            return View("Index", result);
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