using Warranty.Domain.ValueObjects;

namespace Warranty.Domain.Entities;

public class ClaimLineItem
{
    public Guid Id { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public Money Cost { get; private set; } = new Money(0);
    public Guid ClaimId { get; private set; }

    // Parameterless constructor for EF Core
    private ClaimLineItem()
    {
        Id = Guid.NewGuid();
    }

    public ClaimLineItem(string description, Money cost)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.");

        Id = Guid.NewGuid();
        Description = description;
        Cost = cost;
    }
}