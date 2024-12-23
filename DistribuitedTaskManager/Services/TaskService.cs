using DistribuitedTaskManager.Models;
using DistribuitedTaskManager.Repositories;

namespace DistribuitedTaskManager.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository repository)
        => _taskRepository = repository;

    public async Task<IEnumerable<TaskManagerTask>> GetAllTasks()
        => await _taskRepository.GetAllTasks();

    public async Task<TaskManagerTask> CreateTask(TaskManagerTask newTask)
        => await _taskRepository.CreateTask(newTask);
}
