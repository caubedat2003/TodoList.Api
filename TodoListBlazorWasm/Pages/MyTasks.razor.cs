
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using TodoList.Models;
using TodoList.Models.Enums;
using TodoList.Models.SeedWork;
using TodoListBlazorWasm.Components;
using TodoListBlazorWasm.Pages.Components;
using TodoListBlazorWasm.Services;
using TodoListBlazorWasm.Layout;

namespace TodoListBlazorWasm.Pages
{
    public partial class MyTasks
    {
        [Inject] private ITaskApiClient TaskApiClient { set; get; }
        [Inject] private IToastService ToastService { set; get; }

        protected Confirmation DeleteConfirmation { set; get; }
        protected AssignTask AssignTaskDialog { set; get; }
        private Guid DeletedId { set; get; }

        private List<TaskDto> Tasks;

        private MetaData MetaData { set; get; } = new MetaData();

        private TaskListSearch TaskListSearch = new TaskListSearch();

        [CascadingParameter]
        private Error Error { set; get; }

        protected override async Task OnInitializedAsync()
        {
            await GetTask();
        }
        public async Task SearchTask(TaskListSearch taskListSearch)
        {
            TaskListSearch = taskListSearch;
            await GetTask();
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
                await GetTask();
            }
        }
        public void OpenAssignPopup(Guid Id)
        {
            AssignTaskDialog.Show(Id);
        }
        public async Task AssignTaskSuccess(bool result)
        {
            if (result)
            {
                //Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
                await GetTask();
            }
        }
        public async Task GetTask()
        {
            try
            {
                var pagingResponse = await TaskApiClient.GetMyTasks(TaskListSearch);
                Tasks = pagingResponse.Items;
                MetaData = pagingResponse.MetaData;
            }
            catch(Exception ex)
            {
                Error.ProcessError(ex);
            }
        }
        private async Task SelectedPage(int page)
        {
            TaskListSearch.PageNumber = page;
            await GetTask();
        }
    }
}
