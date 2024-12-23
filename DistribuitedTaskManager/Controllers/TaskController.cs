using DistribuitedTaskManager.Models;
using DistribuitedTaskManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace DistribuitedTaskManager.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly IDistributedCache _cache;

    public TaskController(ITaskService taskService, IDistributedCache cache)
    {
        _taskService = taskService;
        _cache = cache;
    }

    [HttpGet]
    public ActionResult<List<TaskManagerTask>> GetTasks()
        => Ok(_taskService.GetAllTasks());

    [HttpGet]
    public async Task<IActionResult> GetTaskByIdCached([FromQuery] string id)
    {
        string cacheKey = $"task-{id}";
        var cachedData = await _cache.GetAsync(cacheKey);

        if (cachedData is null)
        {
            var task = _taskService.GetTaskById(int.Parse(id));

            var serializedTask = JsonSerializer.SerializeToUtf8Bytes(task);
            await _cache.SetAsync(cacheKey, serializedTask, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });
        }
        return Ok(cachedData);
    }

    [HttpPost]
    public ActionResult<Task> CreateTask([FromBody] TaskManagerTask newTask)
    {
        var createdTask = _taskService.CreateTask(newTask);
        return CreatedAtAction(nameof(GetTasks), createdTask);
    }
}