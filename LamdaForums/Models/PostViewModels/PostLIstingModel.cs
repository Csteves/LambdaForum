using LamdaForums.Models.ForumViewModels;
namespace LamdaForums.Models.Post
{
    public class PostLIstingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string AuthorRating { get; set; }
        public string DatePosted { get; set; }

        public int ForumId { get; set; }
        public string ForumImgUrl { get; set; }
        public string ForumTitle { get; set; }

        public int RepliesCount { get; set; }

        public ForumListingData Forum { get; set; }
    }
}
