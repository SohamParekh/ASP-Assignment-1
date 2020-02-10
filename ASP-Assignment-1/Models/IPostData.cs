using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Assignment_1.Models
{
    public interface IPostData
    {
        User AddUser(User newUser);
        Post AddPost(Post newPost);

        int Commit();

        IEnumerable<User> GetUserByNameAndEmail(string name, string email);
        IEnumerable<User> GetUserById(int id);

        IEnumerable<Post> GetPostById(int id);

        IEnumerable<Post> GetOtherPostById(int id);
        void incrementLike(int postId);
        Post deletePost(int postId);

        Comment AddComment(Comment newComment);

        IEnumerable<Comment> GetCommentByPostId(int postId);

        IEnumerable<Comment> GetAllComment();
        IEnumerable<Post> GetAllPost();
    }
}
