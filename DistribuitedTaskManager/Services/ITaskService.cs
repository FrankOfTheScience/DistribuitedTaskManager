using DistribuitedTaskManager.Models;

namespace DistribuitedTaskManager.Services;

public interface ITaskService
{
    Task<IEnumerable<TaskManagerTask>> GetAllTasks();
    Task<TaskManagerTask> GetTaskById(int id);
    Task<TaskManagerTask> CreateTask(TaskManagerTask newTask);
}
