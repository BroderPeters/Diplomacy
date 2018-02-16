using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomacyManager.DTO
{
    class Country
    {
        public string Name { get; set; }
        public List<Province> Provinces { get; set; }
        public Player Player { get; set; }
    }
}
