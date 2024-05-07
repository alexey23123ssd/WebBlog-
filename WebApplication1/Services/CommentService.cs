using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApplication1.Models;

namespace WebApplication1.Services
{

    public class CommentService : ICommentService
    {
        private readonly Models.BlogDbContext _context;

        public CommentService(Models.BlogDbContext context)
        {
            _context = context;
        }
        public Comment Add(Guid id, Comment comment)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException("Post doesnt exist");
            }
            if(comment == null)
            {
                throw new ArgumentNullException();
            }
            comment.Id = Guid.NewGuid();
            _context.Comments.Add(new Comment
            {
                Id = comment.Id,
                Content = comment.Content,
                CreatedAt = DateTime.UtcNow,
                ArticleId = id
            });
            _context.SaveChanges();
            return comment;
        }

        public void Delete(Guid id)
        {
            Comment? comment = _context.Comments.SingleOrDefault(c => c.Id == id);
            if (comment != null)
            {
                _context.Comments.Remove(comment); 
                _context.SaveChanges();
            }
        }
    }
}
