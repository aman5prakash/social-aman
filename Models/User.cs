
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace quizartsocial_backend.Models
{
    public class UserC{

            [Key]
            public string id{get; set;}
            public string name{get; set;}
            public string image{get; set;}
            public int score{get;set;}
            
            public List<PostC> posts{get; set;}

            public List<CommentC> comment_data{get; set;}

          
 


    }
}