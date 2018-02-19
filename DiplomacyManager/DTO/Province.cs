using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiplomacyManager.DTO
{
    public class Province : Neo4jObject
    {
        private string _name;

        public Province(string name, bool isCapital, bool isWonderOfTheWorld, Country country, Player player = null, List<BaseUnit> units = null) : base(name)
        {
            Name = name;
            IsCapital = isCapital;
            IsWonderOfTheWorld = isWonderOfTheWorld;
            Country = country;
            Player = player;
            Units = units;
        }

        public string Name
        {
            get
            {
                return _name;
            }

            private set
            {
                if (value == null || value == "")
                    throw new ArgumentNullException();
                else
                    _name = value;
            }
        }

        public bool IsCapital { get; private set; }
        public bool IsWonderOfTheWorld { get; private set; }
        [JsonIgnore]
        public Country Country { get; private set; }
        [JsonIgnore]
        public Player Player { get; private set; }
        [JsonIgnore]
        public List<BaseUnit> Units { get; private set; }

        internal void ChangeCountry(Country newCountry)
        {
            Country = newCountry;
        }

        internal void ChangePlayer(Player newPlayer)
        {
            Player = newPlayer;
        }

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
