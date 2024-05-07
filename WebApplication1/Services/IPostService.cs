using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IPostService
    {
        Post GetById(Guid id);
        Post Post(Post post);
        IEnumerable<Post> GetAll();
    }
}
