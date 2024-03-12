using Microsoft.EntityFrameworkCore;
using TaskListApi.Data;
using TaskListApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<TaskListContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TaskListDatabase")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
    builder => builder.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin"); // Use the CORS policy

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();