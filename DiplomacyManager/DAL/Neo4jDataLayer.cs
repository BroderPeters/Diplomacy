using DiplomacyManager.DTO;
using DiplomacyManager.Helper;
using Neo4jClient;
using Neo4jClient.Cypher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiplomacyManager.DAL
{
    class Neo4jDataLayer
    {
        public int CreateNode(Neo4jObject newNode)
        {
            var graphClient = new GraphClient(Globals.Neo4jUri, Globals.Neo4jUsername, Globals.Neo4jPassword);
            graphClient.Connect();

            var createStatement = string.Format("({0}:{1}", newNode.Name.ToLower(), newNode.GetType().Name);
            var returnStatement = string.Format("id({0})", newNode.Name.ToLower());

            return graphClient.Cypher
                .Create(createStatement + " {newNode})")
                .WithParam("newNode", newNode)
                .Return(() => Return.As<int>(returnStatement))
                .Results.First();
        }

        public void CreateRelationship(Neo4jObject nodeFrom, string relationship, Neo4jObject nodeTo)
        {
            var graphClient = new GraphClient(Globals.Neo4jUri, Globals.Neo4jUsername, Globals.Neo4jPassword);
            graphClient.Connect();

            var matchFromStatement = string.Format("({0}:{1})", nodeFrom.Name.ToLower(), nodeFrom.GetType().Name);
            var matchToStatement = string.Format("({0}:{1})", nodeTo.Name.ToLower(), nodeTo.GetType().Name);
            var whereFromStatement = string.Format("ID({0}) = {1}", nodeFrom.Name.ToLower(), nodeFrom.Id);
            var whereToStatement = string.Format("ID({0}) = {1}", nodeTo.Name.ToLower(), nodeTo.Id);
            var relationshipStatement = string.Format("({0})-[:{1}]->({2})", nodeFrom.Name.ToLower(), relationship, nodeTo.Name.ToLower());

            graphClient.Cypher
                .Match(matchFromStatement, matchToStatement)
                .Where(whereFromStatement)
                .AndWhere(whereToStatement)
                .Create(relationshipStatement)
                .ExecuteWithoutResults();
        }

        public void DeleteNode(Neo4jObject node)
        {
            var graphClient = new GraphClient(Globals.Neo4jUri, Globals.Neo4jUsername, Globals.Neo4jPassword);
            graphClient.Connect();

            var matchStatement = string.Format("({0}:{1})", node.Name.ToLower(), node.GetType().Name);
            var whereStatement = string.Format("ID({0}) = {1}", node.Name.ToLower(), node.Id);

            graphClient.Cypher
                .Match(matchStatement)
                .Where(whereStatement)
                .Delete(node.Name.ToLower())
                .ExecuteWithoutResults();
        }

        public void DeleteNodeWithRelationship(Neo4jObject node)
        {
            var graphClient = new GraphClient(Globals.Neo4jUri, Globals.Neo4jUsername, Globals.Neo4jPassword);
            graphClient.Connect();

            var matchStatement = string.Format("({0}:{1})", node.Name.ToLower(), node.GetType().Name);
            var whereStatement = string.Format("ID({0}) = {1}", node.Name.ToLower(), node.Id);

            graphClient.Cypher
                .Match(matchStatement)
                .Where(whereStatement)
                .DetachDelete(node.Name.ToLower())
                .ExecuteWithoutResults();
        }
    }
}
