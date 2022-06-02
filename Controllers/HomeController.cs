using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StatsOutcast.BLL;
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
        private readonly LootBLL _bll;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _bll = new LootBLL();
        }

        public IActionResult Index()
        {

           ListasModel Listas = _bll.BuscarListasLoots();
            return View(Listas);
        }
        public IActionResult AtualizarLoot()
        {
            SQLite.ConfigurarLoot();
           return RedirectToAction("Index");
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
