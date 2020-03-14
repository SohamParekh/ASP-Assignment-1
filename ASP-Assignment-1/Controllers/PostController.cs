using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Assignment_1.Models;
using ASP_Assignment_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Controllers;

namespace ASP_Assignment_1.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostData pd;
        public List<User> Users;

        public User userDetails;
        [BindProperty]
        public int Id { get; set; }
        public Post up { get; set; }
        public PostController(IPostData pd) 
        {
            this.pd = pd;
            //Users = pd.GetUserByNameAndEmail(userDetails.Name, userDetails.Email).ToList();
            //Id = Users[0].UserId;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            Id = id;
            //return RedirectToAction("MyPost", "Post",new { UserId });
            return View();
        }
        [HttpPost]
        public IActionResult Index(Post post)
        {
            pd.AddPost(post);
            pd.Commit();
            //ViewBag.message = "Posted Successfully";
             return RedirectToAction("MyPost","Post",new { Id });
           // return View();
        }
        [HttpGet]
        public ViewResult MyPost(int id)
        {
            //Id = id;
            //var post = pd.GetPostById(id);
            //var sharepsot = pd.GetSharePostByPostId(id);

            PostCommentViewModel postCommentViewModel = new PostCommentViewModel()
            {
                Post = pd.GetPostById(id),
                sharePosts = pd.GetSharePostByUserId(id)
            };
            return View(postCommentViewModel);
        }
        public IActionResult AllPost(int id)
        {
            //Id = id;
            var post1 = pd.GetOtherPostById(id);
            //pd.GetOtherPostById(id);
            //return RedirectToAction("AllPost","Post");
            return View(post1);
        }
        public IActionResult Delete(int PostId,int id)
        {
            pd.DeletePost(PostId);
            pd.Commit();
            return RedirectToAction("MyPost","Post", new { id } );
        }
        public IActionResult SharePost(SharePost sharePost)
        {
            pd.AddSharePost(sharePost);
            pd.Commit();
            return RedirectToAction("MyPost", "Post", new { Id });
        }
        public IActionResult DeleteSharePost(int postId)
        {
            pd.DeleteSharePost(postId);
            pd.Commit();
            return RedirectToAction("MyPost", "Post", new { Id });
        }
    }
}