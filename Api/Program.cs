using Application.Interfaces;
using Application.Services;
using Infraestructure.Data;
using Infraestructure.Queries;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Capa de Infraestructura: Las Queries y Commands
// El Repositorio las necesita para funcionar
builder.Services.AddScoped<GetSeatsBySectorQuery>();

//Capa de Infraestructura: Repositorios
// Le decimos: "Cuando alguien pida ISeatRepository, dale un SeatRepository"
builder.Services.AddScoped<ISeatRepository, SeatRepository>();


// Capa de Application: Servicios
// Le decimos: "Cuando alguien pida ISeatService, dale un SeatService"
builder.Services.AddScoped<ISeatService, SeatService>();



// Add services to the container.

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
