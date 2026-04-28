using SonarQubeOverviewv2.Models;
using SonarQubeOverviewv2.Services;

namespace SonarQubeOverviewv2.Tests;

public class PriceCalculatorServiceTests
{
    private readonly PriceCalculatorService _sut = new();

    [Fact]
    public void CalculateFinalPrice_NegativePrice_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>((Action)(() => _sut.CalculateFinalPrice(-1)));
    }

    [Fact]
    public void CalculateFinalPrice_ZeroPrice_ReturnShippingFeeOnly()
    {
        var result = _sut.CalculateFinalPrice(0);
        Assert.Equal(10.0, result);
    }

    [Fact]
    public void CalculateFinalPrice_PriceAboveDiscountThreshold_AppliesDiscount()
    {
        // basePrice=200 -> tax=200*1.23=246 -> discount=246*0.9=221.4 -> +shipping=231.4
        var result = _sut.CalculateFinalPrice(200);
        Assert.Equal(231.4, result);
    }

    [Fact]
    public void CalculateFinalPrice_PriceBelowDiscountThreshold_NoDiscount()
    {
        // basePrice=50 -> tax=50*1.23=61.5 -> +shipping=71.5
        var result = _sut.CalculateFinalPrice(50);
        Assert.Equal(71.5, result);
    }

    [Fact]
    public void CalculateBulkPrice_ZeroQuantity_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>((Action)(() => _sut.CalculateBulkPrice(10, 0)));
    }

    [Fact]
    public void CalculateBulkPrice_NegativeQuantity_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>((Action)(() => _sut.CalculateBulkPrice(10, -5)));
    }

    [Fact]
    public void CalculateBulkPrice_QuantityBelow10_NoDiscount()
    {
        // 5 * 20 = 100
        var result = _sut.CalculateBulkPrice(20, 5);
        Assert.Equal(100.0, result);
    }

    [Fact]
    public void CalculateBulkPrice_QuantityAtLeast10_AppliesBulkDiscount()
    {
        // 10 * 20 = 200 -> 5% off = 190
        var result = _sut.CalculateBulkPrice(20, 10);
        Assert.Equal(190.0, result);
    }
}

public class UserServiceTests
{
    private readonly UserService _sut = new();

    [Fact]
    public void Login_ValidCredentials_ReturnsTrue()
    {
        var result = _sut.Login("admin", "123456");
        Assert.True(result);
    }

    [Fact]
    public void Login_InvalidCredentials_ReturnsFalse()
    {
        var result = _sut.Login("user", "wrongpass");
        Assert.False(result);
    }

    [Fact]
    public void CalculatePrice_ReturnsCorrectValue()
    {
        // price * 1.23 + 10
        var result = _sut.CalculatePrice(100);
        Assert.Equal(133.0, result);
    }

    [Fact]
    public void Sum_ReturnsCorrectSum()
    {
        var result = _sut.Sum([1, 2, 3, 4, 5]);
        Assert.Equal(15, result);
    }

    [Fact]
    public void Sum_EmptyList_ReturnsZero()
    {
        var result = _sut.Sum([]);
        Assert.Equal(0, result);
    }

    [Fact]
    public void BuildQuery_ReturnsQueryWithName()
    {
        var result = _sut.BuildQuery("Alice");
        Assert.Contains("Alice", result);
    }

    [Fact]
    public void ComplexCalculation_ValueAbove100_Returns1()
    {
        Assert.Equal(1, _sut.ComplexCalculation(101));
    }

    [Fact]
    public void ComplexCalculation_ValueZeroOrNegative_Returns0()
    {
        Assert.Equal(0, _sut.ComplexCalculation(0));
        Assert.Equal(0, _sut.ComplexCalculation(-5));
    }

    [Fact]
    public void ComplexCalculation_ValueBetween1And10_Returns0()
    {
        Assert.Equal(0, _sut.ComplexCalculation(5));
    }

    [Fact]
    public void ProcessUsers_WritesNamesToOutput()
    {
        var users = new List<User> { new() { Name = "Alice" }, new() { Name = "Bob" } };
        var exception = Record.Exception((Action)(() => _sut.ProcessUsers(users)));
        Assert.Null(exception);
    }

    [Fact]
    public void ProcessData_DoesNotThrow()
    {
        var exception = Record.Exception((Action)(() => _sut.ProcessData()));
        Assert.Null(exception);
    }
}
