using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Assignment_1.Models
{
    public class SqlData : IPostData
    {
        private readonly AppDbContext db;

        public SqlData(AppDbContext db)
        {
            this.db = db;
        }

        public User AddUser(User newUser)
        {
            db.User.Add(newUser);
            db.SaveChanges();
            return newUser;
        }
        public SharePost AddSharePost(SharePost newSharePost)
        {
            db.sharePosts.Add(newSharePost);
            db.SaveChanges();
            return newSharePost;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public IEnumerable<User> GetUserByNameAndEmail(string name, string email)
        {
            var query = from u in db.User
                        where (u.Name.Equals(name) && u.Email.Equals(email))
                        select u;
            return query;
        }
        public IEnumerable<Post> GetPost(int id)
        {
            return from p in db.Posts
                   where p.PostId == id
                   select p;
        }
        public IEnumerable<Post> GetPostById(int id)
        {
            return from p in db.Posts
                   where p.UserId == id
                   select p;
        }
        public IEnumerable<SharePost> GetSharePostByUserId(int id)
        {
            return from s in db.sharePosts
                   where s.UserId == id
                   select s;
        }

        public Post AddPost(Post newPost)
        {
            db.Posts.Add(newPost);
            db.SaveChanges();
            return newPost;
        }

        public IEnumerable<Post> GetOtherPostById(int PostId)
        {
            return from p in db.Posts
                   where p.PostId != PostId
                   select p;
        }

        public void incrementLike(int postId)
        {
            foreach (var i in db.Posts)
            {
                if (i.PostId == postId)
                {
                    i.Like++;
                }
            }

        }
        public void incrementLikeComment(int CommentId)
        {
            foreach (var i in db.Comments)
            {
                if (i.CommentId == CommentId)
                {
                    i.Like++;
                }
            }

        }

        public Comment AddComment(Comment newComment)
        {
            db.Comments.Add(newComment);
            db.SaveChanges();
            return newComment;
        }

        public IEnumerable<Comment> GetCommentByPostId(int postId)
        {
            return from cd in db.Comments
                   where cd.PostId == postId
                   select cd;
        }

        public IEnumerable<Comment> GetAllComment()
        {
            return from c in db.Comments
                   select c;
        }

        public IEnumerable<User> GetUserById(int id)
        {
            var query = from u in db.User
                        where (u.Name.Equals(id))
                        select u;
            return query;
        }

        public Post DeletePost(int postId)
        {
            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);
            if(post != null)
            {
                db.Posts.Remove(post);
            }
            return post;
        }
        public Comment DeleteComment(int CommentId)
        {
            Comment comment = db.Comments.FirstOrDefault(p => p.CommentId == CommentId);
            if (comment != null)
            {
                db.Comments.Remove(comment);
            }
            return comment;
        }
        public SharePost DeleteSharePost(int postId)
        {
            SharePost post = db.sharePosts.FirstOrDefault(p => p.PostId == postId);
            if (post != null)
            {
                db.sharePosts.Remove(post);
            }
            return post;
        }


    }
}
