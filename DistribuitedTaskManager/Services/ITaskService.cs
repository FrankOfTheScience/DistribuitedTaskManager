using DistribuitedTaskManager.Models;

namespace DistribuitedTaskManager.Services;

public interface ITaskService
{
    Task<IEnumerable<TaskManagerTask>> GetAllTasks();
    Task<TaskManagerTask> CreateTask(TaskManagerTask newTask);
}
