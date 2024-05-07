using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Article
    {
        public Guid? Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public required string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public required string Description { get; set; }

        public string? Content { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
