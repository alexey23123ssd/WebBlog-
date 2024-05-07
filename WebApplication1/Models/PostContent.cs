using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PostContent
    {
        public Guid Id { get; set; }
        [StringLength(10000, MinimumLength = 10)]
        public required string Content { get; set; } 
        public Guid ArticleId { get; set; }
        public Article Article { get; set; } = null!;
    }
}
