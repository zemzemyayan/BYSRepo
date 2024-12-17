using Bussiness.Abstarct;
using Bussiness.Concrete;
using DataAccess.Abstarct;
using DataAccess.Concrete;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.// Repository sýnýflarýný kayýt et
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

// Manager sýnýflarýný kayýt et
builder.Services.AddScoped<ICourseService, CourseManager>();
builder.Services.AddScoped<IInstructorService, InstructorManager>();
builder.Services.AddScoped<IStudentCourseService, StudentCourseManager>();
builder.Services.AddScoped<IStudentService, StudentManager>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<bysContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
