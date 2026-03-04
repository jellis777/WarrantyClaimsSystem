using FluentAssertions;
using Warranty.Domain.Entities;
using Warranty.Domain.ValueObjects;


namespace Warranty.Domain.Tests;

public class ClaimTests
{
    [Fact]
    public void Should_Not_Allow_Submit_If_No_LineItems()
    {
        // Arrange
        var claim = new Claim();

        // Act 
        Action act = () => claim.Submit();

        // Assert 
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Adding_LineItems_Should_Increase_Total()
    {
        // Arrange
        var claim = new Claim();

        // Act 
        claim.AddLineItem("Engine Repair", new Money(100));
        claim.AddLineItem("Labor", new Money(50));

        var total = claim.GetTotal();

        // Assert 
        total.Amount.Should().Be(150);
    }

    [Fact]
    public void Should_Not_Allow_AddLineItem_After_Submission()
    {
        // Arrange 
        var claim = new Claim();
        claim.AddLineItem("Engine Repair", new Money(100));
        claim.Submit();

        // Act 
        Action act = () => claim.AddLineItem("Extra", new Money(50));

        // Assert 
        act.Should().Throw<InvalidOperationException>();
    }
}