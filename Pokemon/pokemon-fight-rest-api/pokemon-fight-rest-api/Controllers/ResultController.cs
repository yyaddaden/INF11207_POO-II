using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace pokemon_fight_rest_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Results")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private Models.PokemonFightDbContext _dbContext;

        public ResultController()
        {
            _dbContext = new Models.PokemonFightDbContext();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Models.DataFormat.ResultModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult AddDeck([FromBody] Models.DataFormat.ResultModel model)
        {
            try
            {
                Models.DataDefinition.Invitation invitation = _dbContext.Invitations.Find(model.InvitationId);
                Models.DataDefinition.Player player = _dbContext.Players.Find(model.PlayerWinnerId);
                if (invitation != null && player != null)
                {
                    Models.DataDefinition.Result result = new Models.DataDefinition.Result()
                    {
                        InvitationId = invitation.InvitationId,
                        PlayerWinnerId = player.PlayerId
                    };
                    _dbContext.Results.Add(result);
                    invitation.Status = "finished";
                    _dbContext.SaveChanges();
                    return CreatedAtAction(nameof(GetResult), new { resultId = result.resultId }, result);
                }
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetResults(int playerId)
        {
            try
            {
                Models.DataDefinition.Player player = _dbContext.Players.Include(p => p.Invitations).Where(p => p.PlayerId == playerId).FirstOrDefault();
                if (player != null)
                {
                    List<Models.DataDefinition.Result> results = _dbContext.Results.Include(i => i.Invitation).Include(i => i.PlayerWinner).Where(r => r.PlayerWinnerId == player.PlayerId).ToList();
                    return Ok(results);
                }
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpGet("{resultId}", Name = "GetResult")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetResult(int resultId)
        {
            try
            {
                Models.DataDefinition.Result result = _dbContext.Results.Include(i => i.Invitation).Include(i => i.PlayerWinner).Where(i => i.resultId == resultId).FirstOrDefault();
                if (result != null)
                    return Ok(result);
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpDelete("{resultId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult RemoveResult(int resultId)
        {
            try
            {
                Models.DataDefinition.Result result = _dbContext.Results.Find(resultId);
                if (result != null)
                {
                    _dbContext.Results.Remove(result);
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
