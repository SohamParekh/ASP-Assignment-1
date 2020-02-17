using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ASP_Assignment_1.Models;
using ASP_Assignment_1.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public int id { set; get; }
        public User user { get; set; }

        public string message = null;

        public List<User> Users;
        private readonly IPostData pd;
        private readonly AppDbContext db;
        public HomeController(IPostData addUserDetails, AppDbContext db)
        {
            this.pd = addUserDetails;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User userDetail)
        {
            if (ModelState.IsValid)
            {
                Users = pd.GetUserByNameAndEmail(userDetail.Name, userDetail.Email).ToList();
                if (Users.Count() == 0)
                {
                    pd.AddUser(userDetail);
                    ViewBag.message = "User registered!";

                }
                else
                {

                    id = Users[0].UserId;
                    return RedirectToAction("MyPost", "Post", new { id });
                }
                pd.AddUser(userDetail);
                return RedirectToAction("MyPost", "Post", new { id });
            }
            else
                return View();
        }
        public ViewResult Details(int PostId)
        {
            PostCommentViewModel postCommentViewModel = new PostCommentViewModel()
            {
                Post = pd.GetPost(PostId),
                Comment = pd.GetCommentByPostId(PostId)
            };
            return View(postCommentViewModel);
        }
        
        public IActionResult LikePost(int postId)
        {
            pd.incrementLike(postId);
            pd.Commit();
            return RedirectToAction("AllPost", "Post");
        }
        
    }
}
