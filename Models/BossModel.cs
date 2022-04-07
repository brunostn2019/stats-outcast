﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsOutcast.Models
{
    public class BossModel
    {
        public string NomeBoss { get; set; }
        public int QuantidadeLoots { get; set; }
        public List<LootModel> LootsRaros { get; set; }
        public List<LootModel> LootsComuns { get; set; }


    }
}
