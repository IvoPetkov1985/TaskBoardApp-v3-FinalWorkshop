using Microsoft.AspNetCore.Mvc;
using TaskBoardApp_v3.Contracts;

namespace TaskBoardApp_v3.Controllers
{
    public class BoardController : BaseController
    {
        private readonly IBoardService service;

        public BoardController(IBoardService boardService)
        {
            service = boardService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await service.GetAllBoardsAsync();

            return View(model);
        }
    }
}
