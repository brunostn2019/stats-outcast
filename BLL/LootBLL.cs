using StatsOutcast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsOutcast.BLL
{
    public class LootBLL
    {
        internal List<LootModel> BuscarLoots()
        {
            return SQLite.BuscarLoots();
        }
          internal List<LootModel> BuscarLootsPorBoss(string nomeBoss)
        {
            return SQLite.BuscarLootsPorBoss(nomeBoss);
        }


    }
}
