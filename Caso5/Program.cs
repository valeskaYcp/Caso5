using Caso5_Gestion_de_producci_n.Repositorios;
using Caso5.Models;
using Caso5.Repositorios.Implementaciones;
using Caso5.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext con PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar UnitOfWork y servicios
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ProduccionService>();
//builder.Services.AddScoped<CalidadService>();
//builder.Services.AddScoped<InventarioService>();
//builder.Services.AddScoped<ProductoService>();
//builder.Services.AddScoped<ProveedorService>();

var app = builder.Build();

// Swagger siempre disponible
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 

app.Run();