using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Models;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService= postService;
        }

        [ValidationFilter]
        [HttpGet]
        public IActionResult Details([FromRoute] Guid id)
        {
            var post = _postService.GetById(id);
            if(post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_postService.GetAll().ToArray());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [ValidationFilter]
        [HttpPost]
        public IActionResult Add(Post post)
        {
            _postService.Post(post);
            return RedirectToAction("Index");
        }
    }
}
