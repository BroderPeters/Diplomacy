using DiplomacyManager.DAL;
using DiplomacyManager.DTO;
using DiplomacyManager.Helper;
using System;
using System.Collections.Generic;

namespace DiplomacyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            AppConfigManager.Configure();

            //var country = new Country("England", null);
            //var province = new Province("London", true, false, country);

            //var player = new Player("Broptor", 1000, false, new List<Province>() { province }, new List<Country>() { country });

            //var neo4jDataLayer = new Neo4jDataLayer();
            //player.Id = neo4jDataLayer.CreateNode(player);
            //country.Id = neo4jDataLayer.CreateNode(country);
            //province.Id = neo4jDataLayer.CreateNode(province);

            //neo4jDataLayer.CreateRelationship(province, "BELONGS_TO", country);

            var mapImporter = new MapImporter(AppConfigManager.Configuration["MapImportDirectoryPath"]);
            mapImporter.ImportMapToNeo4j();

            Console.WriteLine("ready");
            Console.ReadLine();
        }
    }
}
