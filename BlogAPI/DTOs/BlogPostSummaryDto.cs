namespace BlogAPI.DTOs
{
    public class BlogPostSummaryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int CommentCount { get; set; }
    }
}
