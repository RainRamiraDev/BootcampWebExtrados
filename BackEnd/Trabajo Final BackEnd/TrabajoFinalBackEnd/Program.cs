using CardApp.Interfaces;
using CardApp.Service;
using DataAccessApp.Dao;
using DataAccessApp.Interfaces;
using PlayerApp.Interfaces;
using PlayerApp.Service;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios antes de Build
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar DAOs
builder.Services.AddScoped<ICardDao>(provider =>
{
    return new CardDao(connectionString);
});

builder.Services.AddScoped<IUserDao>(provider =>
{
    return new UserDao(connectionString);
});

// Registrar Servicios
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<IUserService, UserService>();


// Registrar otros servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar la tubería de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
