using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebBlog.Application.Controllers
{
    [Route("[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [Route("CreateComment/{id?}")]
        [HttpGet]
        public IActionResult CreateComment([FromRoute] Guid id)
        {
            ViewBag.ArticleId = id;
            return View("CreateComment");
        }

        [Route("CreateComment/{id?}")]
        [HttpPost]
        public IActionResult CreateComment([FromRoute] Guid id, [FromForm] Comment comment)
        {
           var commentCreated = _commentService.Add(id, comment);
            
           ViewBag.CommentId = commentCreated.Id;

           return View("Index");
        }
    }
}
