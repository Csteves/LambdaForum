using LamdaForums.Data;
using LamdaForums.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LambdaForums.Service
{
    public class ForumService : Service<Forum>, IForumService
    {
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
        public ForumService(ApplicationDbContext context)
            : base(context)
        {
        }

  
    }
}
