using Warranty.Domain.Enums;
using Warranty.Domain.ValueObjects;

namespace Warranty.Domain.Entities;

public class Claim
{
    private readonly List<ClaimLineItem> _lineItems = new();

    public Guid Id { get; private set; }
    public ClaimStatus Status { get; private set; }

    public IReadOnlyCollection<ClaimLineItem> LineItems => _lineItems.AsReadOnly();

    public Claim()
    {
        Id = Guid.NewGuid();
        Status = ClaimStatus.Draft;
    }

    public void AddLineItem(string description, Money cost)
    {
        if (Status != ClaimStatus.Draft)
            throw new InvalidOperationException("Cannot modify a submitted claim.");

        _lineItems.Add(new ClaimLineItem(description, cost));
    }

    public Money GetTotal()
    {
        var total = new Money(0);

        foreach (var item in _lineItems)
        {
            total += item.Cost;
        }

        return total;
    }

    public void Submit()
    {
        if (!_lineItems.Any())
            throw new InvalidOperationException("Cannot submit a claim with no line items.");

        Status = ClaimStatus.Submitted;
    }
}