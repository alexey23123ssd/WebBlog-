using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
        public class PostServiceE 
        {
            private readonly string _fileName = "posts.json";

            public PostServiceE(string fileName)
            {
                if (fileName == null) throw new ArgumentNullException(nameof(fileName));
                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }
                _fileName = fileName;
            }

            public Post GetById(Guid id)
            {
                var posts = JsonSerializer.Deserialize<IEnumerable<Post>>(File.ReadAllText(_fileName))
                    ?? new List<Post>();
                foreach (var post in posts)
                {
                    if (post.Id == id)
                    {
                        return post;
                    }

                }
                return null;
            }
            public IEnumerable<Post> GetAll()
            {
                var source = File.ReadAllText(_fileName);
                if (string.IsNullOrEmpty(source))
                {
                    return new List<Post>();
                }
                return JsonSerializer.Deserialize<IEnumerable<Post>>(source);

            }
            public Post Post(Post post)
            {
                post.Id = Guid.NewGuid();
                if (post == null)
                {
                    throw new ArgumentNullException(nameof(post));
                }

                var posts = GetAll();
                var postsList = posts.ToList();
                postsList.Add(post);
                File.WriteAllText(_fileName, JsonSerializer.Serialize(postsList));
                return post;
            }


        }
    
}
