using LamdaForums.Data;
using LamdaForums.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LambdaForums.Service
{
    public class ForumService : Service<Forum>, IForumService
    {
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
        public ForumService(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Forum>> GetAllForumsWithPostsAsync()
        {
            var forums = await ApplicationDbContext.Forums.Include(x => x.Posts).ToListAsync();
            return forums;
        }

        public async Task<Forum> GetForumWithPostsAsync(int id)
        {
            var forum = await ApplicationDbContext.Forums
                .Where(f => f.Id == id)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.User)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.Replies)
                        .ThenInclude(r => r.User)
                .FirstOrDefaultAsync();
            return forum;
        }

        public Task<IEnumerable<ApplicationUser>> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int forumId, string newTitle)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumDescription(int forumId, string newDescription)
        {
            throw new NotImplementedException();
        }
    }
}
