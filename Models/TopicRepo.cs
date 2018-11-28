using System;
using Bogus;
using System.Linq;
using System.Collections.Generic;
using quizartsocial_backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace quizartsocial_backend{

    public class TopicRepo : ITopic
    {
        efmodel context=null;

        public TopicRepo(efmodel _context){
            this.context=_context;
        }

        /*
        public List<Topic> GetAllTopicImage()
        {
             var userFaker = new Faker<Topic>()
            //.RuleFor(t => t.topic_image, f => f.Image.People());
            .RuleFor(t => t.topic_image, f => f.Internet.Avatar());
            var users = userFaker.Generate(1);

            return users;
        }
        

        public List<Topic> GetAllTopicName()
        {
             var userFaker1 = new Faker<Topic>()
            .RuleFor(t => t.topic_name, f => f.Name.FirstName());
            var myusers = userFaker1.Generate(1);


            return myusers;

        }

        public List<Post> GetAllPost()
        {
             var userFaker2 = new Faker<Post>()
            .RuleFor(t => t.posts, f => f.Lorem.Sentence());
            var myusers = userFaker2.Generate(1);


            return myusers;

        }
        */

        // public List<UserC> GetAllUserImage()
        // {
        //      var userFaker3 = new Faker<UserC>()
        //     //.RuleFor(t => t.topic_image, f => f.Image.People());
        //     .RuleFor(t => t.user_image, f => f.Internet.Avatar());
        //     var users = userFaker3.Generate(1);

        //     return users;
        // }
        

        // public List<UserC> GetAllUserName()
        // {
        //      var userFaker4 = new Faker<UserC>()
        //     .RuleFor(t => t.user_name, f => f.Name.FirstName());
        //     var myusers = userFaker4.Generate(1);


        //     return myusers;

        // }

        public List<Post> GetPosts(string topic){
                
                List<Topic> res=context.Topics
                            .Where(s=>(s.topic_name==topic))
                            .ToList();
                int id=res[0].topic_id;
                List<Post> res1=context.Posts
                            .Where(s=>(s.TopicForeignKey==id))
                            .Include("comment_data")
                            .ToList();

                return res1;
        }

        public void AddUser(User value){
                User userObj = new User();
                userObj.id=value.id;
                userObj.image=value.image;
                userObj.name=value.name;
                if(context.Users.FirstOrDefault( n => n.id == value.id) == null){
                    AddUserToDB(userObj);
                }
        }

        public List<Topic> GetAllTopics(){
                List<Topic> res=context.Topics.ToList();
                return res;
        }

        public void AddTopicToDB(Topic obj){
                if(context.Topics.FirstOrDefault( n => n.topic_name == obj.topic_name) == null)
                {
                    context.Topics.Add(obj);
                    context.SaveChanges();
                }

        }

         public void AddPostToDB(Post obj){

            context.Posts.Add(obj);
            context.SaveChanges();

        }

         public void AddUserToDB(User obj){

            context.Users.Add(obj);
            context.SaveChanges();

        }

        public void AddCommentToDB(Comment obj){

            context.Comments.Add(obj);
            context.SaveChanges();

        }

        public async Task<List<string>> fetchTopicAsync(){
             string topicUrl = "http://172.23.238.164:8080/api/quizrt/topics";
            //The 'using' will help to prevent memory leaks.
            //Create a new instance of HttpClient
            List<string> lg=new List<string>();
             using (HttpClient client = new HttpClient())
             
            //Setting up the response...         
            using (HttpResponseMessage res = await client.GetAsync(topicUrl))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
               // Console.WriteLine(data+"prateeeeeeeeeeeeeeeeeeeeeeek");
                //data = data.Trim( new Char[] { '[',']' } );
                 JArray json = JArray.Parse(data);
                 // Console.WriteLine(json+"jkfsfjksfjsjfhskhfks");
                // string ret;
                // if (data != null)
                // {
                //     for(int i=0;i<json.Count;i++)
                //     {
                //         ret=(string)json[i]["topicName"];
                //         if(!(lg.Contains(ret)))
                //         lg.Add(ret);
                //     }
                // }
                string value;
                if(data!=null){
                    for(int i=0;i<json.Count;i++)
                    {
                        value=(string)json[i];
                        if(!(lg.Contains(value)))
                        {
                            lg.Add(value);
                        }
                    //    Console.WriteLine(json[i]);
                    }
                }
                return lg;
        }
        }
        
        
        /* 
        public List<comments> GetAllComments()
        {

        }
        */      
    }


}
