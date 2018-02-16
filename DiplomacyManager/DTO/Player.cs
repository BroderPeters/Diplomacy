using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiplomacyManager.DTO
{
    public class Player
    {
        public Player(string name, int gold, bool isGameMaster, List<Province> provinces, List<Country> countries, List<BaseUnit> units)
        {
            Name = name;
            Gold = gold;
            IsGameMaster = isGameMaster;
            Provinces = provinces;
            Countries = countries;
            Units = units;
        }

        public string Name { get; private set; }
        public int Gold { get; private set; }
        public bool IsGameMaster { get; private set; }
        public List<Province> Provinces { get; private set; }
        public List<Country> Countries { get; private set; }
        public List<BaseUnit> Units { get; private set; }

        internal void ChangeGold(int value)
        {
            Gold += value;
        }

        internal void AddProvinces(List<Province> provinces)
        {
            Provinces.AddRange(provinces);
        }

        internal void RemoveProvinces(List<Province> provinces)
        {
            Provinces = Provinces.Except(provinces).ToList();
        }

        internal void AddCountries(List<Country> countries)
        {
            Countries.AddRange(countries);
            foreach (var country in countries)
            {
                Provinces.AddRange(country.Provinces);
            }
        }

        internal void RemoveCountries(List<Country> countries)
        {
            Countries = Countries.Except(countries).ToList();
            foreach (var country in countries)
            {
                Provinces = Provinces.Except(country.Provinces).ToList();
            }
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
