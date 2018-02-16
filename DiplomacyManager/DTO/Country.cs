using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomacyManager.DTO
{
    public class Country
    {
        public Country(string name, List<Province> provinces, Player player)
        {
            Name = name;
            Provinces = provinces;
            Player = player;
        }

        public string Name { get; private set; }
        public List<Province> Provinces { get; private set; }
        public Player Player { get; private set; }

        internal void ChangePlayer(Player newPlayer)
        {
            Player = newPlayer;
        }
    }
}
