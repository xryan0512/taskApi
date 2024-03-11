using Microsoft.EntityFrameworkCore;
using projectef.Models;
using proyectef;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PostgresSQLConnection");
builder.Services.AddDbContext<TaskContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();


//Obtener todas las tareas
app.MapGet("/tasks", async (TaskContext db) => await db.Tasks.ToListAsync());

//Obtener una tarea por ID
app.MapGet("/task/{id:int}", async (int id, TaskContext db) =>
{
    return await db.Tasks.FindAsync(id)
    is TaskDb task ? Results.Ok(task) : Results.NotFound();
});

//Obtener una tarea por ID
app.MapPut("/task/{id:int}", async (int id, TaskDb task, TaskContext db) =>
{
    if (task.Id != id)
        return Results.BadRequest();

    var taskResult = await db.Tasks.FindAsync(id);
    if (taskResult is null) return Results.NotFound();

    taskResult.Name = task.Name;
    taskResult.Description = task.Description;

    await db.SaveChangesAsync();

    return Results.Ok(task);
});

//Elimininar una tarea por ID
app.MapDelete("/task/{id:int}", async (int id, TaskContext db) =>
{
    var task = await db.Tasks.FindAsync(id);
    if (task is null) return Results.NotFound();

    db.Tasks.Remove(task);
    await db.SaveChangesAsync();

    return Results.NoContent();
});
//Agregar una Tarea
app.MapPost("/task", async (TaskDb task, TaskContext db) =>
{
    db.Tasks.Add(task);
    await db.SaveChangesAsync();
    return Results.Created($"/task/{task.Id}", task);
});


app.Run();
