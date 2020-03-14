using ASP_Assignment_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Assignment_1.ViewModels
{
    public class PostCommentViewModel
    {
        public IEnumerable<Post> Post { get; set; }
        public IEnumerable<Comment> Comment { get; set; }
        public IEnumerable<SharePost> sharePosts { get; set; }
    }
}
