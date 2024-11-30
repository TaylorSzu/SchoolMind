using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using School_Mind.Data;
using School_Mind.Models;
using School_Mind.Repository;
using School_Mind.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddJsonOptions(opt => {
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

//conexão entre o Banco de Dados e o projeto
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SchoolMindContext>(opt => opt.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<IAccountRepository ,AccountService>();
builder.Services.AddScoped<IClassRepository, ClassService>();
builder.Services.AddScoped<ICalendarRepository, CalendarService>();
builder.Services.AddScoped<ITeachingMaterialRepository, TeachingMaterialService>();
builder.Services.AddScoped<IStudentProfileRepository, StudentService>();

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
