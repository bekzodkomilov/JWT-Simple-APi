namespace StudentLibrary.Entites;

public class Student
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}