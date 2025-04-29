global using StudentEnrollment.Models;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Services.StudentService;
using StudentEnrollment;
using StudentEnrollment.Services.CourseService;
using StudentEnrollment.Data;
using StudentEnrollment.Services.EnrollmentService;
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAutoMapper(typeof(Program));

//register Db context
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();     
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
