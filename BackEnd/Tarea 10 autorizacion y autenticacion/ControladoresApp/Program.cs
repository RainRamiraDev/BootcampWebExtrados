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

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserDao>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new UserDao(connectionString);
});


builder.Services.AddValidatorsFromAssemblyContaining<UserDtoValidations>();

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
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "yourco.com",
            ValidAudience = "yourco",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super_Secret_Key_With_More_Than_32_Characters!"))
        };
    });



builder.Services.AddScoped<IUserService, UserService>();

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
