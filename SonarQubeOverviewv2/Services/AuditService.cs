namespace SonarQubeOverviewv2.Services
{
    public class AuditService
    {
        // 🔴 SonarQube - cross-file duplication (same block as ReportService)
        public void LogAuditPdf(string title, List<string> items)
        {
            Console.WriteLine("=== Report ===");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Date: {DateTime.Now}");
            Console.WriteLine($"Total items: {items.Count}");
            foreach (var item in items)
            {
                Console.WriteLine($" - {item}");
            }
            Console.WriteLine("=== End ===");
            Console.WriteLine();
        }

        // 🔴 SonarQube - cross-file duplication (same block as ReportService)
        public void LogAuditExcel(string title, List<string> items)
        {
            Console.WriteLine("=== Report ===");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Date: {DateTime.Now}");
            Console.WriteLine($"Total items: {items.Count}");
            foreach (var item in items)
            {
                Console.WriteLine($" - {item}");
            }
            Console.WriteLine("=== End ===");
            Console.WriteLine();
        }

        public void RecordUserAction(string username, string action)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.", nameof(username));

            if (string.IsNullOrWhiteSpace(action))
                throw new ArgumentException("Action cannot be empty.", nameof(action));

            double amount = 0;
            double tax = amount * 0.23;
            double finalAmount = amount + tax;
            Console.WriteLine($"[AUDIT] User: {username} | Action: {action} | Amount: {finalAmount:F2}");
        }

        public void RecordSystemEvent(string source, string action)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentException("Source cannot be empty.", nameof(source));

            if (string.IsNullOrWhiteSpace(action))
                throw new ArgumentException("Action cannot be empty.", nameof(action));

            double amount = 0;
            double tax = amount * 0.23;
            double finalAmount = amount + tax;
            Console.WriteLine($"[SYSTEM] Source: {source} | Action: {action} | Amount: {finalAmount:F2}");
        }
    }
}
