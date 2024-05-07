using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IArticleService
    {
        Article GetById(Guid id);
        void Post(Article article);
        IEnumerable<Article> GetAll();

        Article Update(Guid id, Article content);
    }
}
