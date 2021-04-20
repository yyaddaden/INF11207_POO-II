namespace pokemon_fight_rest_api.Models.DataDefinition
{
    public class Result
    {
        public int resultId { get; set; }

        public int InvitationId { get; set; }
        public Invitation Invitation { get; set; }

        public int PlayerWinnerId { get; set; }
        public Player PlayerWinner { get; set; }
    }
}
