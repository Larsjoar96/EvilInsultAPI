using Microsoft.EntityFrameworkCore;
using EvilInsultAPI.Models.Domain;


namespace EvilInsultAPI.Models
{
    public class EvilDbContext : DbContext
    {
        public EvilDbContext(DbContextOptions<EvilDbContext> options) : base(options) 
        {
            
        }

        //Database tables
        public DbSet<Insult> Insults { get; set; } 
    }
}
