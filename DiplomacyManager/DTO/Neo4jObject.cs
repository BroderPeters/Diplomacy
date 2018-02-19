using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomacyManager.DTO
{
    public abstract class Neo4jObject
    {
        private string _name;
        private int _id;

        public Neo4jObject(string name)
        {
            Name = name;
        }

        [JsonIgnore]
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    _name = value;
                }
            }
        }

        [JsonIgnore]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id == 0 && value != 0)
                {
                    _id = value;
                }
            }
        }
    }
}
