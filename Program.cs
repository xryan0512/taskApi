using Microsoft.EntityFrameworkCore;
using TaskListApi.Data;
using TaskListApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<TaskListContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TaskListDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();