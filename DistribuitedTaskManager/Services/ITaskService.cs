using DistribuitedTaskManager.Models;

namespace DistribuitedTaskManager.Services;

public interface ITaskService
{
    List<TaskManagerTask> GetAllTasks();
    TaskManagerTask CreateTask(TaskManagerTask newTask);
}
