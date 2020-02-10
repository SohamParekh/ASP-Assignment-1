using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Assignment_1.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controllers;

namespace ASP_Assignment_1.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostData pd;
        

        [BindProperty]
        public int Id { get; set; }
        public IEnumerable<Post> Up { get; set; }
        public IEnumerable<Comment> Cp { get; set; }
        public Post up { get; set; }
        public PostController(IPostData pd)
        {
            this.pd = pd;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(Post post,int id)
        {
            
            pd.AddPost(post);
            pd.Commit();
            ViewBag.message = "Posted Successfully";
            return View("post");
        }
        public IActionResult MyPost(int id)
        {
            Id = id;
            var post = pd.GetPostById(id);
            return View(post);
        }
        public IActionResult AllPost(int id)
        {
            Id = id;
            var post1 = pd.GetOtherPostById(id);
            return View(post1);
        }
    }
}