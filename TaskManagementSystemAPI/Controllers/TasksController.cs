using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystemAPI.Models;
using TaskManagementSystemAPI.Service;

namespace TaskManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }
        //controller method for getting all the tasks 
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }
        //Controller method for getting a particular task by ID 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }
        //Controller method for creating a task
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Tasks task)
        {
            var createdTask = await _taskService.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
        }
        //Controller method for updating a particular task by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Tasks task)
        {
            if (id != task.Id) return BadRequest();
            var updatedTask = await _taskService.UpdateTaskAsync(task);
            if (updatedTask == null) return NotFound();
            return Ok(updatedTask);
        }
        //Controller Method for Deleting a particular task by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var success = await _taskService.DeleteTaskAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }

}
