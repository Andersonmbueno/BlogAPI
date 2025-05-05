namespace BlogAPI.DTOs
{
    public class CreateBlogPostDto
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
