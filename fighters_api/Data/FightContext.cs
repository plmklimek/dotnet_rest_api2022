using Microsoft.EntityFrameworkCore;

namespace fighters_api.Data
{
    public class FightContext:DbContext
    {
        public FightContext(DbContextOptions<FightContext> options) : base(options)
        {
           
        }
        public DbSet<Fight> Fights { get; set; }
    }
}
