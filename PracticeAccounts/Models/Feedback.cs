using System.ComponentModel.DataAnnotations;
using PracticeAccounts.Areas.Identity.Data;

namespace PracticeAccounts.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        public string Comment { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.UtcNow;
        public string UserFullname => $"{User?.FirstName} {User?.LastName}";
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
