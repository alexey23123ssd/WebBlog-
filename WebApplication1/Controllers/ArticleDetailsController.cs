using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebBlog.Application.Controllers
{
    [Route("[controller]")]
    public class ArticleDetailsController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleDetailsController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [Route("Details/{id?}")]
        [HttpGet]
        public IActionResult Details([FromRoute] Guid id) 
        {
            var article = _articleService.GetById(id);

            return View(article);
        }
    }
}
