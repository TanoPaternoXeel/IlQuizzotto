using IlQuizzotto.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>();
        modelBuilder.Entity<Match>();
        modelBuilder.Entity<Player>();
        modelBuilder.Entity<Session>();
        modelBuilder.Entity<Answer>();

        base.OnModelCreating(modelBuilder);
    }
}