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

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IUserDao>(provider =>
//{
//    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//    return new UserDao(connectionString);
//});


//------------------ DAO ----------------------------------

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddSingleton<IUserDao>(provider =>
{
    //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new UserDao(connectionString);
});


builder.Services.AddSingleton<ILibroDao>(provider =>
{
    //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new LibroDao(connectionString);
});

builder.Services.AddSingleton<IPrestamoDao>(provider =>
{
    //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new PrestamoDao(connectionString);
});


//------------------ SERVICE ----------------------------------


builder.Services.AddScoped<IPrestamoService, PrestamoService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ILibroService, LibroService>();





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



//builder.Services.AddScoped<IUserService, UserService>();

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