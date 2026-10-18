namespace SonarQubeOverviewv2.Services
{
    // 🔴 Duplication: four copy-pasted invoice calculations (new code)
    public class InvoiceExportService
    {
        public decimal CalculatePdfTotal(List<decimal> amounts, decimal taxRate, string customer)
        {
            if (amounts == null || amounts.Count == 0)
                throw new ArgumentException("Amounts cannot be empty.", nameof(amounts));

            if (taxRate < 0 || taxRate > 1)
                throw new ArgumentOutOfRangeException(nameof(taxRate));

            decimal net = 0;
            foreach (var amount in amounts)
            {
                if (amount < 0)
                    throw new ArgumentException("Amount cannot be negative.");
                net += amount;
            }

            decimal tax = net * taxRate;
            decimal fee = net > 1000 ? 0 : 25m;
            decimal rebate = net > 5000 ? net * 0.05m : 0;
            decimal gross = net + tax + fee - rebate;

            Console.WriteLine($"[Pdf] Customer: {customer} | Net: {net:F2} | Tax: {tax:F2} | Fee: {fee:F2} | Rebate: {rebate:F2} | Gross: {gross:F2}");

            return Math.Round(gross, 2);
        }

        public decimal CalculateXmlTotal(List<decimal> amounts, decimal taxRate, string customer)
        {
            if (amounts == null || amounts.Count == 0)
                throw new ArgumentException("Amounts cannot be empty.", nameof(amounts));

            if (taxRate < 0 || taxRate > 1)
                throw new ArgumentOutOfRangeException(nameof(taxRate));

            decimal net = 0;
            foreach (var amount in amounts)
            {
                if (amount < 0)
                    throw new ArgumentException("Amount cannot be negative.");
                net += amount;
            }

            decimal tax = net * taxRate;
            decimal fee = net > 1000 ? 0 : 25m;
            decimal rebate = net > 5000 ? net * 0.05m : 0;
            decimal gross = net + tax + fee - rebate;

            Console.WriteLine($"[Xml] Customer: {customer} | Net: {net:F2} | Tax: {tax:F2} | Fee: {fee:F2} | Rebate: {rebate:F2} | Gross: {gross:F2}");

            return Math.Round(gross, 2);
        }

        public decimal CalculateJsonTotal(List<decimal> amounts, decimal taxRate, string customer)
        {
            if (amounts == null || amounts.Count == 0)
                throw new ArgumentException("Amounts cannot be empty.", nameof(amounts));

            if (taxRate < 0 || taxRate > 1)
                throw new ArgumentOutOfRangeException(nameof(taxRate));

            decimal net = 0;
            foreach (var amount in amounts)
            {
                if (amount < 0)
                    throw new ArgumentException("Amount cannot be negative.");
                net += amount;
            }

            decimal tax = net * taxRate;
            decimal fee = net > 1000 ? 0 : 25m;
            decimal rebate = net > 5000 ? net * 0.05m : 0;
            decimal gross = net + tax + fee - rebate;

            Console.WriteLine($"[Json] Customer: {customer} | Net: {net:F2} | Tax: {tax:F2} | Fee: {fee:F2} | Rebate: {rebate:F2} | Gross: {gross:F2}");

            return Math.Round(gross, 2);
        }

        public decimal CalculateCsvTotal(List<decimal> amounts, decimal taxRate, string customer)
        {
            if (amounts == null || amounts.Count == 0)
                throw new ArgumentException("Amounts cannot be empty.", nameof(amounts));

            if (taxRate < 0 || taxRate > 1)
                throw new ArgumentOutOfRangeException(nameof(taxRate));

            decimal net = 0;
            foreach (var amount in amounts)
            {
                if (amount < 0)
                    throw new ArgumentException("Amount cannot be negative.");
                net += amount;
            }

            decimal tax = net * taxRate;
            decimal fee = net > 1000 ? 0 : 25m;
            decimal rebate = net > 5000 ? net * 0.05m : 0;
            decimal gross = net + tax + fee - rebate;

            Console.WriteLine($"[Csv] Customer: {customer} | Net: {net:F2} | Tax: {tax:F2} | Fee: {fee:F2} | Rebate: {rebate:F2} | Gross: {gross:F2}");

            return Math.Round(gross, 2);
        }
    }
}
