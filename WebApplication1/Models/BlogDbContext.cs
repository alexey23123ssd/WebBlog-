using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Models
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base (options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
