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


        public List<TopicC> GetAllTopicImage()
        {
             var userFaker = new Faker<TopicC>()
            //.RuleFor(t => t.topic_image, f => f.Image.People());
            .RuleFor(t => t.topic_image, f => f.Internet.Avatar());
            var users = userFaker.Generate(1);

            return users;
        }
        

        public List<TopicC> GetAllTopicName()
        {
             var userFaker1 = new Faker<TopicC>()
            .RuleFor(t => t.topic_name, f => f.Name.FirstName());
            var myusers = userFaker1.Generate(1);


            return myusers;

        }

        public List<PostC> GetAllPost()
        {
             var userFaker2 = new Faker<PostC>()
            .RuleFor(t => t.posts, f => f.Lorem.Sentence());
            var myusers = userFaker2.Generate(1);


            return myusers;

        }

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

        public List<PostC> GetAllPostsIndi(string topic){
                
                List<TopicC> res=context.TopicT
                            .Where(s=>(s.topic_name==topic))
                            .ToList();
                int id=res[0].topic_id;
                List<PostC> res1=context.PostT
                            .Where(s=>(s.TopicForeignKey==id))
                            .Include("comment_data")
                            .ToList();

                return res1;
        }

        public void AddUser(UserC value){
                UserC userObj = new UserC();
                userObj.id=value.id;
                userObj.image=value.image;
                userObj.name=value.name;
                if(context.UserT.FirstOrDefault( n => n.id == value.id) == null){
                    AddUserToDB(userObj);
                }
        }

        public List<TopicC> GetAllTopics(){
                List<TopicC> res=context.TopicT.ToList();
                return res;
        }

        public void AddTopicToDB(TopicC obj){
                if(context.TopicT.FirstOrDefault( n => n.topic_name == obj.topic_name) == null)
                {
                    context.TopicT.Add(obj);
                    context.SaveChanges();
                }

        }

         public void AddPostToDB(PostC obj){

            context.PostT.Add(obj);
            context.SaveChanges();

        }

         public void AddUserToDB(UserC obj){

            context.UserT.Add(obj);
            context.SaveChanges();

        }

        public void AddCommentToDB(CommentC obj){

            context.CommentT.Add(obj);
            context.SaveChanges();

        }

        public async Task<List<string>> fetchTopicAsync(){
             string topicUrl = "http://172.23.238.164:8080/api/quizrt/template";
            //The 'using' will help to prevent memory leaks.
            //Create a new instance of HttpClient
            List<string> lg=new List<string>();
             using (HttpClient client = new HttpClient())
             
            //Setting up the response...         
            using (HttpResponseMessage res = await client.GetAsync(topicUrl))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                Console.WriteLine(data+"harshaaaaaaaaaaaa");
                //data = data.Trim( new Char[] { '[',']' } );
                JArray json = JArray.Parse(data);
                // Console.WriteLine(data+"jkfsfjksfjsjfhskhfks");
                string ret;
                if (data != null)
                {
                    for(int i=0;i<json.Count;i++)
                    {
                        ret=(string)json[i]["topicName"];
                        if(!(lg.Contains(ret)))
                        lg.Add(ret);
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
