using PracticeAccounts.Areas.Identity.Data;

namespace PracticeAccounts.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrlPath { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
