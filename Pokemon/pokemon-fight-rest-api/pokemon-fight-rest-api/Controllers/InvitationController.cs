using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace pokemon_fight_rest_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Invitations")]
    [ApiController]
    public class InvitationController : ControllerBase
    {
        private Models.PokemonFightDbContext _dbContext;

        public InvitationController()
        {
            _dbContext = new Models.PokemonFightDbContext();
        }

        [HttpPost("{playerId}")]
        [ProducesResponseType(typeof(Models.DataFormat.InvitationModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult AddInvitation(int playerId, [FromBody] Models.DataFormat.InvitationModel model)
        {
            try
            {
                Models.DataDefinition.Player playerEmitter = _dbContext.Players.Find(playerId);
                Models.DataDefinition.Player playerReceiver = _dbContext.Players.Find(model.PlayerReceiverId);
                if (playerEmitter != null && playerReceiver != null)
                {
                    Models.DataDefinition.Invitation invitation = new Models.DataDefinition.Invitation()
                    {
                        PlayerEmitterId = playerEmitter.PlayerId,
                        PlayerReceiverId = playerReceiver.PlayerId,
                        Money = model.Money,
                        Status = "pending"
                    };
                    _dbContext.Invitations.Add(invitation);
                    _dbContext.SaveChanges();
                    return CreatedAtAction(nameof(GetInvitation), new { invitationId = invitation.InvitationId }, invitation);
                }
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpGet("{invitationId}", Name = "GetInvitation")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetInvitation(int invitationId)
        {
            try
            {
                Models.DataDefinition.Invitation invitation = _dbContext.Invitations.Find(invitationId);
                if (invitation != null)
                    return Ok(invitation);
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpGet("Received/{playerId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetReceived(int playerId)
        {
            try
            {
                Models.DataDefinition.Player player = _dbContext.Players.Find(playerId);
                if (player != null)
                {
                    List<Models.DataDefinition.Invitation> invitations = _dbContext.Invitations.Where(i => i.PlayerReceiverId == player.PlayerId).ToList();
                    return Ok(invitations);
                }
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpGet("Emitted/{playerId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetEmitted(int playerId)
        {
            try
            {
                Models.DataDefinition.Player player = _dbContext.Players.Find(playerId);
                if (player != null)
                {
                    List<Models.DataDefinition.Invitation> invitations = _dbContext.Invitations.Where(i => i.PlayerEmitterId == player.PlayerId).ToList();
                    return Ok(invitations);
                }
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpPatch("Accept/{playerId}/{invitationId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Accept(int playerId, int invitationId)
        {
            try
            {
                Models.DataDefinition.Player player = _dbContext.Players.Find(playerId);
                if (player == null)
                    return StatusCode((int)HttpStatusCode.NotFound);

                Models.DataDefinition.Invitation invitation = _dbContext.Invitations.Where(i => i.PlayerReceiverId == player.PlayerId && i.InvitationId == invitationId).FirstOrDefault();

                if (invitation != null)
                {
                    invitation.Status = "accepted";
                    _dbContext.SaveChanges();
                    return Ok();
                }
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpPatch("Refuse/{playerId}/{invitationId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Refuse(int playerId, int invitationId)
        {
            try
            {
                Models.DataDefinition.Player player = _dbContext.Players.Find(playerId);
                if(player == null)
                    return StatusCode((int)HttpStatusCode.NotFound);

                Models.DataDefinition.Invitation invitation = _dbContext.Invitations.Where(i => i.PlayerReceiverId == player.PlayerId && i.InvitationId == invitationId).FirstOrDefault();

                if (invitation != null)
                {
                    invitation.Status = "refused";
                    _dbContext.SaveChanges();
                    return Ok();
                }
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpDelete("{invitationId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult RemoveInvitation(int invitationId)
        {
            try
            {
                Models.DataDefinition.Invitation invitation = _dbContext.Invitations.Find(invitationId);
                if (invitation != null)
                {
                    _dbContext.Invitations.Remove(invitation);
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
