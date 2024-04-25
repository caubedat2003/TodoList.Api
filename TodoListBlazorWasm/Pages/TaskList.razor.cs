
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.Models.Enums;
using TodoListBlazorWasm.Components;
using TodoListBlazorWasm.Services;

namespace TodoListBlazorWasm.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient TaskApiClient { set; get; }
        [Inject] private IToastService ToastService { set; get; }

        protected Confirmation DeleteConfirmation { set; get; }
        private Guid DeletedId { set; get; }

        private List<TaskDto> Tasks;

        private TaskListSearch TaskListSearch = new TaskListSearch();

        protected override async Task OnInitializedAsync()
        {
            Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
        }
        public async Task SearchTask(TaskListSearch taskListSearch)
        {
            TaskListSearch = taskListSearch;
            Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
        }
        public void OnDeleteTask(Guid deletedId)
        {
            DeletedId = deletedId;
            DeleteConfirmation.Show();
        }
        public async Task OnConfirmDeleteTask(bool deleteConfirmed)
        {
            if(deleteConfirmed)
            {
                await TaskApiClient.DeleteTask(DeletedId);
                Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
            }
        }
    }
}
