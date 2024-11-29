using Microsoft.EntityFrameworkCore;
using TP3.Models;

public class AppDbContext : DbContext
{
    public DbSet<Customers> Customers { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<Genres> Genres { get; set; }
    public DbSet<Movies> Movies { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Replace with your MySQL connection string
        optionsBuilder.UseMySql("server=localhost;database=mydb;user=root;password=",
            new MySqlServerVersion(new Version(8, 0, 30))); // Specify your MySQL version
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customers>()
            .HasMany(c => c.Movies)
            .WithMany(m => m.Customers)
            .UsingEntity<Dictionary<string, object>>(
                "CustomerMovie", // Junction table name
                j => j.HasOne<Movies>().WithMany().HasForeignKey("MovieId"), // Define foreign key to Movies
                j => j.HasOne<Customers>().WithMany().HasForeignKey("CustomerId") // Define foreign key to Customers
            );

        base.OnModelCreating(modelBuilder);

        string genreJson = System.IO.File.ReadAllText("Data/Genres.json");
        var genres = System.Text.Json.JsonSerializer.Deserialize<List<Genres>>(genreJson);

        foreach (var genre in genres)
        {
            modelBuilder.Entity<Genres>().HasData(genre);
        }
    }

}
