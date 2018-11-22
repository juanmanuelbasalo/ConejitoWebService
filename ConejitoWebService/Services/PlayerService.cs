using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ConejitoWebService.DAO;
using ConejitoWebService.Models;

namespace ConejitoWebService.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerDAO playerDao;
        public PlayerService()
        {
            playerDao = new PlayerDAO();
        }

        #region Funciones del servicio para modificar el jugador
        public int GetMyScore(string facebookId)
        {
            int score = playerDao.GetMyScore(facebookId);
            return score;
        }
        public bool InsertPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.FacebookId) || string.IsNullOrEmpty(player.Name))
            {
                return false;
            }
            else
            {
                return playerDao.InsertPlayer(player);
            }
        }
        public bool UpdatePlayerScore(Player player, int score)
        {
            if(player.Score > score)
            {
                return false;
            }
            return playerDao.UpdatePlayerScore(player, score);
        }
        public ListPlayer GetMyFriends(ListPlayer players)
        {
            return playerDao.GetMyFriendsDb(players);
        }
        public Player GetPlayer(string facebookId)
        {
            return playerDao.GetPlayer(facebookId);
        }
        #endregion
        #region Funciones del servicio Asincrono
        public async Task<int> GetMyScoreAsync(string facebookId)
        {
            int score = await playerDao.GetMyScoreAsync(facebookId);
            return score;
        }
        public async Task<ListPlayer> GetMyFriendsDbAsync(ListPlayer players)
        {
            return await playerDao.GetMyFriendsDbAsync(players);
        }
        public async Task<Player> GetPlayerAsync(string facebookId)
        {
            return await playerDao.GetPlayerAsync(facebookId);
        }
        public async Task<bool> InsertPlayerAsync(Player player)
        {
            if (string.IsNullOrEmpty(player.FacebookId) || string.IsNullOrEmpty(player.Name))
            {
                return false;
            }
            else
            {
                return await playerDao.InsertPlayerAsync(player);
            }
        }
        public async Task<bool> UpdatePlayerScoreAsync(Player player, int score)
        {
            if (player.Score > score)
            {
                return false;
            }
            return await playerDao.UpdatePlayerScoreAsync(player, score);
        }
        #endregion
    }
}