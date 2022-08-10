using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentLibrary.Mapper;
using StudentLibrary.Model;
using StudentLibrary.Service;

namespace StudentLibrary.Controller;

[ApiController]
[Route("/api/controller")]
[Authorize]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly IStudentService _service;

    public StudentController(ILogger<StudentController> logger, IStudentService service)
    {
        _logger = logger;
        _service = service;
    }

    // [HttpPost("/addstudent")]
    // public async Task<IActionResult> AddStudent([FromForm] StudentModel model)
    // {
    //     if(ModelState.IsValid)
    //     {
    //         await _service.InsertStudentAsync(model.ToEntity());
    //         return Ok(model);
    //     }
    //     return BadRequest();
    // }

    [HttpGet("/getallstudent")]
    public async Task<IActionResult> GetAllStudent()
    {
        var res = await _service.GetAllStudentAsync();
        return Ok(res);
    }

    [HttpGet("/getstudentby{id}")]
    public async Task<IActionResult> GetStudentById(Guid id)
    {
        var res = await _service.GetStudentByIdAsync(id);
        return Ok(res);
    }

    [HttpDelete("/deletestudentby/{id}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        var res = await _service.DeleteStudentIdAsync(id);
        return Ok(res);
    }

    [HttpPut("/update/{id}")]
    public async Task<IActionResult> Update([FromForm]StudentModel model,Guid id)
    {
        var student =  await _service.GetStudentByIdAsync(id);
        student.FirstName = model.FirstName;
        student.LastName = model.LastName;
        
        var res = await _service.UpdateStudentAsync(student);
        var error = !res.IsSuccess;
        var massage = res.e is null ? "Success" : res.e.Message;
        return Ok(new{error,massage});
    }
}