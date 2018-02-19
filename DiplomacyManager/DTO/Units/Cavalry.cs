using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomacyManager.DTO
{
    public class Cavalry : BaseUnit
    {
        public Cavalry(string name, int strength, int cost, int range, int maxAmount, Player player, Province province) : base(name, strength, cost, range, maxAmount, player, province) { }
    }
}
