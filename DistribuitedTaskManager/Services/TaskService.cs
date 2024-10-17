using DistribuitedTaskManager.Data;
using DistribuitedTaskManager.Models;

namespace DistribuitedTaskManager.Services;

public class TaskService : ITaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public List<TaskManagerTask> GetAllTasks()
    {
        return _context.Tasks.ToList();
    }

    public TaskManagerTask CreateTask(TaskManagerTask newTask)
    {
        _context.Tasks.Add(newTask);
        _context.SaveChanges();
        return newTask;
    }
}
