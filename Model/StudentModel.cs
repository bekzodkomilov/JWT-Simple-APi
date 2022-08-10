using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace StudentLibrary.Model;

public class StudentModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}