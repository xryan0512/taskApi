using Microsoft.EntityFrameworkCore;
using projectef.Models;

namespace proyectef;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
    public DbSet<TaskDb> Tasks { get; set; }

}
