using Microsoft.EntityFrameworkCore;
using StudentLibrary.Data;
using StudentLibrary.Service;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<StudentDbContext>(options
//     => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentDbContext>(options =>
{
    options.UseSqlite("Data Source=Data/app.db");
},ServiceLifetime.Singleton);
builder.Services.AddSingleton<StudentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
