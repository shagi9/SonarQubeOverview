using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace SonarQubeOverviewv2.Controllers
{
    // 🔴 Vulnerabilities: user input flows straight into dangerous APIs (taint analysis)
    [ApiController]
    [Route("[controller]")]
    public class SecurityDemoController : ControllerBase
    {
        private readonly ILogger<SecurityDemoController> _logger;

        public SecurityDemoController(ILogger<SecurityDemoController> logger)
        {
            _logger = logger;
        }

        // Path traversal: name = "../../appsettings.json"
        [HttpGet("file")]
        public IActionResult ReadFile(string name)
        {
            var content = System.IO.File.ReadAllText(Path.Combine("uploads", name));
            return Ok(content);
        }

        // OS command injection: host = "127.0.0.1 && whoami"
        [HttpGet("ping")]
        public IActionResult Ping(string host)
        {
            Process.Start("cmd.exe", "/c ping " + host);
            return Ok();
        }

        // Open redirect: returnUrl = "https://evil.example"
        [HttpGet("go")]
        public IActionResult Go(string returnUrl)
        {
            return Redirect(returnUrl);
        }

        // Server-side request forgery (SSRF)
        [HttpGet("fetch")]
        public async Task<IActionResult> Fetch(string url)
        {
            using var client = new HttpClient();
            var body = await client.GetStringAsync(url);
            return Ok(body);
        }

        // Log injection
        [HttpGet("log")]
        public IActionResult Log(string user)
        {
            _logger.LogInformation("Login attempt by " + user);
            return Ok();
        }

        // Regex injection (ReDoS)
        [HttpGet("match")]
        public IActionResult Match(string pattern, string input)
        {
            return Ok(Regex.IsMatch(input, pattern));
        }
    }
}
