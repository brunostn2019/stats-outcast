using Microsoft.AspNetCore.Mvc;
using StatsOutcast.BLL;
using StatsOutcast.Models;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Grafico(string bossName)
        {
            List<LootModel> loots = _bll.BuscarLootsPorBoss(bossName);
            loots = loots.OrderBy(s => s.Quantidade).Take(10).ToList();
         
            return View(loots);
        }
      
    }
}
