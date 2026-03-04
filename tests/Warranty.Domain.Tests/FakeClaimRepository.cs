using Warranty.Domain.Entities;
using Warranty.Application.Interfaces;

namespace Warranty.Domain.Tests;

public class FakeClaimRepository : IClaimRepository
{
    private readonly Dictionary<Guid, Claim> _storage = new();

    public Task<Claim?> GetByIdAsync(Guid id)
    {
        _storage.TryGetValue(id, out var claim);
        return Task.FromResult(claim);
    }

    public Task SaveAsync(Claim claim)
    {
        _storage[claim.Id] = claim;
        return Task.CompletedTask;
    }

    public void Add(Claim claim)
    {
        _storage[claim.Id] = claim;
    }

}

