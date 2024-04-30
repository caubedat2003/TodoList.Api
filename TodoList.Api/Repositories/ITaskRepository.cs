using TodoList.Models;
using TodoList.Models.SeedWork;
using Task = TodoList.Api.Entities.Task;

namespace TodoList.Api.Repositories
{
    public interface ITaskRepository
    {
        Task<PagedList<Task>> GetTasksList(TaskListSearch taskListSearch);
        Task<PagedList<Task>> GetTasksListByUserId(Guid userId, TaskListSearch taskListSearch);

        Task<Task> Create(Task task);

        Task<Task> Update(Task task);

        Task<Task> Delete(Task task);

        Task<Task> GetById(Guid id);
    }
}
