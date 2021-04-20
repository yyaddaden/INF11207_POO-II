namespace pokemon_fight_rest_api.Models.DataDefinition
{
    public class Invitation
    {
        public int InvitationId { get; set; }
        public float Money { get; set; }
        public string Status { get; set; }

        public int PlayerEmitterId { get; set; }
        public int PlayerReceiverId { get; set; }
    }
}
