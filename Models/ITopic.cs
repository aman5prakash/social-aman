using System.Collections.Generic;
using System.Threading.Tasks;

namespace quizartsocial_backend.Models{
    public interface ITopic {
        // List<Topic> GetAllTopicName();
        // List<Topic> GetAllTopicImage();
        // List<Post> GetAllPost();

        // List<UserC> GetAllUserName();
        // List<UserC> GetAllUserImage();

        void AddUser(User obj);
        Task AddTopicToDB(Topic obj);
        Task AddPostToDB(Post obj);
        // void AddUserToDB(User obj);
        Task AddUserToDB(User obj);
        Task AddCommentToDB(Comment obj);
        List<Post> GetPosts(string topicName);
        List<Topic> GetAllTopics();
         
        Task<List<string>> fetchTopicAsync();
        // List<post> GetAllPosts();
        // List<comments> GetAllComments();


    }
}