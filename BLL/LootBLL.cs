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
            Listas = CalculaMedias(Listas);
            Listas.LootsMaisRaros = SQLite.BuscarItemEQuantidade();
            Listas.BossesAndTheirLoots = SQLite.BuscarBossesEQuantidade();
            Listas.Players = SQLite.BuscarPlayers();

            return Listas;
        }

        private ListasModel CalculaMedias(ListasModel Listas)
        {
            int resultado;
            var teste = Int32.TryParse((Listas.Loots.Count / (int)(Listas.Loots.First().Data - Listas.Loots.Last().Data).TotalDays).ToString(), out resultado);
            Listas.QuantidadePorDia = resultado;
            Listas.QuantidadePorMes = Listas.QuantidadePorDia * 30;
            Listas.QuantidadePorAno = Listas.QuantidadePorDia * 365;
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
