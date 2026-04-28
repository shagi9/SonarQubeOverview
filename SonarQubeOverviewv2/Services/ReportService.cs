namespace SonarQubeOverviewv2.Services
{
    public class ReportService
    {
        // 🔴 SonarQube - Duplicated block #1
        public double CalculatePdfReportTotal(List<double> prices, int quantity, string currency)
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

            Console.WriteLine($"[PDF] Currency: {currency} | Subtotal: {subtotal:F2} | Tax: {tax:F2} | Shipping: {shipping:F2} | Discount: {discount:F2} | Total: {total:F2}");

            return Math.Round(total, 2);
        }

        // 🔴 SonarQube - Duplicated block #2 (copy-paste of block #1)
        public double CalculateExcelReportTotal(List<double> prices, int quantity, string currency)
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

            Console.WriteLine($"[Excel] Currency: {currency} | Subtotal: {subtotal:F2} | Tax: {tax:F2} | Shipping: {shipping:F2} | Discount: {discount:F2} | Total: {total:F2}");

            return Math.Round(total, 2);
        }

        // 🔴 SonarQube - Duplicated block #3 (copy-paste of block #1)
        public double CalculateCsvReportTotal(List<double> prices, int quantity, string currency)
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

            Console.WriteLine($"[CSV] Currency: {currency} | Subtotal: {subtotal:F2} | Tax: {tax:F2} | Shipping: {shipping:F2} | Discount: {discount:F2} | Total: {total:F2}");

            return Math.Round(total, 2);
        }
    }
}
