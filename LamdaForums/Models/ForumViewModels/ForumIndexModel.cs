
using System.Collections.Generic;


namespace LamdaForums.Models.ForumViewModels
{
    public class ForumIndexModel
    {
        public IEnumerable<ForumListingData> ForumList { get; set; }
        public string Message { get; set; }
    }
}
