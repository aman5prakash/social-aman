using System.Collections.Generic;
namespace quizartsocial_backend.Models{
    public interface ITopic {
        List<category> GetAllTopicName();
        List<category> GetAllTopicImage();
        List<category> GetAllTopics();
        // List<post> GetAllPosts();
        // List<comments> GetAllComments();


    }
}