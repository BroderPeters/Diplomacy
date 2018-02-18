using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiplomacyManager.DTO
{
    public class Country
    {
        private string _name;

        public Country(string name, List<Province> provinces, Player player = null)
        {
            Name = name;
            Provinces = provinces;
            Player = player;
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

        public List<Province> Provinces { get; private set; }
        public Player Player { get; private set; }

        internal void ChangePlayer(Player newPlayer)
        {
            Player = newPlayer;
        }

        internal void AddProvinces(List<Province> provinces)
        {
            Provinces.AddRange(provinces);
        }

        internal void RemoveProvinces(List<Province> provinces)
        {
            Provinces = Provinces.Except(provinces).ToList();
        }
    }
}
