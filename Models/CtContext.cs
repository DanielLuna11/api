using Microsoft.EntityFrameworkCore;

namespace Ct.Models;

public class CtContext : DbContext
{
    public CtContext(DbContextOptions<CtContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CtItem>()
            .HasNoKey();
    }

    public DbSet<CtItem> CtItems { get; set; } = null!;
}