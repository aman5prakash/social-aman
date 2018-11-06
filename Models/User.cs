
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace quizartsocial_backend.Models
{
    public class UserC{

            [Key]
            public int user_id{get; set;}
            public string user_name{get; set;}
            public string user_image{get; set;}
            
            public List<PostC> posts{get; set;}

            public List<CommentC> comment_data{get; set;}

          
 


    }
}