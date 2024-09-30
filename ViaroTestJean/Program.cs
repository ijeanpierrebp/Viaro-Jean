using Microsoft.EntityFrameworkCore;
using ViaroTestJean.Data;
using ViaroTestJean.Repositories.Implementations;
using ViaroTestJean.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ColegioDbContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ViaroDB")));


builder.Services.AddScoped<IAlumno, AlumnoRepository>();
builder.Services.AddScoped<IAlumnoGrado, AlumnoGradoRepository>();
builder.Services.AddScoped<IGrado, GradoRepository>();
builder.Services.AddScoped<IProfesor, ProfesorRepository>();

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
