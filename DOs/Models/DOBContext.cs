using Microsoft.EntityFrameworkCore;

public class DOBContext: DbContext
{
    public DbSet<DO> DOs {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"); 
        if ( environment == "Development")
        {
            optionsBuilder.UseSqlite("Data Source=DODB.db");
        }
        else 
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ProdDBConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DO>().HasData(
            new DO() {Id = 1, Title = "Moni", Description = "Know yourselves", Done = false, DueDate = new DateTime(2025, 4, 25, 23, 59, 59)}
        );
    }
}