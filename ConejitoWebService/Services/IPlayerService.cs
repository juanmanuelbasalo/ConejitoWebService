using ConejitoWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConejitoWebService.Services
{
    public interface IPlayerService
    {
        int GetMyScore(string facebookId);
        bool InsertPlayer(Player player);
        bool UpdatePlayerScore(Player player, int score);
        IList<Player> GetMyFriends(ICollection<Player> players);
    }
}
