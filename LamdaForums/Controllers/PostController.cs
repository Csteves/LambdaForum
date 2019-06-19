using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamdaForums.Data;
using LamdaForums.Data.Entities;
using LamdaForums.Models.PostViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LamdaForums.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var post = await _postService.GetByIdAsync(id);
            IEnumerable<PostReplyData> replies = PostRepliesModelBuilder(post);

            var vm = new PostIndexData
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Created = post.Created,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                AuthorRating = post.User.Rating.ToString(),
                Replies = replies,
            };

            return View(vm);
        }

        //Get: /Post/Create
        public IActionResult Create(int forumId)
        {
            return View();
        }

        [HttpPost]
        public  IActionResult CreatePost()
        {
            return View();
        }

       private IEnumerable<PostReplyData> PostRepliesModelBuilder(IEnumerable<PostReply> replies)
        {
            var postReplies = replies.Select(reply => new PostReplyData
            {
                Id = reply.Id,
                Content = reply.Content,
                Created = reply.Created,
                AuthorId = reply.User.Id,
                AuthorName = reply.User.UserName,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                AuthorRating = reply.User.Rating.ToString(),
            });
            return postReplies;
        }
        private IEnumerable<PostReplyData> PostRepliesModelBuilder(Post post)
        {
            return PostRepliesModelBuilder(post.Replies);
        }
    }
}