using System;
using System.Collections.Generic;
using LamdaForums.Models;

namespace LamdaForums.Models.PostViewModels
{
    public class PostIndexData : PostReplyBase
    {
        public IEnumerable<PostReplyData> Replies { get; set; }
    }
}
