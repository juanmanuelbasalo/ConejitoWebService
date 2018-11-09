using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ConejitoWebService.Models;
using Dapper;
using static ConejitoWebService.ConnectionManager.ConnectionHelper;

namespace ConejitoWebService.DAO
{
    public class PlayerDAO : IPlayerDAO
    {
        #region Funciones para manejar el jugador
        public List<Player> GetMyFriendsDb(List<Player> players)
        {
            throw new NotImplementedException();
        }
        public int GetMyScore(string facebookId)
        {
            int score = default(int);
            using (IDbConnection connection = GetConnection("KBunnySql"))
            {
                score = connection.Query<int>("KBunnyGame_Players_GetMyScore @FacebookId", new { FacebookId = facebookId}).FirstOrDefault();
            }
            return score;
        }
        public bool InsertPlayer(Player player)
        {
            bool success = default(bool);
            using (IDbConnection connection = GetConnection("KBunnySql"))
            {
                var result = connection.Execute("KBunnyGame_Players_InsertPlayer @Name, @Score, @FacebookId", player);
                success = (result >= 1);
            }
            return success;
        }
        public bool UpdatePlayerScore(Player player, int score)
        {
            bool success = default(bool);
            using (IDbConnection connection = GetConnection("KBunnySql"))
            {
                var result = connection.Execute("KBunnyGame_Players_UpdateScore @Id, @Score", new { player.Id, score});
                success = (result >= 1);
            }
            return success;
        }
        #endregion
    }
}