using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.Data;
using ProjectManagementApp.DTOs.AuthDTO;
using ProjectManagementApp.Helpers.JWT;
using ProjectManagementApp.Models;

namespace ProjectManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //[HttpPost("login")]
        //public string Login()
        //{
        //    return "Login Successfully";
        //}
        //[HttpPost("register")]
        //public string Register()
        //{
        //    return "Register Successfully";
        //}

        private readonly ApplicationDbContext _dbContext;
        private readonly JWTHelper _jwtHelper;

        public AuthController(ApplicationDbContext dbContext, JWTHelper jwtHelper)
        {
            _dbContext = dbContext;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserName == loginDTO.UserName);

            if (user == null)
            {
                return BadRequest("User does not exist");
            }


            if (!VerifyPassword(loginDTO.Password, user.HashedPassword))
            {
                return BadRequest("Username or Password is Invalid");
            }

            var roles = await _dbContext.UserRoles
                .Where(ur => ur.UserId == user.UserId)
                .Select(ur => ur.Role!.RoleName)
                .ToListAsync();
            string token = _jwtHelper.GenerateToken(user, roles);

            var response = new AuthResponseDTO
            {
                Token = token,
                Username = user.UserName,
                Email = user.UserEmail,
                ExpiresIn = DateTime.UtcNow.AddMinutes(120),
                Roles = roles
            };

            return Ok(response);
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDTO userDTO)
        {
            //unique email
            if (await _dbContext.Users.AnyAsync(u => u.UserEmail == userDTO.Email))
            {
                return BadRequest("User Already Exists");
            }


            var user = new User
            {
                UserEmail = userDTO.Email,
                UserName = userDTO.UserName,
                HashedPassword = HashPassword(userDTO.Password),
            };

            await _dbContext.Users.AddAsync(user);

            var defaultRole = await _dbContext.Roles.FirstOrDefaultAsync(role => role.RoleName == "Developer");

            if (defaultRole != null)
            {
                var newUserRole = new UserRole
                {
                    User = user,
                    Role = defaultRole
                };
                await _dbContext.UserRoles.AddAsync(newUserRole);
            }


            await _dbContext.SaveChangesAsync();

            return Ok(user);
        }


        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult> GetCurrentUser()
        {
            //token -> userid
            var userid = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);

            if (userid == null)
            {
                return Unauthorized();
            }

            int id = int.Parse(userid.Value);

            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserId == id);
            return Ok(user);
        }
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string text, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(text, hash);
        }
    }
}
