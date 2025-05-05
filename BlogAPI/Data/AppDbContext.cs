using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;
using Serilog;

namespace BlogAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            Log.Information("AppDbContext initialized");
        }

        public DbSet<BlogPost> BlogPosts => Set<BlogPost>();
        public DbSet<Comment> Comments => Set<Comment>();
    }
}
