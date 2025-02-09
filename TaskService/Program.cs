using MongoDB.Driver;
using TaskService.Data;
using TaskService.Repositories;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration["MongoDB:ConnectionString"];
var mongoClient = new MongoClient(mongoConnectionString);

builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddScoped<MongoDBContext>();
builder.Services.AddScoped<TaskRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "MongoDB Connected!");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
