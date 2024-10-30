namespace TaskBoardApp_v3.Models
{
    public class HomeViewModel
    {
        public int AllTasksCount { get; set; }

        public List<HomeBoardModel> BoardsWithTasksCount { get; set; } = new List<HomeBoardModel>();

        public int UserTasksCount { get; set; }
    }
}
