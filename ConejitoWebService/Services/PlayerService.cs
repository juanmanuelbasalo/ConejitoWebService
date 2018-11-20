using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConejitoWebService.DAO;
using ConejitoWebService.Models;

namespace ConejitoWebService.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerDAO playerDao;
        public PlayerService(IPlayerDAO playerDao)
        {
            this.playerDao = playerDao;
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
    }
}