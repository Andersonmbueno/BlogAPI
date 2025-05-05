using BlogAPI.DTOs;
using BlogAPI.Models;

namespace BlogAPI.Interfaces
{
    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPostSummaryDto>> GetAllAsync();
        Task<BlogPostDetailDto?> GetByIdAsync(int id);
        Task<BlogPost> CreateAsync(CreateBlogPostDto dto);
        Task<Comment?> AddCommentAsync(int postId, CreateCommentDto dto);
    }
}
