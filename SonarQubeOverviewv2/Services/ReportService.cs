namespace SonarQubeOverviewv2.Services
{
    public class ReportService
    {
        // 🔴 SonarQube - Duplicated block #1
        public void GeneratePdfReport(string title, List<string> items)
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

        // 🔴 SonarQube - Duplicated block #2 (same logic copy-pasted)
        public void GenerateExcelReport(string title, List<string> items)
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

        // 🔴 SonarQube - Duplicated block #3 (same logic copy-pasted again)
        public void GenerateCsvReport(string title, List<string> items)
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
    }
}
