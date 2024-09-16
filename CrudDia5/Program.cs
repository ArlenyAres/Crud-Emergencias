using CrudDia5.DTOs;
using CrudDia5.Models;
using CrudDia5.Services;

using CrudDia5.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// services
builder.Services.AddScoped<IAeronaveService, AeronaveService>();
builder.Services.AddScoped<IPilotoService, PilotoService>();
builder.Services.AddScoped<IMisionEmerService, MisionEmergenciaService>();


// contexto database con sql server 

builder.Services.AddDbContext<EmergenciaDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});



//Validadores

builder.Services.AddScoped<IValidator<AeronaveDto>, AeronaveInsertValidator>();
builder.Services.AddScoped<IValidator<PilotoInsertDto>, PilotoInsertValidator>();
builder.Services.AddScoped<IValidator<PilotoUpdateDto>, PilotoUpdateValidator>();
builder.Services.AddScoped<IValidator<MisionEmergenciaInsertDto>, MisionEmergenciaInsertValidator>();
builder.Services.AddScoped<IValidator<MisionEmergenciaUpdateDto>, MisionEmergenciaUpdateValidator>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
   

app.MapControllerRoute(
    name: "aeronave",
    pattern: "Aeronave/{action=listaAeronaves}/{id?}",
    defaults: new { controller = "Aeronave" });

app.MapControllerRoute(
    name: "misionEmergencia",
    pattern: "MisionEmergencia/{action=ListaEmergencias}/{id?}",
    defaults: new { controller = "MisionEmergencia" });

app.Run();
