using Microsoft.EntityFrameworkCore;
using PruebaBackend.Core.Application.Interfaces;
using PruebaBackend.Core.Application.UseCases;
using PruebaBackend.Core.Domain.Interfaces;
using PruebaBackend.Infrastructure.Persistence;
using PruebaBackend.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations(); // Habilitar anotaciones de Swagger
});

var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(Path.Combine("API", "appsettings.json"), optional: false)
    .Build();

var connectionString = configurationBuilder.GetConnectionString("cnStringBdPostgreSql");
builder.Services.AddNpgsql<ApplicationDbContext>(connectionString);

builder.Services.AddScoped<IAgencyUseCase, AgencyUseCase>();
builder.Services.AddScoped<IHotelUseCase, HotelUseCase>();
builder.Services.AddScoped<IRoomUseCase, RoomUseCase>();
builder.Services.AddScoped<IPreferredHotelUseCase, PreferredHotelUseCase>();
builder.Services.AddScoped<ITravelerUseCase, TravelerUseCase>();
builder.Services.AddScoped<IReservationUseCase, ReservationUseCase>();
builder.Services.AddScoped<IAgencyRepository, AgencyRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<ITravelerRepository, TravelerRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IPreferredHotelRepository, PreferredHotelRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IEmergencyContactRepository, EmergencyContactRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    try
    {
        using(var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            Console.WriteLine("Conexión a base de datos verificada correctamente");
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Error al verificar la conexión a la base de datos: {ex.Message}");
        throw; // Re-lanza la excepción para ver el error completo
    }

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
