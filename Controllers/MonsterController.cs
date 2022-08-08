using Microsoft.AspNetCore.Mvc;
using StatsOutcast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsOutcast.Controllers
{
    public class MonsterController : Controller
    {
        BLL.LootBLL _bll = new BLL.LootBLL();
        public IActionResult Index()
        {
            List<BossModel> Lista = _bll.BuscarMonsterStats();
            return View(Lista);
        }
    }
}
