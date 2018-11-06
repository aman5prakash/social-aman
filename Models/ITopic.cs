using System.Collections.Generic;
using System.Threading.Tasks;

namespace quizartsocial_backend.Models{
    public interface ITopic {
        List<TopicC> GetAllTopicName();
        List<TopicC> GetAllTopicImage();
        List<PostC> GetAllPost();

        List<UserC> GetAllUserName();
        List<UserC> GetAllUserImage();

        void AddTopicToDB(TopicC obj);
        void AddPostToDB(PostC obj);
        void AddUserToDB(UserC obj);
        void AddCommentToDB(CommentC obj);
        List<PostC> GetAllPostsIndi(string a);
        List<TopicC> GetAllTopics();
         
        Task<List<string>> fetchTopicAsync();
        // List<post> GetAllPosts();
        // List<comments> GetAllComments();


    }
}