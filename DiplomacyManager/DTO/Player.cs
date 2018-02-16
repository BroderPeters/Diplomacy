using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomacyManager.DTO
{
    class Player
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public bool IsGameMaster { get; set; }
        public List<Province> Provinces { get; set; }
        public List<Country> Countries { get; set; }
        public List<BaseUnit> Units { get; set; }
    }
}
