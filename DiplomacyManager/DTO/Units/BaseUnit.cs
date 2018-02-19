using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomacyManager.DTO
{
    public abstract class BaseUnit : Neo4jObject
    {
        public BaseUnit(string name, int strength, int cost, int range, int maxAmount, Player player, Province province) : base(name)
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
        [JsonIgnore]
        public Player Player { get; private set; }
        [JsonIgnore]
        public Province Province { get; private set; }

        internal void ChangeProvince(Province newProvince)
        {
            Province = newProvince;
        }
    }
}
