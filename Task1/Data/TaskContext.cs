using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
        }
    }
}
