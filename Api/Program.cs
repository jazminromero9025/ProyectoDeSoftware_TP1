using Application.Interfaces;
using Application.Services;
using Infraestructure.Data;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
// Registrar el Repositorio (Capa de Infraestructura)
builder.Services.AddScoped<ISeatRepository, SeatRepository>();

// Registrar el Servicio (Capa de Aplicación)
builder.Services.AddScoped<ISeatService, SeatService>();

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

// ── SEEDER ──────────────────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
    DataSeeder.Seed(db);
}
// ────────────────────────────────────────────────────────

app.Run();
