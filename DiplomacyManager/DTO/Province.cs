using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomacyManager.DTO
{
    class Province
    {
        public string Name { get; set; }
        public bool IsCapital { get; set; }
        public bool IsWonderOfTheWorld { get; set; }
        public Country Country { get; set; }
        public Player Player { get; set; }
        public List<BaseUnit> Units { get; set; }
    }
}
