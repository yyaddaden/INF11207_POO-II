using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace pokemon_fight_rest_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Decks")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private Models.PokemonFightDbContext _dbContext;

        public DeckController()
        {
            _dbContext = new Models.PokemonFightDbContext();
        }

        [HttpPost("{playerId}")]
        [ProducesResponseType(typeof(Models.DataFormat.PlayerModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult AddDeck(int playerId, [FromBody] Models.DataFormat.DeckModel model)
        {
            try
            {
                Models.DataDefinition.Player player = _dbContext.Players.Find(playerId);
                if (player != null)
                {
                    Models.DataDefinition.Deck deck = new Models.DataDefinition.Deck()
                    {
                        FirstPokemonId = model.FirstPokemonId,
                        SecondPokemonId = model.SecondPokemonId,
                        ThirdPokemonId = model.ThirdPokemonId
                    };
                    _dbContext.Decks.Add(deck);
                    _dbContext.SaveChanges();
                    player.DeckId = deck.DeckId;
                    _dbContext.SaveChanges();
                    return CreatedAtAction(nameof(GetDeck), new { deckId = deck.DeckId }, deck);
                }
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpGet("{deckId}", Name = "GetDeck")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult GetDeck(int deckId)
        {
            try
            {
                Models.DataDefinition.Deck deck = _dbContext.Decks.Find(deckId);
                if (deck != null)
                    return Ok(deck);
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpDelete("{deckId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult RemoveDeck(int deckId)
        {
            try
            {
                Models.DataDefinition.Deck deck = _dbContext.Decks.Find(deckId);
                if (deck != null)
                {
                    _dbContext.Decks.Remove(deck);
                    _dbContext.SaveChanges();
                    return Ok();
                }
                else
                    return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception) { }

            return BadRequest();
        }

        [HttpPut("{deckId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult UpdateDeck([FromBody] Models.DataFormat.DeckModel model, int deckId)
        {
            try
            {
                Models.DataDefinition.Deck deck = _dbContext.Decks.Find(deckId);
                if (deck != null)
                {
                    deck.FirstPokemonId = model.FirstPokemonId ?? deck.FirstPokemonId;
                    deck.SecondPokemonId = model.SecondPokemonId ?? deck.SecondPokemonId;
                    deck.ThirdPokemonId = model.ThirdPokemonId ?? deck.ThirdPokemonId;
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
