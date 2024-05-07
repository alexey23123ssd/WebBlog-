using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections;
using System.Drawing;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PostService : IPostService
    {
        private readonly Models.BlogDbContext _context;

        public PostService(Models.BlogDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Post Post(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
