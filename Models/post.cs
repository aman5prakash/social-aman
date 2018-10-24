using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizartsocial_backend.Models
{
    public class post{

        [Key]
        public int post_id{get; set;}

        public int topic_id{get; set;}

        public string posts{get; set;}
        public List<comments> comment_data{get; set;}
    

    }
}