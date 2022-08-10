using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentLibrary.Data;
using StudentLibrary.Entites;
using StudentLibrary.Mapper;
using StudentLibrary.Model;
using StudentLibrary.Service;

namespace StudentLibrary.Controller;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IStudentService _service;
    private readonly ILogger<AuthController> _logger;
    private readonly StudentDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(ILogger<AuthController> logger, StudentDbContext context, IConfiguration config, IStudentService service)
    {
        _service = service;
        _logger = logger;
        _context = context;
        _config = config;
    }
    
    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromForm] Student newUser)
    {
        var (hash, salt) = generateHash(newUser.Password); 
        var user = await _service.InsertStudentAsync(newUser);
        return Ok(user);
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login(Register login)
    {
        var user = await _context.Students.FirstOrDefaultAsync(u => u.Username == login.Username);
        if(user == default)
        {
            return BadRequest("Unaqa user yo'q");
        }

        var p = verifyPassword(login.Password, user.PasswordHash, user.PasswordSalt);
        if(!p)
        {
            return BadRequest("Password hato");
        }
        var token = createToken(user);
        return Ok(token);
    }

    private string createToken(Student user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JwtAuth:Token").Value));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims, 
            expires: DateTime.Now.AddDays(1), 
            signingCredentials: cred);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    private (byte[] PasswordHash, byte[] PasswordSalt) generateHash(string password)
    {
        byte[] passwordHash;
        byte[] passwordSalt;
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        return (passwordHash, passwordSalt);
    }

    private bool verifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
        }
    }
}
