using Microsoft.EntityFrameworkCore;

namespace pokemon_fight_rest_api.Models
{
    public class PokemonFightDbContext : DbContext
    {
        public DbSet<DataDefinition.Player> Players { get; set; }
        public DbSet<DataDefinition.Deck> Decks { get; set; }
        public DbSet<DataDefinition.Invitation> Invitations { get; set; }
        public DbSet<DataDefinition.Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=PokemonFightApiRestDB;Trusted_Connection=True;");
        }
    }
}
