using Microsoft.EntityFrameworkCore;
using TaskBoardApp_v3.Contracts;
using TaskBoardApp_v3.Data;
using TaskBoardApp_v3.Models;

namespace TaskBoardApp_v3.Services
{
    public class BoardService : IBoardService
    {
        private readonly TaskBoardDbContext context;

        public BoardService(TaskBoardDbContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task<IEnumerable<BoardViewModel>> GetAllBoardsAsync()
        {
            var boards = await context.Boards
                .AsNoTracking()
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks
                    .Select(t => new TaskViewModel()
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName
                    })
                })
                .ToListAsync();

            return boards;
        }
    }
}
