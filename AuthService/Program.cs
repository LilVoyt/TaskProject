using AuthService.Consumers;
using AuthService.Data;
using AuthService.Repositories;
using AuthService.Services;
using AuthService.Services.Interfaces;
using Consumers;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<IDataContext, DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();

    x.AddConsumer<UserRoleChangedConsumer>();
    x.AddConsumer<UserExistingCheckConsumer>();

    x.AddRequestClient<UserExistingCheck>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("user-role-changed", e =>
        {
            e.ConfigureConsumer<UserRoleChangedConsumer>(context);
        });
        cfg.ReceiveEndpoint("user-existence-check", e =>
        {
            e.ConfigureConsumer<UserExistingCheckConsumer>(context);
        });
    });

});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.RequireHttpsMetadata = false;
    option.SaveToken = true;
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("myHardSecret7asdasdasdasd7777777777")),
        ValidateAudience = false,
        ValidateIssuer = false,
    };
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin")
    );


//services injetion
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<ITokenProvider,TokenProvider>();
builder.Services.AddScoped<ILoginUser, LoginUser>();
builder.Services.AddScoped<IRegisterUser, RegisterUser>();

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
