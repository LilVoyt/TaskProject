using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskService.Entites;
using TaskService.Repositories;

namespace TaskService.Controllers
{
    [Route("task")]
    [ApiController]
    public class TaskController(TaskRepository taskRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTestData()
        {
            await taskRepository.GetAllTasksAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(TaskEntity taskEntity)
        {
            await taskRepository.AddTaskAsync(taskEntity);
            return Ok();
        }
    }
}
