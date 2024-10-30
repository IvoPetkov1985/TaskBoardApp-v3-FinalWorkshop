using TaskBoardApp_v3.Models;

namespace TaskBoardApp_v3.Contracts
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardViewModel>> GetAllBoardsAsync();
    }
}
