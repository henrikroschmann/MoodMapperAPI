using Microsoft.EntityFrameworkCore;

namespace MoodMapperAPI.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Journal> Journals { get; set; }
    public DbSet<Entry> Entries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Journal>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Journal>()
            .HasOne(x => x.User)
            .WithOne(x => x.Journal)
            .HasForeignKey<Journal>(x => x.UserId);

        modelBuilder.Entity<Entry>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Entry>()
            .HasOne(x => x.User);

        modelBuilder.Entity<ApplicationUser>()
            .HasOne(x => x.Journal);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(x => x.Entries)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable(name: "Users");
        });
    }
}