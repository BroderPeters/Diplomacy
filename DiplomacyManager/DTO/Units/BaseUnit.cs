using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomacyManager.DTO
{
    public abstract class BaseUnit
    {
        public BaseUnit(int strength, int cost, int range, int maxAmount, Player player, Province province)
        {
            Strength = strength;
            Cost = cost;
            Range = range;
            MaxAmount = maxAmount;
            Player = player;
            Province = province;
        }

        public int Strength { get; private set; }
        public int Cost { get; private set; }
        public int Range { get; private set; }
        public int MaxAmount { get; private set; }
        public Player Player { get; private set; }
        public Province Province { get; private set; }

        internal void ChangeProvince(Province newProvince)
        {
            Province = newProvince;
        }
    }
}
