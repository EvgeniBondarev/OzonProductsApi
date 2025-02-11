using Microsoft.EntityFrameworkCore;
using OzonProductsApi.Persistence.SQL.MySql.Models;

namespace OzonProductsApi.Persistence.SQL.MySql;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) { }

    public DbSet<OzonTaskEntity> OzonTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OzonTaskEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.TaskId).IsRequired();
            entity.Property(e => e.MongoId).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
            entity.Property(e => e.LastStatus).HasMaxLength(100);
        });
    }
}