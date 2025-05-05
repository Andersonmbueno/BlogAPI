using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAPI.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(1000)]
        public string Text { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign key
        [ForeignKey("BlogPost")]
        public int BlogPostId { get; set; }

        // Navigation property
        public BlogPost BlogPost { get; set; } = null!;
    }
}
