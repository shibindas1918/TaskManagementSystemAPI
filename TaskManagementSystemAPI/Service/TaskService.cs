using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagementSystemAPI.Data;
using TaskManagementSystemAPI.Models;

namespace TaskManagementSystemAPI.Service
{
    public class TaskService
    {
        private readonly TaskManagementContext _context;

        public TaskService(TaskManagementContext context)
        {
            _context = context;
        }
        // Get method to get all the tasks 
        public async Task<IEnumerable<Task>> GetAllTasksAsync()
        {
            return (IEnumerable<Task>)await _context.Tasks.Include(t => t.User).ToListAsync();

        }
        //Get method for getting a particular task by Id  
        public async Task<Tasks> GetTaskByIdAsync(int taskId)
        {
            var task = await _context.Tasks.Include(t => t.User)
                                           .FirstOrDefaultAsync(t => t.Id == taskId);
            return task;
        }

        //post method for creating a Task 
        public async Task<Tasks> CreateTaskAsync(Tasks task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        //Update Method for updating particular task by id 

        public async Task<Tasks> UpdateTaskAsync(Tasks task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        //Delete Method for deleting a particular task 
        public async Task<bool> DeleteTaskAsync(int taskId)
{
    var task = await _context.Tasks.FindAsync(taskId);
    if (task != null)
    {
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }
    return false;
}
    }

}
