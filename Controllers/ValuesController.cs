using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quizartsocial_backend.Models;

namespace backEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ITopic topicObj;
        

        public ValuesController(ITopic _topicObj){
            this.topicObj=_topicObj;
        }
        // GET api/values
        
        // [HttpGet]
        // public IActionResult Get()
        // {
        //     int n=1;
        //     // List<TopicC> lg=new List<TopicC>();
        //     List<PostC> lg=new List<PostC>();
        //     //List<UserC> lg=new List<UserC>();
        //     for (int i = 0; i < n; i++){
        //             // List<TopicC> tName = topicObj.GetAllTopicName();
        //             // List<TopicC> tImage = topicObj.GetAllTopicImage();
        //             // TopicC test=new TopicC();
        //             // test.topic_name=tName[0].topic_name;
        //             // test.topic_image=tImage[0].topic_image;
        //             // lg.Add(test);
        //             // topicObj.AddTopicToDB(test);
        //             // List<PostC> tPost= topicObj.GetAllPost();
        //             // PostC test=new PostC();
        //             // test.posts=tPost[0].posts;
        //             // test.TopicForeignKey=1;
        //             // test.UserForeignKey=1;
        //             // lg.Add(test);
        //             // topicObj.AddPostToDB(test);
        //             // List<UserC> tName = topicObj.GetAllUserName();
        //             // List<UserC> tImage = topicObj.GetAllUserImage();
        //             // UserC test=new UserC();
        //             // test.user_name=tName[0].user_name;
        //             // test.user_image=tImage[0].user_image;
        //             // lg.Add(test);
        //             // topicObj.AddUserToDB(test);
                    
        //    }
        //    return Ok(lg);
         
        // }
        

        
        // GET api/values/5
        [HttpGet("{title}")]
        //[Route("api/values/{id}")]
        public IActionResult Get(string title)
        {
            if(title=="cricket")
            {
                List<PostC> post_indiv = topicObj.GetAllPostsIndi(title);
                return Ok(post_indiv);
                                         
            }
            return BadRequest("Bad :p ");

        }

        

        // GET api/values/5
        /*
        [HttpGet("{id:string}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
        */

        // POST api/values
        // [HttpPost]
        // public IActionResult Post([FromBody] Object value)
        // {
        //     Console.WriteLine("hjhgjdsf");
        //     UserC userObj=new UserC();
        //     userObj.user_name="Prateek";
        //     UserC userObj1=new UserC();
        //     userObj1.user_name="Harsha";
        //     UserC userObj2=new UserC();
        //     userObj2.user_name="Kuldeep";
        //     topicObj.AddUserToDB(userObj);
        //     topicObj.AddUserToDB(userObj1);
        //     topicObj.AddUserToDB(userObj2);
        //     TopicC testTopicObj=new TopicC();
        //     testTopicObj.topic_name="Cricket";
        //     topicObj.AddTopicToDB(testTopicObj);
        //     return Ok("hjhgjdsf");
        // }

        [HttpPost("{postEntered}")]
        public IActionResult Post(string postEntered , [FromBody] PostComment value)
        {
            if(postEntered=="post")
            {
                PostC postObj=new PostC();
                postObj.posts=value.posts;
                postObj.UserForeignKey=value.UserForeignKey;
                postObj.TopicForeignKey=value.TopicForeignKey;
                topicObj.AddPostToDB(postObj);

            }

            else if(postEntered=="comment")
            {
                CommentC commentObj=new CommentC();
                commentObj.comment=value.comment;
                commentObj.PostForeignKey=value.PostForeignKey;
                commentObj.UsercomForeignKey=value.UsercomForeignKey;
                topicObj.AddCommentToDB(commentObj);

            }
            return Ok("hjhgjdsf");
        }

        

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
