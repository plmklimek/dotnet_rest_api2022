using Microsoft.EntityFrameworkCore;

namespace fighters_api.Data
{
    public class FighterContext : DbContext
    {
        public FighterContext(DbContextOptions<FighterContext> options) : base(options)
        {

        }
        public DbSet<Fighters> Fighters { get; set; }
    }
}
