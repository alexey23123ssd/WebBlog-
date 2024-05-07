using WebApplication1.Models;
namespace WebApplication1.Services
{
    public interface ICommentService
    {
        Comment Add(Guid id,Comment comment);
        void Delete(Guid id);
    }
}
