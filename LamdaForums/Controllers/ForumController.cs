using LamdaForums.Data;
using LamdaForums.Models.ForumViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using LamdaForums.Data.Entities;

namespace LamdaForums.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;
        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
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
            ForumTopicModel vm = new ForumTopicModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Created = forum.Created,
                Description = forum.Description,
            };

            return View(vm);
        }
        
    }
}