using System.ComponentModel.DataAnnotations;
using static TaskBoardApp_v3.Data.Common.DataConstants;

namespace TaskBoardApp_v3.Data.DataModels
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}
