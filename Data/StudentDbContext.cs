using Microsoft.EntityFrameworkCore;
using StudentLibrary.Entites;

namespace StudentLibrary.Data;

public class StudentDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

     public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>() 
                            .HasIndex(s => s.Username)
                            .IsUnique();
    }

}