
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace quizartsocial_backend.Models
{
    public class TopicC{

            [Key]
            public int topic_id{get; set;}
            public string topic_name{get; set;}
            public string topic_image{get; set;}
            public List<PostC> posts{get; set;}
            


    }
}