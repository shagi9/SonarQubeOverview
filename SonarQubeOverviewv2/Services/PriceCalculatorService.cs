namespace SonarQubeOverviewv2.Services
{
    public class PriceCalculatorService
    {
        private const double TaxRate = 0.23;
        private const double ShippingFee = 10.0;
        private const double DiscountThreshold = 100.0;
        private const double DiscountRate = 0.10;

        public double CalculateFinalPrice(double basePrice)
        {
            if (basePrice < 0)
                throw new ArgumentException("Price cannot be negative.", nameof(basePrice));

            double price = basePrice + (basePrice * TaxRate);

            if (basePrice > DiscountThreshold)
                price -= price * DiscountRate;

            price += ShippingFee;

            return Math.Round(price, 2);
        }

        public double CalculateBulkPrice(double unitPrice, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            double total = unitPrice * quantity;

            if (quantity >= 10)
                total -= total * 0.05;

            return Math.Round(total, 2);
        }
    }
}
