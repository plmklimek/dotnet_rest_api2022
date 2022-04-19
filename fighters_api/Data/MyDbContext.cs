using System;
using Microsoft.EntityFrameworkCore;
namespace fighters_api.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<Fight> Fights { get; set; }
    }
}
