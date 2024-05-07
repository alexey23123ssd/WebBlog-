using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; } 
        public Guid ArticleId { get; set; }
        public Article Article { get; set; } = null!;
    }
}
