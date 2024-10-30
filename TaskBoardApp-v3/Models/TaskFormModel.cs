using System.ComponentModel.DataAnnotations;
using static TaskBoardApp_v3.Data.Common.DataConstants;

namespace TaskBoardApp_v3.Models
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(TaskTitleMaxLength, MinimumLength = TaskTitleMinLength, ErrorMessage = TaskInputLengthErrorMsg)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(TaskDescriptionMaxLength, MinimumLength = TaskDesrriptionMinLength, ErrorMessage = TaskInputLengthErrorMsg)]
        public string Description { get; set; } = string.Empty;

        public int BoardId { get; set; }

        public IEnumerable<BoardFormModel> Boards { get; set; } = new List<BoardFormModel>();
    }
}
