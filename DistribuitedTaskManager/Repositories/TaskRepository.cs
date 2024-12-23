using DistribuitedTaskManager.Data;
using DistribuitedTaskManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DistribuitedTaskManager.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
        => _context = context;

    public async Task<IEnumerable<TaskManagerTask>> GetAllTasks() 
        => await _context.Tasks.ToListAsync();

    public async Task<TaskManagerTask?> GetTaskById(int id) 
        => await _context.Tasks.FindAsync(id);

    public async Task<TaskManagerTask?> GetTaskByName(string name)
        => await _context.Tasks.Where(t => t.Name == name).FirstOrDefaultAsync();

    public async Task<TaskManagerTask> CreateTask(TaskManagerTask task)
    {
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<TaskManagerTask> UpdateTask(TaskManagerTask task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}

