using Microsoft.AspNetCore.Mvc;
using TaskBoardApp_v3.Contracts;
using TaskBoardApp_v3.Models;
using static TaskBoardApp_v3.Data.Common.DataConstants;

namespace TaskBoardApp_v3.Controllers
{
    public class TaskController : BaseController
    {
        private readonly ITaskService service;

        public TaskController(ITaskService taskService)
        {
            service = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new TaskFormModel();

            model.Boards = await service.GetBoardsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            var boards = await service.GetBoardsAsync();

            if (!boards.Any(b => b.Id == model.BoardId))
            {
                ModelState.AddModelError(nameof(model.BoardId), MissingBoardErrorMsg);
            }

            if (!ModelState.IsValid)
            {
                model.Boards = await service.GetBoardsAsync();
                return View(model);
            }

            string userId = GetUserId();

            await service.CreateNewTaskAsync(userId, model);

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var task = await service.CreateDetailsModel(id);

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var taskToEdit = await service.GetTaskByIdAsync(id);

            if (taskToEdit == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (userId != taskToEdit.OwnerId)
            {
                return Unauthorized();
            }

            var model = await service.CreateTaskFormModelAsync(id);
            model.Boards = await service.GetBoardsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskFormModel model, int id)
        {
            var taskToEdit = await service.GetTaskByIdAsync(id);

            if (taskToEdit == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (userId != taskToEdit.OwnerId)
            {
                return Unauthorized();
            }

            var boards = await service.GetBoardsAsync();

            if (!boards.Any(b => b.Id == taskToEdit.BoardId))
            {
                ModelState.AddModelError(nameof(taskToEdit.BoardId), MissingBoardErrorMsg);
            }

            if (!ModelState.IsValid)
            {
                model.Boards = boards;
                return View(model);
            }

            await service.EditTaskAsync(model, id);

            return RedirectToAction("All", "Board");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var taskToDelete = await service.GetTaskByIdAsync(id);

            if (taskToDelete == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (userId != taskToDelete.OwnerId)
            {
                return Unauthorized();
            }

            var model = await service.CreateTaskDeleteModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskDeleteModel model)
        {
            var taskToDelete = await service.GetTaskByIdAsync(model.Id);

            if (taskToDelete == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (userId != taskToDelete.OwnerId)
            {
                return Unauthorized();
            }

            await service.RemoveTaskAsync(model.Id);

            return RedirectToAction("All", "Board");
        }
    }
}
