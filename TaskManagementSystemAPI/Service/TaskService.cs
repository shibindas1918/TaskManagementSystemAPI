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

        public async Task<IEnumerable<Task>> GetAllTasksAsync()
        {
            return (IEnumerable<Task>)await _context.Tasks.Include(t => t.User).ToListAsync();

        }
        public async Task<Tasks> GetTaskByIdAsync(int taskId)
        {
            var task = await _context.Tasks.Include(t => t.User)
                                           .FirstOrDefaultAsync(t => t.Id == taskId);
            return task;
        }


        public async Task<Tasks> CreateTaskAsync(Tasks task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }


        public async Task<Tasks> UpdateTaskAsync(Tasks task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }


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
