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
            var forumsVM = forums.Select(x => new ForumListingData
            {
                Id = x.Id,
                Name = x.Title,
                Description = x.Description
            });
           
            return View();
        }
    }
}