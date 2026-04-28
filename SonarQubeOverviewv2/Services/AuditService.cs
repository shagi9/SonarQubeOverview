namespace SonarQubeOverviewv2.Services
{
    public class AuditService
    {
        // 🔴 SonarQube - cross-file duplication (identical block to ReportService)
        public double AuditPdfTotal(List<double> prices, int quantity, string currency)
        {
            if (prices == null || prices.Count == 0)
                throw new ArgumentException("Prices list cannot be empty.", nameof(prices));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            double subtotal = 0;
            for (int i = 0; i < prices.Count; i++)
            {
                if (prices[i] < 0)
                    throw new ArgumentException($"Price at index {i} cannot be negative.");
                subtotal += prices[i];
            }

            double tax = subtotal * 0.23;
            double shipping = quantity > 10 ? 0 : 15.0;
            double discount = subtotal > 500 ? subtotal * 0.10 : 0;
            double total = subtotal + tax + shipping - discount;

            Console.WriteLine($"[AUDIT-PDF] Currency: {currency} | Subtotal: {subtotal:F2} | Tax: {tax:F2} | Shipping: {shipping:F2} | Discount: {discount:F2} | Total: {total:F2}");

            return Math.Round(total, 2);
        }

        // 🔴 SonarQube - cross-file duplication (identical block to ReportService)
        public double AuditExcelTotal(List<double> prices, int quantity, string currency)
        {
            if (prices == null || prices.Count == 0)
                throw new ArgumentException("Prices list cannot be empty.", nameof(prices));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));

            double subtotal = 0;
            for (int i = 0; i < prices.Count; i++)
            {
                if (prices[i] < 0)
                    throw new ArgumentException($"Price at index {i} cannot be negative.");
                subtotal += prices[i];
            }

            double tax = subtotal * 0.23;
            double shipping = quantity > 10 ? 0 : 15.0;
            double discount = subtotal > 500 ? subtotal * 0.10 : 0;
            double total = subtotal + tax + shipping - discount;

            Console.WriteLine($"[AUDIT-Excel] Currency: {currency} | Subtotal: {subtotal:F2} | Tax: {tax:F2} | Shipping: {shipping:F2} | Discount: {discount:F2} | Total: {total:F2}");

            return Math.Round(total, 2);
        }
    }
}
