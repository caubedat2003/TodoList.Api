
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;
using TodoList.Models;

namespace TodoList.Api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoListDbContext _context;
        public TaskRepository(TodoListDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Entities.Task>> GetTasksList()
        {
            return await _context.Tasks
                .Include(x => x.Assignee).ToListAsync();
                
        }
        public async Task<Entities.Task> Create(Entities.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }
        public async Task<Entities.Task> Update(Entities.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> Delete(Entities.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entities.Task> GetById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }
    }
}
