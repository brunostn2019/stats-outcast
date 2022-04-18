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
        internal ListasModel BuscarListasLoots()
        {
            ListasModel Listas = new ListasModel();
            Listas.Loots = SQLite.BuscarLoots();
            Listas.LootsMaisRaros = SQLite.BuscarItemEQuantidade();
            Listas.BossesAndTheirLoots = SQLite.BuscarBossesEQuantidade();

            return Listas;
        }

        //private List<LootModel> FiltrarLootsRaros(List<LootModel> loots)
        //{
        //   List<LootModel> LootsMaisRaros = loots.OrderBy(a=>a.)
        //}

        internal List<LootModel> BuscarLootsPorBoss(string nomeBoss)
        {
            return SQLite.BuscarLootsPorBoss(nomeBoss);
        }




    }
}
