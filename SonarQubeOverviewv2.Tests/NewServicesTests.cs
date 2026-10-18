using SonarQubeOverviewv2.Services;

namespace SonarQubeOverviewv2.Tests;

public class PaymentServiceTests
{
    private readonly PaymentService _sut = new();

    [Fact]
    public void Charge_WithCardNumber_AddsCardLength()
    {
        var result = _sut.Charge(100m, "1234");
        Assert.Equal(104m, result);
    }

    [Fact]
    public void Charge_NullCard_ReturnsZero()
    {
        // NullReferenceException is swallowed inside Charge, so it silently returns 0
        var result = _sut.Charge(100m, null);
        Assert.Equal(0m, result);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void GetStatus_AlwaysReturnsOk(bool paid)
    {
        Assert.Equal("OK", _sut.GetStatus(paid));
    }
}

public class CryptoServiceTests
{
    private readonly CryptoService _sut = new();

    [Fact]
    public void Hash_ReturnsSha1HexString()
    {
        var result = _sut.Hash("abc");
        Assert.Equal(40, result.Length);
    }

    [Fact]
    public void NewOneTimePassword_IsSixDigits()
    {
        var otp = _sut.NewOneTimePassword();
        Assert.InRange(otp, 100000, 999999);
    }
}

public class InvoiceExportServiceTests
{
    private readonly InvoiceExportService _sut = new();

    [Fact]
    public void CalculatePdfTotal_SmallInvoice_AddsTaxAndFee()
    {
        // net 300 -> tax 60 -> fee 25 -> no rebate = 385
        var result = _sut.CalculatePdfTotal([100m, 200m], 0.2m, "ACME");
        Assert.Equal(385m, result);
    }

    [Fact]
    public void CalculatePdfTotal_EmptyAmounts_Throws()
    {
        Assert.Throws<ArgumentException>(() => _sut.CalculatePdfTotal([], 0.2m, "ACME"));
    }
}
