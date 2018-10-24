
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace quizartsocial_backend.Models
{
    public class category{

            [Key]
            public int topic_id{get; set;}
            public string topic_name{get; set;}

            public List<post> posts{get; set;}


    }
}