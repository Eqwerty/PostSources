using System.Collections.Generic;
using System.Linq;

namespace PostsRepository;

public class PostsRepository : IPostsRepository
{
    private readonly List<int> _posts = new();

    public void Add(int post)
    {
        _posts.Add(post);
    }

    public IList<int> GetPosts()
    {
        return _posts
            .OrderBy(p => p)
            .ToList()
            .AsReadOnly();
    }
}