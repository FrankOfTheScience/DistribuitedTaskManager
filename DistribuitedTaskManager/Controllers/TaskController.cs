using DistribuitedTaskManager.Models;
using DistribuitedTaskManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DistribuitedTaskManager.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
        => _taskService = taskService;

    [HttpGet]
    public ActionResult<List<TaskManagerTask>> GetTasks()
    {
        return Ok(_taskService.GetAllTasks());
    }

    [HttpPost]
    public ActionResult<Task> CreateTask([FromBody] TaskManagerTask newTask)
    {
        var createdTask = _taskService.CreateTask(newTask);
        return CreatedAtAction(nameof(GetTasks), createdTask);
    }
}