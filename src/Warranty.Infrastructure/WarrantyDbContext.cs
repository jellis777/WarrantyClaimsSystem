using Microsoft.EntityFrameworkCore;
using Warranty.Domain.Entities;
using Warranty.Domain.ValueObjects;

namespace Warranty.Infrastructure.Persistence;

public class WarrantyDbContext : DbContext
{
    public WarrantyDbContext(DbContextOptions<WarrantyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Claim> Claims => Set<Claim>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure ClaimLineItem
        modelBuilder.Entity<ClaimLineItem>(entity =>
        {
            entity.HasKey(x => x.Id);

            // Use value conversion for Money - store Amount as decimal
            entity.Property(e => e.Cost)
                  .HasConversion(
                      money => money.Amount,
                      amount => new Money(amount))
                  .HasColumnName("Cost");
        });

        // Configure Claim -> ClaimLineItem relationship
        modelBuilder.Entity<Claim>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasMany<ClaimLineItem>()
                  .WithOne()
                  .HasForeignKey(x => x.ClaimId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        base.OnModelCreating(modelBuilder);
    }
}