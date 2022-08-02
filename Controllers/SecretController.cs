using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentLibrary.Service;

namespace StudentLibrary.Controller;

[ApiController]
[Route("/api/controller")]
[Authorize]
public class SecretController : ControllerBase
{
    private readonly ILogger<SecretController> _logger;
    private readonly IStudentService _service;

    public SecretController(ILogger<SecretController> logger, IStudentService service)
    {
        _logger = logger;
        _service = service;
    }
    [HttpGet("/secret")]
    public IActionResult Get()
        => Ok("It is a secret only for admin");

    [HttpGet("/name")]
    public IActionResult GetMe()
    {
        var student = _service.GetAllStudentAsync();
        return Ok(student);
    }
}