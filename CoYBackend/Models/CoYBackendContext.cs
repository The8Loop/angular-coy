using Microsoft.EntityFrameworkCore;

namespace CoYBackend.Models
{
  public class CoYBackendContext : DbContext
  {
    public CoYBackendContext(DbContextOptions<CoYBackendContext> options)
        : base(options)
    {
    }

    public DbSet<User> users { get; set; } = null!;
    public DbSet<Money> money { get; set; } = null!;
    public DbSet<Contribution_Type> contribution_type { get; set; } = null!;
    public DbSet<TotalSP> totalSPDbSet { get; set; }

    public virtual Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade yggdrasil { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Money>()
      .HasOne(m => m.User)
      .WithMany(u => u.Contributions)
      .HasForeignKey(m => m.UserId)
      .HasPrincipalKey(u => u.Id);

      modelBuilder.Entity<Money>()
      .HasOne(m => m.ContributionType)
      .WithMany(c => c.Money)
      .HasForeignKey(m => m.ContributionTypeId)
      .HasPrincipalKey(u => u.Id);

      modelBuilder.Entity<User>()
      .HasOne(u => u.Algorithm)
      .WithMany(a => a.Users)
      .HasForeignKey(u => u.AlgorithmId)
      .HasPrincipalKey(a => a.Id);

      modelBuilder.Entity<TotalSP>().HasNoKey();
      modelBuilder.Entity<Leaderboard>().HasNoKey();
    }
  }
}