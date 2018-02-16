using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomacyManager.DTO
{
    public class Infantry : BaseUnit
    {
        public Infantry(int strength, int cost, int range, int maxAmount, Player player, Province province) : base(strength, cost, range, maxAmount, player, province) { }
    }
}
