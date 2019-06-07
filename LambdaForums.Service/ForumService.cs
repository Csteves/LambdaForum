using LamdaForums.Data;
using LamdaForums.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Forum>> GetAllForumsWithPostAsync()
        {
            var forums = await ApplicationDbContext.Forums.Include(x => x.Posts).ToListAsync();
            return forums;
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
