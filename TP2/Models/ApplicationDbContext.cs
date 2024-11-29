using Microsoft.EntityFrameworkCore;
namespace TP2.Models
{
    public class ApplicationdbContext : DbContext
    {
        public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        // Optionally configure SQLite directly here
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=movies.db");  // SQLite database file
            }
        }
    }

}
