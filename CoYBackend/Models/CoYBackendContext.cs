using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using CoYBackend.Models;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Money>()
      .HasOne(m => m.User)
      .WithMany(u => u.Contributions)
      .HasForeignKey(m => m.UserId)
      .HasPrincipalKey(u => u.Id);

      modelBuilder.Entity<Money>()
      .HasOne(m => m.Contribution_Type)
      .WithMany(c => c.Money)
      .HasForeignKey(m => m.ContributionTypeId)
      .HasPrincipalKey(u => u.Id);
    }
  }
}