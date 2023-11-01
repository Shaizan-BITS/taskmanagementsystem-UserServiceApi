using Microsoft.EntityFrameworkCore;
using UserServiceApi.Database;
using UserServiceApi.Dto.Request;

namespace UserServiceApi.Service
{
    public class TaskService
    {
        private readonly UserServiceDbContext _context;

        public TaskService(UserServiceDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Task> CreateTaskAsync(TaskCreateRequestDto task)
        {
            var newTask = new Models.Task
            {
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                AssigneeId = task.AssigneeId,
                Category = task.Category,
                CreatorId = task.CreatorId
            };

            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();
            return newTask;
        }

        public async Task<Models.Task> GetTaskAsync(Guid taskId)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == taskId);
        }

        public async Task<Models.Task> UpdateTaskAsync(Guid taskId, TaskUpdateRequestDto updatedTask)
        {
            var existingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == taskId);

            if (existingTask == null)
            {
                return null; // Task not found
            }

            // Update task properties if the corresponding field is present in the updatedTask
            if (!string.IsNullOrEmpty(updatedTask.Title))
            {
                existingTask.Title = updatedTask.Title;
            }

            if (!string.IsNullOrEmpty(updatedTask.Description))
            {
                existingTask.Description = updatedTask.Description;
            }

            if (updatedTask.DueDate != default)
            {
                existingTask.DueDate = updatedTask.DueDate;
            }

            if (updatedTask.Priority != default)
            {
                existingTask.Priority = updatedTask.Priority;
            }

            // Update other task properties similarly...

            await _context.SaveChangesAsync();

            return existingTask;
        }


        public async Task DeleteTaskAsync(Guid taskId)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }

}
