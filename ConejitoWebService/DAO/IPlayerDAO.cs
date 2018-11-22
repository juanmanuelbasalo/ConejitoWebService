using ConejitoWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConejitoWebService.DAO
{
    public interface IPlayerDAO
    {
        int GetMyScore(string facebookId);
        bool InsertPlayer(Player player);
        bool UpdatePlayerScore(Player player, int score);
        ListPlayer GetMyFriendsDb(ListPlayer players);
        Player GetPlayer(string facebookId);

        Task<int> GetMyScoreAsync(string facebookId);
        Task<ListPlayer> GetMyFriendsDbAsync(ListPlayer players);
        Task<Player> GetPlayerAsync(string facebookId);
        Task<bool> InsertPlayerAsync(Player player);
        Task<bool> UpdatePlayerScoreAsync(Player player, int score);
    }
}
