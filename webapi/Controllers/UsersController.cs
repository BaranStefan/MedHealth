// Controllers/AccountController.cs

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourProjectName.Data;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        if (dto.Password != dto.ConfirmPassword)
            return BadRequest("Passwords do not match.");

        var userExists = await _context.Users.AnyAsync(u => u.Username == dto.Username || u.Email == dto.Email);
        if (userExists)
            return BadRequest("User already exists.");

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = dto.Password  // Store the password as plain text (HIGHLY INSECURE!)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new { Message = "Registration successful" });
    }
}

public class RegisterDto
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
}
