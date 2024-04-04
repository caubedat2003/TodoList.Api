
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using TodoList.Models;
using TodoListBlazorWasm.Services;

namespace TodoListBlazorWasm.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient TaskApiClient { set; get; }

        private List<TaskDto> Tasks;
        protected override async Task OnInitializedAsync()
        {
            Tasks = await TaskApiClient.GetTaskList();
        }
    }
}
