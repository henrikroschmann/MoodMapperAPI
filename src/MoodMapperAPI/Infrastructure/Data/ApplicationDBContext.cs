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
            .HasMany(x => x.Entries)
            .WithOne(e => e.Journal)
            .HasForeignKey(e => e.JournalId);

        modelBuilder.Entity<Entry>()
            .HasKey(x => x.Id);
    }
}