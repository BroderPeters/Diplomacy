using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomacyManager.DTO
{
    public class Ship : BaseUnit
    {
        public Ship(string name, int strength, int cost, int range, int maxAmount, Player player, Province province) : base(name, strength, cost, range, maxAmount, player, province) { }
    }
}
