using UserDaoLib.Daos.Interfaces;
using UserDaoLib.Daos;
using UserDaoLib.Services.Interfaces;
using UserDaoLib.Services;
using UserDaoLib.Dto.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Configuration;
using RefreshTokenApp.Service.Interface;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

//------------------ DAO ----------------------------------

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddSingleton<IUserDao>(provider =>
{
    return new UserDao(connectionString);
});

builder.Services.AddSingleton<ILibroDao>(provider =>
{
    return new LibroDao(connectionString);
});

builder.Services.AddSingleton<IPrestamoDao>(provider =>
{
    return new PrestamoDao(connectionString);
});

builder.Services.AddSingleton<IRefreshTokenDao>(provider =>
{
    return new RefreshTokenDao(connectionString);
});

//------------------ SERVICE ----------------------------------


builder.Services.AddScoped<IPrestamoService, PrestamoService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ILibroService, LibroService>();

builder.Services.AddScoped<IRefreshTokenService, RefreshTokenService>();


//--------
builder.Services.Configure<KeysConfiguration>(builder.Configuration.GetSection("Jwt"));
//--------






//------------------ VALIDATIONS ----------------------------------


builder.Services.AddValidatorsFromAssemblyContaining<UserDtoValidations>();

builder.Services.AddValidatorsFromAssemblyContaining<LibroDtoValidations>();

builder.Services.AddValidatorsFromAssemblyContaining<PrestamoDtoValidations>();




builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("*");
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
        };
    });




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();
app.Run();