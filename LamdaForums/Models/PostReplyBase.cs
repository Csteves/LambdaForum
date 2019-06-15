using System;
namespace LamdaForums.Models
{
    public class PostReplyBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }

        public string AuthorRating { get; set; }
    }
}