using Microsoft.AspNetCore.Mvc;
using System.Linq;
using webapi.Data;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // POST api/user/register
        [HttpPost("register")]
        public ActionResult Register(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return BadRequest("Email already exists.");
            }

            if (_context.Users.Any(u => u.Username == user.Username))
            {
                return BadRequest("Username already exists.");
            }

            

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully.");
        }

        // POST api/user/login
        [HttpPost("login")]
        public ActionResult Login(LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(new { message = "Logged in successfully.", user });
        }

    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
