using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp_v3.Data.Common.DataConstants;

namespace TaskBoardApp_v3.Data.DataModels
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TaskTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(TaskDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        public Board? Board { get; set; }

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        public IdentityUser Owner { get; set; } = null!;
    }
}
