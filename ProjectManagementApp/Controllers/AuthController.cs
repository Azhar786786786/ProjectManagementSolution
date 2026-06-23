using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public string Login()
        {
            return "Login Successfully";
        }
        [HttpPost("register")]
        public string Register()
        {
            return "Register Successfully";
        }
    }
}
