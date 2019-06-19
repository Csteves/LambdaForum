using System;
using System.Collections.Generic;
using LamdaForums.Models;

namespace LamdaForums.Models.PostViewModels
{
    public class PostIndexData : PostReplyBase
    {
        public string Title { get; set; }
        public IEnumerable<PostReplyData> Replies { get; set; }
    }
}
