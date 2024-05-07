using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Post
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public  string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public  string Description { get; set; }

        [Required]
        [StringLength(10000, MinimumLength = 10)]
        public string Content { get; set; }


    }
}
