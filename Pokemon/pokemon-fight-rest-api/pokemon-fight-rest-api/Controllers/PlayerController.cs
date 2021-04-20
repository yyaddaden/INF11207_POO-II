using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace pokemon_fight_rest_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private Models.PokemonFightDbContext _dbContext;

        public PlayerController()
        {
            _dbContext = new Models.PokemonFightDbContext();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Models.DataFormat.PlayerModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult AddPlayer([FromBody] Models.DataFormat.PlayerModel model)
        {
            try
            {
                Models.DataDefinition.Player player = new Models.DataDefinition.Player()
                {
                    Name = model.Name
                };
                _dbContext.Players.Add(player);
                _dbContext.SaveChanges();
                return CreatedAtAction(nameof(GetPlayer), new { playerId = player.PlayerId }, player);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetPlayers()
        {
            try
            {
                List<Models.DataDefinition.Player> players = _dbContext.Players.ToList();
                return Ok(players);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpGet("{playerId}", Name = "GetPlayer")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetPlayer(int playerId)
        {
            try
            {
                Models.DataDefinition.Player player = _dbContext.Players.Find(playerId);
                if (player != null)
                    return Ok(player);
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpDelete("{playerId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult RemovePlayer(int playerId)
        {
            try
            {
                Models.DataDefinition.Player player = _dbContext.Players.Find(playerId);
                if (player != null)
                {
                    _dbContext.Players.Remove(player);
                    _dbContext.SaveChanges();
                    return Ok();
                }
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }
    }
}
