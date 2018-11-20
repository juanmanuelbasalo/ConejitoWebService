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
        public ListPlayer GetMyFriendsDb(ListPlayer players)
        {
            ListPlayer dbPlayers = new ListPlayer();
            dbPlayers.Players = new List<Player>();
            using (IDbConnection connection = GetConnection("KBunnySql"))
            {
                foreach(var player in players.Players)
                {
                    var result = connection.Query<Player>("KBunnyGame_Players_GetMyFriends", new { player.FacebookId }, 
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
                    dbPlayers.Players.Add(result);
                }
            }
            return dbPlayers;
        }
        public int GetMyScore(string facebookId)
        {
            int score = default(int);
            using (IDbConnection connection = GetConnection("KBunnySql"))
            {
                score = connection.Query<int>("KBunnyGame_Players_GetMyScore", new { FacebookId = facebookId }, 
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return score;
        }
        public Player GetPlayer(string facebookId)
        {
            using (IDbConnection connection = GetConnection("KBunnySql"))
            {
                var player = connection.Query<Player>("KBunnyGame_Players_GetMyFriends", new { FacebookId = facebookId },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
                return player;
            }
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
                var result = connection.Execute("KBunnyGame_Players_UpdateScore", new { player.Id, score }, commandType: CommandType.StoredProcedure);
                success = (result >= 1);
            }
            return success;
        }
        #endregion
    }
}