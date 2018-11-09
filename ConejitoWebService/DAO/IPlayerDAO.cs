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
        IList<Player> GetMyFriendsDb(ICollection<Player> players);
        bool InsertPlayer(Player player);
        bool UpdatePlayerScore(Player player, int score);
    }
}
