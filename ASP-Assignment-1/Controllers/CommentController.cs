using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Assignment_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Assignment_1.Controllers
{
    public class CommentController : Controller
    {
        private readonly IPostData pd;
        public int postID { get; set; }
        

        [BindProperty]
        public int Dummy { get; set; }
        public CommentController(IPostData pd)
        {
            this.pd = pd;
        }
        public IActionResult Index(int postId, int dummy)
        {
            postID = postId;
            Dummy = dummy;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Comment comment)
        {
            pd.AddComment(comment);
            pd.Commit();
            return RedirectToAction("MyPost","Post");
        }
    }
}