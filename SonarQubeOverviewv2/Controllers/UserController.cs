using Microsoft.AspNetCore.Mvc;
using SonarQubeOverviewv2.Models;
using SonarQubeOverviewv2.Services;

namespace SonarQubeOverviewv2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // ❌ No dependency injection
        private readonly UserService _service = new UserService();

        [HttpPost("process")]
        public IActionResult Process(List<User> users)
        {
            _service.ProcessUsers(users);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var result = _service.Login(user.Name, user.Password);
            return Ok(result);
        }
    }
}