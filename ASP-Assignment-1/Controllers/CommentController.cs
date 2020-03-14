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
        

        public CommentController(IPostData pd)
        {
            this.pd = pd;
        }
        public IActionResult Index(int postId)
        {
            postID = postId;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Comment comment,int id)
        {
            pd.AddComment(comment);
            pd.Commit();
            return RedirectToAction("MyPost","Post",new { id});
        }
        public IActionResult Delete(int CommentId,int PostId)
        {
            pd.DeleteComment(CommentId);
            pd.Commit();
            return RedirectToAction("Details", "Home",new { PostId });
        }
    }
}