using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

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
  }
}