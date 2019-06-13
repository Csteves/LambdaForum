using LamdaForums.data;
using LamdaForums.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LamdaForums.Data
{
    public interface IForumService : IService<Forum>
    {
        Task<IEnumerable<Forum>> GetAllForumsWithPostsAsync();
        Task<Forum> GetForumWithPostsAsync(int id);
        Task<IEnumerable<ApplicationUser>> GetAllActiveUsers();
        Task Create(Forum forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newTitle);
        Task UpdateForumDescription(int forumId, string newDescription);

    }
}
