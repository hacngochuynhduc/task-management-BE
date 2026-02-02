using Microsoft.EntityFrameworkCore;
using STEAMHOUSE.Base.Entities;

namespace STEAMHOUSE.Infrastruture.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // public DbSet<User> Users { get; set; }
    public DbSet<TaskList> TaskLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("application");

        // modelBuilder.Entity<User>(entity =>
        // {
        //     entity.HasKey(e => e.Id);
        //     entity.Property(u => u.UserName).IsRequired().HasMaxLength(50);
        // });

        modelBuilder.Entity<TaskList>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Status).HasConversion<string>(); 
        });

        base.OnModelCreating(modelBuilder);
    }
}