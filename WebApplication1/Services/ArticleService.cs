using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ArticleService : IArticleService
    {
        private readonly Models.BlogDbContext _context;

        public ArticleService(Models.BlogDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Article> GetAll()
        {
            return _context.Articles;
        }

        public Article GetById(Guid id)
        {
            return _context.Articles.SingleOrDefault(x => x.Id == id);
        }

        public void Post(Article article)
        {
            article.Id = Guid.NewGuid();

            _context.Articles.Add(new Article
            {
                Id = article.Id,
                Name = article.Name,
                Description = article.Description,
                Content = article.Content
            });

            _context.SaveChanges();
        }

        public Article Update(Guid id, Article article)
        {
            var articleExisted = _context.Articles.SingleOrDefault(x => x.Id == id);

            if (articleExisted != null)
            {
                articleExisted.Content = article.Content;
                _context.Articles.Update(articleExisted);
                _context.SaveChanges();
                return articleExisted;
            }

            return null;
        }
    }
}
