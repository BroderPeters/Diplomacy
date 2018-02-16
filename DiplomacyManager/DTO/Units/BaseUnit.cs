using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomacyManager.DTO
{
    class BaseUnit
    {
        public int Strength { get; set; }
        public int Cost { get; set; }
        public int Range { get; set; }
        public int MaxAmount { get; set; }
        public Player Player { get; set; }
        public Province Province { get; set; }
    }
}
