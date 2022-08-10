using System;
using StudentLibrary.Entites;
using StudentLibrary.Model;

namespace StudentLibrary.Mapper;

public static class StudentMapper
{
    public static Student ToEntity(this StudentModel model)
        => new Student()
        {
            Id = Guid.NewGuid(),
            Username = model.Username,
            Password = model.Password,
            LastName = model.LastName,
            FirstName = model.FirstName
        };

    public static StudentModel ToModel(this Student student)
        => new StudentModel
        {
            Username = student.Username,
            Password = student.Password,
            LastName = student.LastName,
            FirstName = student.FirstName
        };
}