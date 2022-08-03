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
            LastName = model.LastName,
            FirstName = model.FirstName
        };

    public static StudentModel ToModel(this Student student)
        => new StudentModel
        {
            Id = student.Id,
            LastName = student.LastName,
            FirstName = student.FirstName
        };
}