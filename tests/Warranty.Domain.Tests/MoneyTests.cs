using FluentAssertions;
using Warranty.Domain.ValueObjects;

namespace Warranty.Domain.Tests;

public class MoneyTests
{
    [Fact]
    public void Should_Create_Money_With_Positive_Amount()
    {
        var money = new Money(100);

        money.Amount.Should().Be(100);
    }

    [Fact]
    public void Should_Throw_When_Amount_Is_Negative()
    {
        Action act = () => new Money(-5);

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Should_Add_Money_Correctly()
    {
        var m1 = new Money(50);
        var m2 = new Money(25);

        var result = m1 + m2;

        result.Amount.Should().Be(75);
    }
}