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
    public class PlayerController : Controller
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly LootBLL _bll;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
            _bll = new LootBLL();
        }

        public IActionResult AtualizarPlayer()
        {

            Parallel.Invoke(() =>            SQLite.ConfigurarPlayers());

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {

            ListasModel Listas = _bll.BuscarListasLoots();
            return View(Listas);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
