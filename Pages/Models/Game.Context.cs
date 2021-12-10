using Microsoft.EntityFrameworkCore;

namespace  Final_Project.Models
{

    public class GameDbContext : DbContext
    {

        public GameDbContext (DbContextOptions<Context> options): base(options)
        {

        }
        public DbSet<Game> Gaming {get; set;}
    } 
}