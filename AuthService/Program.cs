using AuthService.Data;
using AuthService.Repositories;
using AuthService.Services;
using AuthService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddAutoMapper(typeof(Program));


//services injetion
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ITokenProvider,TokenProvider>();
builder.Services.AddScoped<ILoginUser, LoginUser>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
