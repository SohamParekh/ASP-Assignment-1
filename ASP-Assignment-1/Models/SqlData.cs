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

        public Post AddPost(Post newPost)
        {
            db.Posts.Add(newPost);
            db.SaveChanges();
            return newPost;
        }

        public IEnumerable<Post> GetOtherPostById(int id)
        {
            return from p in db.Posts
                   where p.PostId != id
                   select p;
        }

        public void incrementLike(int postId)
        {
            foreach (var i in db.Posts)
            {
                if (i.PostId == postId)
                {
                    i.Like += 1;
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
    }
}
