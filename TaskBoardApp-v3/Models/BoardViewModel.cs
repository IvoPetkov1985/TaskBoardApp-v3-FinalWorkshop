namespace TaskBoardApp_v3.Models
{
    public class BoardViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
    }
}
