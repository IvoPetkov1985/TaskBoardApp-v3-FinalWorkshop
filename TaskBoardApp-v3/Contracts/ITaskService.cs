using TaskBoardApp_v3.Models;

namespace TaskBoardApp_v3.Contracts
{
    public interface ITaskService
    {
        Task<TaskDetailsModel> CreateDetailsModel(int id);

        Task CreateNewTaskAsync(string userId, TaskFormModel model);

        Task<TaskDeleteModel> CreateTaskDeleteModelAsync(int id);

        Task<TaskFormModel> CreateTaskFormModelAsync(int id);

        Task EditTaskAsync(TaskFormModel model, int id);

        Task<IEnumerable<BoardFormModel>> GetBoardsAsync();

        Task<TaskBoardApp_v3.Data.DataModels.Task> GetTaskByIdAsync(int id);

        Task RemoveTaskAsync(int id);
    }
}
