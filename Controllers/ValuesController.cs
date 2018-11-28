using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using quizartsocial_backend.Models;

namespace backEnd.Controllers
{
    [Route("api")]
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
        [HttpGet("topics")]
        //[Route("api/values/{id}")]
        public IActionResult AllTopics()
        {  
                List<Topic> allTopics=topicObj.GetAllTopics();
                return Ok(allTopics);
        }

        [HttpGet]
        [Route("posts/{title}")]
         public IActionResult Posts(string title)
        {
                List<Post> post_data = topicObj.GetPosts(title);
                if(post_data.Any())
                {
                    return Ok(post_data);                      
                }
                else
                {
                    return BadRequest(":p");
                } 
        }
            // return BadRequest("Bad :p ");

        // GET api/values/5
        /*
        [HttpGet("{id:string}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
        */

        //POST api/values
        
        [HttpPost]
        [Route("topics")]
        public void AllTopics([FromBody] Object value)
        {
            Task<List<string>> topicReturns = System.Threading.Tasks.Task<string>.Run(() => topicObj.fetchTopicAsync().Result);
            List<string> topicList = topicReturns.Result;
            // JObject jo = (JObject)(value);
            // string ttt = jo["topicName"].ToString();
            // Console.WriteLine(ttt);
              for(int i=0;i<topicList.Count;i++){
                  Topic test=new Topic();
                  test.topic_name=topicList[i];
                  topicObj.AddTopicToDB(test);
              }
        }

        [HttpPost]
        [Route("post")]
        public void PostOfTopic(string postEntered , [FromBody] Post value)
        {
                Post postObj=new Post();
                postObj.posts=value.posts;
                postObj.UserForeignKey=value.UserForeignKey;
                postObj.TopicForeignKey=value.TopicForeignKey;
                topicObj.AddPostToDB(postObj);
        }

        [HttpPost]
        [Route("comment")]
        public void CommentOfPost(string postEntered , [FromBody] Comment value)
        {
                Comment commentObj=new Comment();
                commentObj.comment=value.comment;
                commentObj.PostForeignKey=value.PostForeignKey;
                commentObj.UsercomForeignKey=value.UsercomForeignKey;
                topicObj.AddCommentToDB(commentObj);
        }          
        

        [HttpPost]
        [Route("user")]
         public void Users([FromBody] User value)
        {            
                topicObj.AddUser(value);       
                //return Ok("hjhgjdsf");
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
