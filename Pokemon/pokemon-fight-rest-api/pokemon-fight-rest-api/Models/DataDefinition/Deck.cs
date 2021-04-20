namespace pokemon_fight_rest_api.Models.DataDefinition
{
    public class Deck
    {
        public int DeckId { get; set; }
        public int? FirstPokemonId { get; set; }
        public int? SecondPokemonId { get; set; }
        public int? ThirdPokemonId { get; set; }
    }
}
