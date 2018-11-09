﻿using ConejitoWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConejitoWebService.Services;

namespace ConejitoWebService.Controllers
{
    public class PlayersController : ApiController
    {
        private readonly IPlayerService playerService;

        public PlayersController()
        {
            playerService = new PlayerService(
);
        }

        [Route("api/Players/GetScore/{facebookId}")]
        [HttpGet]
        public int GetScore(string facebookId)
        {
            return playerService.GetMyScore(facebookId);
        }

        [Route("api/Players/GetMyFriends")]
        [HttpGet]
        public IList<Player> GetMyFriends([FromBody]ICollection<Player> players)
        {
            return playerService.GetMyFriends(players);
        }

        // POST: api/Players
        public void Post([FromBody]Player player)
        {
            playerService.InsertPlayer(player);
        }

        // PUT: api/Players?score={score}
        public void Put(int score, [FromBody]Player player)
        {
            playerService.UpdatePlayerScore(player, score);
        }

        // DELETE: api/Players/5
        public void Delete(int id)
        {
        }
    }
}
