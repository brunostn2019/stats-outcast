using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StatsOutcast.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StatsOutcast.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SQLite sql;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            sql = new SQLite();
        }

        public IActionResult Index()
        {
            ModelDados resultado = new ModelDados();
              resultado.dado=  SQLite.ReadData();
            return View(resultado);
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
