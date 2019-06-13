using LamdaForums.Models.Post;
using System.Collections.Generic;


namespace LamdaForums.Models.ForumViewModels
{
    public class ForumTopicModel
    {
        public ForumListingData Forum { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }

    }
}
