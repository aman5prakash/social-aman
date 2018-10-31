using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizartsocial_backend.Models
{
    public class PostC{

        [Key]
        public int post_id{get; set;}

        // public int topic_id{get; set;}
      //  public int user_id{get;set;}

        public string posts{get; set;}
        public List<CommentC> comment_data{get; set;}

        public int TopicForeignKey { get; set; }
        // public category category { get; set; }

        public int UserForeignKey { get; set; }
        // public user user { get; set; }
    }
}