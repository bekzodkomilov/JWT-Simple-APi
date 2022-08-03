using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace StudentLibrary.Model;

public class StudentModel
{
    public Guid Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
}