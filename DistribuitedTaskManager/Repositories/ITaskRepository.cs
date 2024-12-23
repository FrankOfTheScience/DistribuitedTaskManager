using DistribuitedTaskManager.Models;

namespace DistribuitedTaskManager.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<TaskManagerTask>> GetAllTasks();
    Task<TaskManagerTask> CreateTask(TaskManagerTask newTask);
    Task<TaskManagerTask> UpdateTask(TaskManagerTask updatedTask);
    Task DeleteTask(int taskId);
    Task<TaskManagerTask> GetTaskById(int taskId);
    Task<TaskManagerTask> GetTaskByName(string name);
}
