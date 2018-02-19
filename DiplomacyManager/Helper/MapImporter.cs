using DiplomacyManager.DAL;
using DiplomacyManager.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DiplomacyManager.Helper
{
    class MapImporter
    {
        private string _directoryPath;
        private string _countriesPath;
        private string _provincesPath;
        private string _relationshipsPath;

        private Neo4jDataLayer neo4JDataLayer;

        private List<Country> _countries;
        private List<Province> _provinces;

        private const string COUNTRIES = "Countries";
        private const string PROVINCES = "Provinces";
        private const string RELATIONSHIPS = "Relationships";
        private const string CSV = ".csv";
        private const string BELONGSTO = "BELONGS_TO";
        private const string ISNEIGHBOUR = "IS_NEIGHBOUR";

        public MapImporter(string directoryPath)
        {
            DirectoryPath = directoryPath;
            CheckImportFiles();
            neo4JDataLayer = new Neo4jDataLayer();
        }

        private string DirectoryPath
        {
            get
            {
                return _directoryPath;
            }

            set
            {
                if (value == null || value == "") throw new ArgumentNullException();
                else if (!Directory.Exists(value)) throw new DirectoryNotFoundException(value);
                else
                {
                    if (value[value.Length - 1] == '\\') _directoryPath = value;
                    else _directoryPath = value + "\\";

                    _countriesPath = _directoryPath + COUNTRIES + CSV;
                    _provincesPath = _directoryPath + PROVINCES + CSV;
                    _relationshipsPath = _directoryPath + RELATIONSHIPS + CSV;
                }
            }
        }

        private void CheckImportFiles()
        {
            if (!File.Exists(_countriesPath)) throw new FileNotFoundException(_countriesPath);
            if (!File.Exists(_provincesPath)) throw new FileNotFoundException(_provincesPath);
            if (!File.Exists(_relationshipsPath)) throw new FileNotFoundException(_relationshipsPath);
        }

        public void ImportMapToNeo4j()
        {
            ImportCountries();
            ImportProvinces();
            ImportRelationships();
        }

        public void ImportCountries()
        {
            using (var streamReader = new StreamReader(_countriesPath, Encoding.UTF8))
            {
                _countries = new List<Country>();

                streamReader.ReadLine();
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    var values = line.Split(';');

                    var country = new Country(values[0], null);

                    country.Id = neo4JDataLayer.CreateNode(country);
                    _countries.Add(country);
                }
            }
        }

        public void ImportProvinces()
        {
            using (var streamReader = new StreamReader(_provincesPath, Encoding.UTF8))
            {
                _provinces = new List<Province>();

                streamReader.ReadLine();
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    var values = line.Split(';');

                    var province = new Province(values[0], Convert.ToBoolean(Convert.ToInt32(values[1])), Convert.ToBoolean(Convert.ToInt32(values[2])), null);

                    province.Id = neo4JDataLayer.CreateNode(province);
                    _provinces.Add(province);
                }
            }
        }

        public void ImportRelationships()
        {
            using (var streamReader = new StreamReader(_relationshipsPath, Encoding.UTF8))
            {
                streamReader.ReadLine();
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    var values = line.Split(';');

                    var relationship = values[2];
                    if (relationship == BELONGSTO)
                    {
                        neo4JDataLayer.CreateRelationship(_provinces.Find((p) => p.Name == values[0]), relationship, _countries.Find((c) => c.Name == values[1]));
                    }
                    else if (relationship == ISNEIGHBOUR)
                    {
                        neo4JDataLayer.CreateRelationship(_provinces.Find((p) => p.Name == values[0]), relationship, _provinces.Find((p) => p.Name == values[1]));
                    }
                    else
                    {
                        throw new ArgumentException(relationship);
                    }
                }
            }
        }
    }
}
