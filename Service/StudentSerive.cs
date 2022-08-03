using Microsoft.EntityFrameworkCore;
using StudentLibrary.Data;
using StudentLibrary.Entites;
using StudentLibrary.Mapper;
using StudentLibrary.Model;

namespace StudentLibrary.Service;

public class StudentService : IStudentService
{
    private readonly ILogger<StudentService> _logger;
    private readonly StudentDbContext _context;

    public StudentService (ILogger<StudentService> logger, StudentDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<(bool IsSuccess, Exception e)> DeleteStudentIdAsync(Guid id)
    {
        try
        {
           var res = await GetStudentByIdAsync(id);
           _context.Students.Remove(res);
           await _context.SaveChangesAsync();
           _logger.LogInformation($"Student deleted");
            return (true, null);
        }
        catch (Exception e)
        {
            return (false, e);
        }
    }

    public async Task<List<StudentModel>> GetAllStudentAsync()
        => await _context.Students.Select(a => a.ToModel()).ToListAsync();

    public async Task<Student> GetStudentByIdAsync(Guid id)
    {
        return await _context.Students.FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<(bool IsSuccess, Exception e)> InsertStudentAsync(Student student)
    {
        try
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"New Student is added");
            return (true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"New Student was not added");
            return (false ,e);
        }
    }

    public async Task<(bool IsSuccess, Exception e)> UpdateStudentAsync(Student student)
    {
        try
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Student updated {student.Id}");
            return (true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"Student isnt update{student.Id}");
            return (false, e);
        }
    }
}