using System.Security.Cryptography;
using System.Text;

namespace SonarQubeOverviewv2.Services
{
    public class SecurityService
    {
        // 🔴 SonarQube S2068 - Hardcoded credentials
        private const string DbPassword = "SuperSecret123!";
        private const string ApiKey = "hardcoded-api-key-abc123";

        // 🔴 SonarQube S3649 - SQL Injection (query returned for execution elsewhere)
        public string GetUserQuery(string username)
        {
            return "SELECT * FROM Users WHERE Username = '" + username + "'";
        }

        // 🔴 SonarQube S5547 - Weak cryptography (MD5)
        public string HashPassword(string password)
        {
            using var md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes);
        }

        // 🔴 SonarQube S2245 - Weak random number generator used for security
        public string GenerateToken()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        // 🔴 SonarQube S5332 - HTTP (not HTTPS) used
        public async Task FetchData()
        {
            var client = new HttpClient();
            await client.GetStringAsync("http://example.com/api/data");
        }

        // 🔴 SonarQube S2077 - SQL query constructed from user input
        public string DeleteUserQuery(string userId)
        {
            return "DELETE FROM Users WHERE Id = " + userId;
        }
    }
}
