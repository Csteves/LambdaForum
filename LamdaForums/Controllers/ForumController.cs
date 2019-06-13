using LamdaForums.Data;
using LamdaForums.Models.ForumViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using LamdaForums.Data.Entities;
using LamdaForums.Models.Post;

namespace LamdaForums.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;
        private readonly IPostService _PostService;
        public ForumController(IForumService forumService, IPostService postService)
        {
            _forumService = forumService;
            _PostService = postService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Forum> forums = await _forumService.GetAllAsync();
            var forumsListings = forums.Select(x => new ForumListingData
            {
                Id = x.Id,
                Name = x.Title,
                Description = x.Description
            });

            var vm = new ForumIndexModel
            {
                ForumList = forumsListings,
            };
           
            return View(vm);
        }

     

        //Get:/Forum/Topic/{id}
        public async Task<IActionResult> Topic(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var forum = await _forumService.GetForumWithPostsAsync(id);
            var posts = await _PostService.GetPostsPerForumAsync(id);
            var forumListing = BuildForumListing(forum);
            var postListing = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                Author = post.User.UserName,
                AuthorRating = post.User.Rating.ToString(),
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post),
            });

            var forumVm = new ForumTopicModel
            {
                Forum = forumListing,
                Posts = postListing,
            };
            return View(forumVm);
        }

        private ForumListingData BuildForumListing(Post post)
        {
            return BuildForumListing(post.Forum);
        }
        private ForumListingData BuildForumListing(Forum forum)
        {
            return new ForumListingData
            {
                Id = forum.Id,
                Name = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl,
            };
        }
    }
}