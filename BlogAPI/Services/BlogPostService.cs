using BlogAPI.Data;
using BlogAPI.DTOs;
using BlogAPI.Interfaces;
using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BlogAPI.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly AppDbContext _context;

        public BlogPostService(AppDbContext context)
        {
            _context = context;
            Log.Information("BlogPostService initialized");
        }

        public async Task<IEnumerable<BlogPostSummaryDto>> GetAllAsync()
        {
            Log.Information("Fetching all blog posts");

            var posts = await _context.BlogPosts
                .Select(p => new BlogPostSummaryDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    CommentCount = p.Comments.Count
                })
                .ToListAsync();

            Log.Information($"Retrieved {posts.Count} blog posts");
            return posts;
        }

        public async Task<BlogPostDetailDto?> GetByIdAsync(int id)
        {
            Log.Information($"Fetching blog post with ID: {id}");

            var post = await _context.BlogPosts
                .Where(p => p.Id == id)
                .Include(p => p.Comments)
                .Select(p => new BlogPostDetailDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    Comments = p.Comments.Select(c => new CommentDto
                    {
                        Author = c.Author,
                        Text = c.Text,
                        CreatedAt = c.CreatedAt
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (post == null)
            {
                Log.Warning($"Blog post with ID {id} not found");
            }
            else
            {
                Log.Information($"Blog post with ID {id} retrieved successfully");
            }

            return post;
        }

        public async Task<BlogPost> CreateAsync(CreateBlogPostDto dto)
        {
            Log.Information("Creating a new blog post");

            var post = new BlogPost
            {
                Title = dto.Title,
                Content = dto.Content
            };

            _context.BlogPosts.Add(post);
            await _context.SaveChangesAsync();

            Log.Information($"Blog post with ID {post.Id} created successfully");
            return post;
        }

        public async Task<Comment?> AddCommentAsync(int postId, CreateCommentDto dto)
        {
            Log.Information($"Adding a comment to blog post with ID {postId}");

            var post = await _context.BlogPosts.FindAsync(postId);
            if (post == null)
            {
                Log.Warning($"Blog post with ID {postId} not found");
                return null;
            }

            var comment = new Comment
            {
                Author = dto.Author,
                Text = dto.Text,
                BlogPostId = postId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            Log.Information($"Comment added to blog post with ID {postId}");
            return comment;
        }
    }
}
