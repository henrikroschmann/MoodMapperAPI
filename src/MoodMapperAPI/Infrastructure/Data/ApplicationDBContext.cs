using System.Reflection.Metadata;

namespace MoodMapperAPI.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Journal> Journals { get; set; }
    public DbSet<Entry> Entries { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public ApplicationDbContext()
    { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Journal>()
        .HasKey(j => j.Id);

        modelBuilder.Entity<Journal>()
            .HasOne<ApplicationUser>(j => j.User)
            .WithMany(u => u.Journals)
            .HasForeignKey(j => j.UserId);

        modelBuilder.Entity<Journal>()
            .HasMany(u => u.Entries)
            .WithOne(e => e.Journal)
            .HasForeignKey(e => e.JournalId);

        modelBuilder.Entity<Entry>().HasKey(e => e.Id);
        modelBuilder.Entity<Entry>()
            .HasOne<ApplicationUser>(e => e.User)
            .WithMany(u => u.Entries)
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<Tag>().HasKey(t => t.Id);
        modelBuilder.Entity<Tag>()
            .HasMany<Entry>(t => t.Entries)
            .WithOne(e => e.Tag)
            .HasForeignKey(e => e.TagId);
       
        modelBuilder.Entity<Tag>()
            .HasOne<ApplicationUser>(t => t.User)
            .WithMany(u => u.Tags)
            .HasForeignKey(t => t.UserId);


        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable(name: "Users");
        });
    }
}