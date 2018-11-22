using ConejitoWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConejitoWebService.Services;
using ConejitoWebService.DAO;
using System.Threading.Tasks;

namespace ConejitoWebService.Controllers
{
    public class PlayersController : ApiController
    {
        private readonly IPlayerService playerService;

        public PlayersController()
        {
            playerService = new PlayerService();
        }

        [Route("api/Players/GetScore/{facebookId}")]
        [HttpGet]
        public async Task<int> GetScore(string facebookId)
        {
            return await playerService.GetMyScoreAsync(facebookId);
            //return playerService.GetMyScore(facebookId);
        }

        [Route("api/Players/GetMyFriends")]
        [HttpPost]
        public async Task<ListPlayer> GetMyFriends([FromBody]ListPlayer players)
        {
            return await playerService.GetMyFriendsDbAsync(players);
            //return playerService.GetMyFriends(players);
        }

        [Route("api/Players/GetPlayer/{facebookId}")]
        public async Task<Player> GetPlayer(string facebookId)
        {
            return await playerService.GetPlayerAsync(facebookId);
            //return playerService.GetPlayer(facebookId);
        }
        // POST: api/Players
        public async Task Post([FromBody]Player player)
        {
            await playerService.InsertPlayerAsync(player);
            //playerService.InsertPlayer(player);
        }

        // PUT: api/Players?score={score}
        public async Task Put(int score, [FromBody]Player player)
        {
            await playerService.UpdatePlayerScoreAsync(player, score);
            //playerService.UpdatePlayerScore(player, score);
        }

        // DELETE: api/Players/5
        public void Delete(int id)
        {
        }
    }
}
