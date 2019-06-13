using LamdaForums.data;
using LamdaForums.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LamdaForums.Data
{
    public interface IPostService : IService<Post>
    {
        
        Task<IEnumerable<Post>> GetPostsPerForumAsync(int forumId);
        Task<IEnumerable<Post>> GetFilteredPostsAsync(int id);
        //Task EditPostContentAsync(int id, string content);
        //Task AddReplyAsync(PostReply reply);
    }
}
