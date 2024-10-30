using Microsoft.EntityFrameworkCore;
using TaskBoardApp_v3.Contracts;
using TaskBoardApp_v3.Data;
using TaskBoardApp_v3.Models;
using static TaskBoardApp_v3.Data.Common.DataConstants;

namespace TaskBoardApp_v3.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskBoardDbContext context;

        public TaskService(TaskBoardDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<TaskDetailsModel> CreateDetailsModel(int id)
        {
            var model = await context.Tasks
                .AsNoTracking()
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString(TaskDateTimeFormat),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task CreateNewTaskAsync(string userId, TaskFormModel model)
        {
            var newTask = new TaskBoardApp_v3.Data.DataModels.Task()
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                BoardId = model.BoardId,
                OwnerId = userId
            };

            await context.Tasks.AddAsync(newTask);
            await context.SaveChangesAsync();
        }

        public async Task<TaskDeleteModel> CreateTaskDeleteModelAsync(int id)
        {
            var model = await context.Tasks
                .AsNoTracking()
                .Where(t => t.Id == id)
                .Select(t => new TaskDeleteModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    OwnerId = t.OwnerId
                })
                .FirstAsync();

            return model;
        }

        public async Task<TaskFormModel> CreateTaskFormModelAsync(int id)
        {
            var taskToEdit = await context.Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskFormModel()
                {
                    Title = t.Title,
                    Description = t.Description,
                    BoardId = t.BoardId,
                })
                .FirstAsync();

            return taskToEdit;
        }

        public async Task EditTaskAsync(TaskFormModel model, int id)
        {
            var taskToEdit = await context.Tasks
                .FirstAsync(t => t.Id == id);

            taskToEdit.Title = model.Title;
            taskToEdit.Description = model.Description;
            taskToEdit.BoardId = model.BoardId;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BoardFormModel>> GetBoardsAsync()
        {
            var boards = await context.Boards
                .AsNoTracking()
                .Select(b => new BoardFormModel()
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToListAsync();

            return boards;
        }

        public async Task<Data.DataModels.Task> GetTaskByIdAsync(int id)
        {
            var task = await context.Tasks
                .AsNoTracking()
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            return task;
        }

        public async Task RemoveTaskAsync(int id)
        {
            var taskToRemove = await context.Tasks
                .FirstAsync(t => t.Id == id);

            context.Tasks.Remove(taskToRemove);
            await context.SaveChangesAsync();
        }
    }
}
