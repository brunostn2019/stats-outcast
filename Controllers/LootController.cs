using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatsOutcast.BLL;
using StatsOutcast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsOutcast.Controllers
{
    public class LootController : Controller
    {
        private readonly LootBLL _bll;
        public LootController()
        {
            _bll = new LootBLL();
        }
        public IActionResult Boss(string bossName)
        {
            List<LootModel> loots = _bll.BuscarLootsPorBoss(bossName);
            return View(loots);
        }
    }
}
