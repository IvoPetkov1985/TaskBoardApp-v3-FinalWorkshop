using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskBoardApp_v3.Data;
using TaskBoardApp_v3.Models;

namespace TaskBoardApp_v3.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TaskBoardDbContext context;

        public HomeController(ILogger<HomeController> logger,
            TaskBoardDbContext dbContext)
        {
            _logger = logger;
            context = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var taskBoards = context.Boards
                .Select(b => b.Name)
                .Distinct();

            var tasksCounts = new List<HomeBoardModel>();

            foreach (string boardName in taskBoards)
            {
                var tasksInBoard = context.Tasks.Where(t => t.Board.Name == boardName).Count();

                tasksCounts.Add(new HomeBoardModel()
                {
                    BoardName = boardName,
                    TasksCount = tasksInBoard
                });
            }

            int userTasksCount = -1;

            if (User?.Identity?.IsAuthenticated ?? false)
            {
                string userId = GetUserId();
                userTasksCount = context.Tasks.Where(t => t.OwnerId == userId).Count();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount = context.Tasks.Count(),
                BoardsWithTasksCount = tasksCounts,
                UserTasksCount = userTasksCount
            };

            return View(homeModel);
        }
    }
}
