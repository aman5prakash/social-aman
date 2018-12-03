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
    public class SocialController : ControllerBase
    {
        ITopic topicObj;
        public SocialController(ITopic _topicObj)
        {
            this.topicObj=_topicObj;
            //topicObj.GetTopicsFromRabbitMQ();
        }
       
        [HttpGet("topics")]
        public async Task<IActionResult> GetTopics()
        {
            // topicObj.GetTopicsFromRabbitMQ();
            List<Topic> allTopics = await topicObj.FetchTopicsFromDbAsync();
            return Ok(allTopics);
        }

        [HttpGet]
        [Route("posts/{topicName}")]
        public async Task<IActionResult> GetPosts(string topicName)
        {
            List<Post> posts = await topicObj.GetPostsAsync(topicName);
            if(posts.Any())
            {
                return Ok(posts);                      
            }
            else
            {
                return NotFound();
            } 
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            await topicObj.AddPostToDBAsync(post);
            return Ok();
        }

        [HttpPost]
        [Route("comment")]
        public async Task<IActionResult> CreateComment([FromBody] Comment comment)
        {
            await topicObj.AddCommentToDBAsync(comment);
            return Ok();
        }          
        
        [HttpPost]
        [Route("user")]
        public IActionResult CreateUser([FromBody] User value)
        {            
            topicObj.AddUserToDBAsync(value);
            return Ok();
        }

        [HttpDelete]
        [Route("topic/{topicName}")]
        public IActionResult Deletetopic([FromRoute] string topicName)
        {
            topicObj.DelTopicFromDBAsync(topicName);
            return Ok();
        }
    }
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
        //[Route("api/values/{id}")]
        // GET api/values/5
         // GET api/values/5
        /*
        [HttpGet("{id:string}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
        */
         // PUT api/values/5
         
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }

        //   [HttpPost]
        // [Route("topics")]
        // public IActionResult AllTopics([FromBody] Object value)
        // {
        //     Task<List<string>> topicReturns = System.Threading.Tasks.Task<string>.Run(() => topicObj.fetchTopicAsync().Result);
        //     List<string> topicList = topicReturns.Result;
        //     // JObject jo = (JObject)(value);
        //     // string ttt = jo["topicName"].ToString();
        //     // Console.WriteLine(ttt);
        //       for(int i=0;i<topicList.Count;i++){
        //           Topic test=new Topic();
        //           test.topicName=topicList[i];
        //           topicObj.AddTopicToDB(test);
        //       }
        //       return Ok();
        // }
        
