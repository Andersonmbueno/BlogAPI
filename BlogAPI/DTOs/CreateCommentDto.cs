namespace BlogAPI.DTOs
{
    public class CreateCommentDto
    {
        public string Author { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}
