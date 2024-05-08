using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class ArticleController:Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public ArticleController(IArticleService articleService,ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }

        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(_articleService.GetAll().ToArray());
        }

        [Route("CreateArticle")]
        [ValidationFilter]
        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View("Add");
        }

        [Route("CreateArticle")]
        [ValidationFilter]
        [HttpPost]
        public IActionResult CreateArticle([FromForm] Article article)
        {
            _articleService.Post(article);

            return RedirectToAction("Index");
        }

        [Route("UpdateArticle/{id?}")]
        [ValidationFilter]
        [HttpPut]
        public IActionResult UpdateContent([FromRoute] Guid id,[FromBody] Article content)
        {
            _articleService.Update(id, content);

            return Ok();
        }

        [Route("CreateComment/{id?}")]
        [ValidationFilter]
        [HttpPost]
        public IActionResult CreateComment([FromRoute] Guid id, [FromBody] Comment comment)
        {
            _commentService.Add(id, comment);

            return Ok();
        }

        [Route("DeleteComment/{id?}")]
        [ValidationFilter]
        [HttpDelete]
        public IActionResult DeleteComment([FromRoute] Guid id)
        {
            _commentService.Delete(id);

            return Ok();
        }
    }
}
