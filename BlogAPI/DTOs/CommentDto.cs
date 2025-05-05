namespace BlogAPI.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Author { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
