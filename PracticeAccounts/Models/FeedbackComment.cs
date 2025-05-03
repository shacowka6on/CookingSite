using PracticeAccounts.Areas.Identity.Data;

namespace PracticeAccounts.Models
{
    public class FeedbackComment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } 
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
