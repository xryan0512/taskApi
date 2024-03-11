using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectef;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TaskContext>(p => p.UseInMemoryDatabase("TasksDB"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] TaskContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria" + dbContext.Database.IsInMemory());
});

app.Run();
