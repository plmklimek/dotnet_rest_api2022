using Microsoft.EntityFrameworkCore;

namespace fighters_api.Data
{
    public class FighterContext : DbContext
    {
        public FighterContext(DbContextOptions<FightContext> options) : base(options)
        {

        }
        public DbSet<Fighter> Fighters { get; set; }
    }
}
