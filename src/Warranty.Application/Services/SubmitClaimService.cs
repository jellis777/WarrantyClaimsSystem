using Warranty.Application.Interfaces;

namespace Warranty.Application.Services;

public class SubmitClaimService
{
    private readonly IClaimRepository _repository;

    public SubmitClaimService(IClaimRepository repository)
    {
        _repository = repository;
    }

    public async Task SubmitAsync(Guid claimId)
    {
        var claim = await _repository.GetByIdAsync(claimId);

        if (claim == null)
            throw new Exception("Claim not found.");

        claim.Submit();

        await _repository.SaveAsync(claim);
    }
}