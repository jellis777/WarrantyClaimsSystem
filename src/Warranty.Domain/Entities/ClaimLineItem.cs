using Warranty.Domain.ValueObjects;

namespace Warranty.Domain.Entities;

public class ClaimLineItem
{
    public string Description { get; private set; }
    public Money Cost { get; private set; }

    public ClaimLineItem(string description, Money cost)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.");

        Description = description;
        Cost = cost;
    }
}