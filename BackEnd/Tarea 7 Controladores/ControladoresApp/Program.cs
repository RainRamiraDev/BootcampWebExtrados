using UserDaoLib.Daos.Interfaces;
using UserDaoLib.Daos;
using UserDaoLib.Services.Interfaces;
using UserDaoLib.Services;
using UserDaoLib.Dto.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;

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



builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
