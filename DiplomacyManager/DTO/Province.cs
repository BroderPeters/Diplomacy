using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiplomacyManager.DTO
{
    public class Province
    {
        public Province(string name, bool isCapital, bool isWonderOfTheWorld, Country country, Player player, List<BaseUnit> units)
        {
            Name = name;
            IsCapital = isCapital;
            IsWonderOfTheWorld = isWonderOfTheWorld;
            Country = country;
            Player = player;
            Units = units;
        }

        public string Name { get; private set; }
        public bool IsCapital { get; private set; }
        public bool IsWonderOfTheWorld { get; private set; }
        public Country Country { get; private set; }
        public Player Player { get; private set; }
        public List<BaseUnit> Units { get; private set; }

        internal void AddUnits(List<BaseUnit> units)
        {
            Units.AddRange(units);
        }

        internal void RemoveUnits(List<BaseUnit> units)
        {
            Units = Units.Except(units).ToList();
        }
    }
}
