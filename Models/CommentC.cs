using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace quizartsocial_backend.Models
{
    public class CommentC{

        [Key]
        public int comment_id{get; set;}

    //    public int user_id{get;set;}

        public string comment{get; set;}

        // public post post { get; set; }

        // public user user { get; set; }

        public int PostForeignKey { get; set; }
        public string UsercomForeignKey { get; set; }



    }
}