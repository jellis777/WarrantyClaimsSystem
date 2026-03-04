
using Microsoft.EntityFrameworkCore;
using Warranty.Application.Interfaces;
using Warranty.Domain.Entities;
using Warranty.Infrastructure.Persistence;

namespace Warranty.Infrastructure.Repositories;

public class ClaimRepository : IClaimRepository
{
    private readonly WarrantyDbContext _context;

    public ClaimRepository(WarrantyDbContext context)
    {
        _context = context;
    }


    public async Task<Claim?> GetByIdAsync(Guid id)
    {
        return await _context.Claims.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task SaveAsync(Claim claim)
    {
        _context.Update(claim);
        await _context.SaveChangesAsync();
    }

}