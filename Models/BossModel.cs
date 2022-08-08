using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsOutcast.Models
{
    public class BossModel
    {
        public string NomeBoss { get; set; }
        public int QuantidadeLoots { get; set; } 
        public double Hp { get; set; } 
        public double Xp { get; set; } 
        public int Magic { get; set; } 
        public int Lvl { get; set; } 
        public string XpPorHP { get { return (Xp / Hp).ToString("#.##"); } } 


    }
}
