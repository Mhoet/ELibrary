using ELibrary.MVC.Model.DTO.ResponseDTO;
using ELibrary.MVC.Models;
using ELibrary.MVC.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace ELibrary.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBook _book;

        public HomeController(IBook book, ILogger<HomeController> logger)
        {
            _logger = logger;
            _book = book;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                var userData = JsonSerializer.Deserialize<LoginResponseDTO>(user);
                ViewData["Name"] = userData.Name;
                ViewData["Id"] = userData.Id;
                ViewData["Token"] = userData.Token;
            }
            try

            {
                var result = _book.GetAllBooks();
                ViewData["Featured"] = result.Take(6);
                ViewData["Books"] = result.GetRange(9, 12);
                return View();
            }
            catch (Exception)
            {
                return View();
            }
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