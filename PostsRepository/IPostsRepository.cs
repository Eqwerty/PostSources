using System.Collections.Generic;

namespace PostsRepository;

public interface IPostsRepository
{
    void Add(int post);

    IList<int> GetPosts();
}