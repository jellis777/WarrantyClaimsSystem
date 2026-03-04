using FluentAssertions;
using Warranty.Domain.Entities;
using Warranty.Domain.ValueObjects;
using Warranty.Domain.Enums;
using Warranty.Application.Services;

namespace Warranty.Domain.Tests;

public class SubmitClaimServiceTests
{
    [Fact]
    public async Task Should_Submit_Claim()
    {
        // Arrange
        var repo = new FakeClaimRepository();
        var service = new SubmitClaimService(repo);

        var claim = new Claim();
        claim.AddLineItem("Engine", new Money(100));

        repo.Add(claim); // Add claim to repository

        // Act 
        await service.SubmitAsync(claim.Id);

        // Assert
        var savedClaim = await repo.GetByIdAsync(claim.Id);
        savedClaim!.Status.Should().Be(ClaimStatus.Submitted);
    }
}