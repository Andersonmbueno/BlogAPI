namespace BlogAPI.DTOs
{
    public class BlogPostDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public List<CommentDto> Comments { get; set; } = new();
    }
}
