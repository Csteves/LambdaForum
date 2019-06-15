using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LamdaForums.Data;
using LamdaForums.Data.Entities;

namespace LambdaForums.Service
{
    public class PostService : Service<Post>, IPostService
    {
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
        public PostService(ApplicationDbContext context)
            : base(context)
        {
        }
        public async Task<Post> GetByIdAsync(int id)
        {
            var post = await ApplicationDbContext.Posts
                            .Where(p => p.Id == id)
                            .Include(p => p.User)
                            .SingleAsync();
            return post;
        }
        public async Task<IEnumerable<Post>> GetFilteredPostsAsync(int id)
        {
            var posts = await ApplicationDbContext.Posts
                .Where(p => p.Id == id)
                .Include(p => p.User)
                .Include(p => p.Forum)
                .Include(p => p.Replies)
                    .ThenInclude(r => r.User)
                .ToListAsync();
            return posts;
        }

        public async Task<IEnumerable<Post>> GetPostsPerForumAsync(int forumId)
        {
            IEnumerable<Post> posts = await ApplicationDbContext.Posts
                .Where(p => p.Forum.Id == forumId)
                .Include(p => p.User)
                .Include(p => p.Replies)
                    .ThenInclude(r => r.User)
                .ToListAsync();
            return posts;
        }


        public  Task EditPostContent(int id, string content)
        {
            
           throw new System.NotImplementedException();
        }

        public  Task AddReply(PostReply reply)
        {
           throw new System.NotImplementedException();
        }
    }
}
