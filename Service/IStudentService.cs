using StudentLibrary.Entites;
using StudentLibrary.Model;

namespace StudentLibrary.Service;

public interface IStudentService
{
    Task<Student> GetStudentByIdAsync(Guid id);
    Task<List<StudentModel>> GetAllStudentAsync();
    Task<(bool IsSuccess, Exception e)> InsertStudentAsync(Student student);
    Task<(bool IsSuccess, Exception e)> UpdateStudentAsync(Student student);
    Task<(bool IsSuccess, Exception e)> DeleteStudentIdAsync(Guid id);
}