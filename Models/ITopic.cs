using System.Collections.Generic;
namespace quizartsocial_backend.Models{
    public interface ITopic {
        List<TopicC> GetAllTopicName();
        List<TopicC> GetAllTopicImage();
        void AddTopicToDB(TopicC obj);
        // List<post> GetAllPosts();
        // List<comments> GetAllComments();


    }
}