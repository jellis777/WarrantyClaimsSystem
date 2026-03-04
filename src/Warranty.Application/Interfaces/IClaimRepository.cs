using Warranty.Domain.Entities;

namespace Warranty.Application.Interfaces;

public interface IClaimRepository
{
    Task<Claim?> GetByIdAsync(Guid id);
    Task SaveAsync(Claim claim);
}