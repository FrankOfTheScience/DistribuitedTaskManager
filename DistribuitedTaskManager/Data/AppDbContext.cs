using DistribuitedTaskManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DistribuitedTaskManager.Data;

public class AppDbContext : DbContext
{
    public DbSet<TaskManagerTask> Tasks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}
