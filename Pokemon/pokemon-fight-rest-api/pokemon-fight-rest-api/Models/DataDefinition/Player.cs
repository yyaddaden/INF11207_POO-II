using System.Collections.Generic;

namespace pokemon_fight_rest_api.Models.DataDefinition
{
    public class Player
    {
        public Player()
        {
            Invitations = new List<Invitation>();
        }

        public int PlayerId { get; set; }
        public string Name { get; set; }

        public int? DeckId { get; set; }
        public Deck Deck { get; set; }

        public ICollection<Invitation> Invitations { get; set; }
    }
}
