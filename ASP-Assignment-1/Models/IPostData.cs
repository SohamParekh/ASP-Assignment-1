using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Assignment_1.Models
{
    public interface IPostData
    {

        //There is any error while sharing other users posts. 
        //And whenever user add the post it redirects to 0 id 

        User AddUser(User newUser);
        Post AddPost(Post newPost);
        Post DeletePost(int postId);
        Comment DeleteComment(int CommentId);

        SharePost DeleteSharePost(int postId);

        SharePost AddSharePost(SharePost newSharePost);

        int Commit();

        IEnumerable<User> GetUserByNameAndEmail(string name, string email);
        IEnumerable<User> GetUserById(int id);

        IEnumerable<Post> GetPostById(int id);

        IEnumerable<SharePost> GetSharePostByUserId(int id);

        IEnumerable<Post> GetOtherPostById(int id);
        void incrementLike(int postId);
        void incrementLikeComment(int CommentId);

        Comment AddComment(Comment newComment);

        IEnumerable<Comment> GetCommentByPostId(int postId);

        IEnumerable<Comment> GetAllComment();
        IEnumerable<Post> GetPost(int id);
    }
}
