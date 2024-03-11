using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace proyectef;

public class TaskContext : DbContext
{
    public DbSet<TaskDb> Tasks { get; set; }
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
}
