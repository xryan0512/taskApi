using Microsoft.EntityFrameworkCore;
using TaskListApi.Models;

namespace TaskListApi.Data
{
    public class TaskListContext : DbContext
    {
        public TaskListContext(DbContextOptions<TaskListContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}