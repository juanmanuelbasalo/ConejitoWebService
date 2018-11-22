using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using ConejitoWebService.Models;
using Dapper;
using static ConejitoWebService.ConnectionManager.ConnectionHelper;

namespace ConejitoWebService.DAO
{
    public class PlayerDAO : IPlayerDAO
    {
        #region Funciones para manejar el jugador Sincronico
        public ListPlayer GetMyFriendsDb(ListPlayer players)
        {
            ListPlayer dbPlayers = new ListPlayer
            {
                Players = new List<Player>()
            };
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
        #region Funciones para manejar al jugador Async
        public async Task<ListPlayer> GetMyFriendsDbAsync(ListPlayer players)
        {
            ListPlayer dbPlayers = new ListPlayer { Players = new List<Player>()};
            using (IDbConnection connection = GetConnection("KBunnySql"))
            {
                foreach (var player in players.Players)
                {
                    var result = await connection.QueryAsync<Player>("KBunnyGame_Players_GetMyFriends", new { player.FacebookId },
                        commandType: CommandType.StoredProcedure);
                    dbPlayers.Players.Add(result.FirstOrDefault());
                }
            }
            return dbPlayers;
        }
        public async Task<int> GetMyScoreAsync(string facebookId)
        {
            int score = default(int);
            using (IDbConnection connection = GetConnection("KBunnySql"))
            {
                var result = await connection.QueryAsync<int>("KBunnyGame_Players_GetMyScore", new { facebookId },
                    commandType: CommandType.StoredProcedure);
                score = result.FirstOrDefault();
                return score;
            }
        }
        public async Task<Player> GetPlayerAsync(string facebookId)
        {
            using (IDbConnection connection = GetConnection("KBunnySql"))
            {
                var player = await connection.QueryAsync<Player>("KBunnyGame_Players_GetMyFriends", new { FacebookId = facebookId },
                        commandType: CommandType.StoredProcedure);
                return player.FirstOrDefault();
            }
        }
        public async Task<bool> InsertPlayerAsync(Player player)
        {
            bool success = default(bool);
            using (IDbConnection connection = GetConnection("KBunnySql"))
            {
                var result = await connection.ExecuteAsync("KBunnyGame_Players_InsertPlayer @Name, @Score, @FacebookId", player);
                success = (result >= 1);
            }
            return success;
        }
        public async Task<bool> UpdatePlayerScoreAsync(Player player, int score)
        {
            bool success = default(bool);
            using (IDbConnection connection = GetConnection("KBunnySql"))
            {
                var result = await connection.ExecuteAsync("KBunnyGame_Players_UpdateScore", new { player.Id, score }, 
                    commandType: CommandType.StoredProcedure);
                success = (result >= 1);
            }
            return success;
        }
        #endregion
    }
}