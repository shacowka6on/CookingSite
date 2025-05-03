namespace PracticeAccounts.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
