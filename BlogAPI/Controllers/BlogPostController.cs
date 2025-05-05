using BlogAPI.DTOs;
using BlogAPI.Interfaces;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _service;

        public BlogPostController(IBlogPostService service)
        {
            _service = service;
            Log.Information("BlogPostController initialized");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            Log.Information("GET /api/posts endpoint hit");

            var posts = await _service.GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            Log.Information($"GET /api/posts/{id} endpoint hit");

            var post = await _service.GetByIdAsync(id);
            if (post == null)
            {
                Log.Warning($"Blog post with ID {id} not found");
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreateBlogPostDto dto)
        {
            Log.Information("POST /api/posts endpoint hit");

            var createdPost = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetPostById), new { id = createdPost.Id }, createdPost);
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> AddComment(int id, [FromBody] CreateCommentDto dto)
        {
            Log.Information($"POST /api/posts/{id}/comments endpoint hit");

            var comment = await _service.AddCommentAsync(id, dto);
            if (comment == null)
            {
                Log.Warning($"Failed to add comment to blog post with ID {id}");
                return NotFound();
            }

            return CreatedAtAction(nameof(GetPostById), new { id = id }, comment);
        }
    }
}
