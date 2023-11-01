using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserServiceApi.Dto.Request;
using UserServiceApi.Service;

namespace UserServiceApi.Controllers
{
    [ApiController]
    [Route("userservice/api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateRequestDto task)
        {
            var newTask = await _taskService.CreateTaskAsync(task);
            return new ObjectResult(new { taskId = newTask.TaskId }) { StatusCode = 200 };

        }

        [HttpGet("{taskId}")]
        [Authorize]
        public async Task<IActionResult> GetTask(Guid taskId)
        {
            var task = await _taskService.GetTaskAsync(taskId);
            if (task == null)
            {
                return NotFound("Task not found.");
            }
            return Ok(task);
        }

        [HttpPut("{taskId}")]
        [Authorize]
        public async Task<IActionResult> UpdateTask(Guid taskId, [FromBody] TaskUpdateRequestDto updatedTask)
        {
            var task = await _taskService.UpdateTaskAsync(taskId, updatedTask);
            if (task == null)
            {
                return NotFound("Task not found.");
            }
            return Ok("Task updated successfully.");
        }

        [HttpDelete("{taskId}")]
        [Authorize]
        public async Task<IActionResult> DeleteTask(Guid taskId)
        {
            await _taskService.DeleteTaskAsync(taskId);
            return Ok("Task deleted successfully.");
        }
    }

}
