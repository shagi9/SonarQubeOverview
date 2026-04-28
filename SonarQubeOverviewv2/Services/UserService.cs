using SonarQubeOverviewv2.Models;

namespace SonarQubeOverviewv2.Services
{
    public class UserService
    {
        // 🟢 analyzers + 🔴 SonarQube
        // Null reference risk
        public void ProcessUsers(List<User> users)
        {
            foreach (var user in users) // ⚠️ possible null reference
            {
                Console.WriteLine(user.Name.ToLower()); // ⚠️ possible null dereference
            }
        }

        // 🔴 SonarQube (security)
        // Hardcoded credentials
        public bool Login(string username, string password)
        {
            if (username == "admin" && password == "123456") // 🔐 vulnerability
            {
                return true;
            }
            return false;
        }

        // 🔴 SonarQube (duplication)
        public void PrintLogs()
        {
            LogBlock();
            LogBlock(); // duplicated logic
        }

        private void LogBlock()
        {
            Console.WriteLine("Start");
            Console.WriteLine("Processing...");
            Console.WriteLine("End");
        }

        // 🔴 SonarQube (magic numbers)
        public double CalculatePrice(double price)
        {
            return price * 1.23 + 10; // 🧹 magic numbers
        }

        // 🟢 analyzers (performance hint)
        public int Sum(List<int> numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++) // ⚠️ possible inefficiency
            {
                sum += numbers[i];
            }

            return sum;
        }

        // 🟢 analyzers
        public void DoNothing()
        {
            int x = 42; // ⚠️ unused variable
        }

        // 🔴 SonarQube (exception handling)
        public void ProcessData()
        {
            try
            {
                DoWork();
            }
            catch (Exception)
            {
                // ❌ swallowed exception
            }
        }

        // 🔴 SonarQube (complexity)
        public int ComplexCalculation(int x)
        {
            if (x > 0)
            {
                if (x > 10)
                {
                    if (x > 100)
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        // 🔴 SonarQube (security: injection risk)
        public string BuildQuery(string name)
        {
            return "SELECT * FROM Users WHERE Name = '" + name + "'"; // ❌ SQL injection risk
        }

        private void DoWork()
        {
            throw new Exception("fail");
        }
    }
}