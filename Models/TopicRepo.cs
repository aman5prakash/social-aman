using System;
using Bogus;
using System.Linq;
using System.Collections.Generic;
using quizartsocial_backend.Models;
using Microsoft.EntityFrameworkCore;

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

        public List<UserC> GetAllUserImage()
        {
             var userFaker3 = new Faker<UserC>()
            //.RuleFor(t => t.topic_image, f => f.Image.People());
            .RuleFor(t => t.user_image, f => f.Internet.Avatar());
            var users = userFaker3.Generate(1);

            return users;
        }
        

        public List<UserC> GetAllUserName()
        {
             var userFaker4 = new Faker<UserC>()
            .RuleFor(t => t.user_name, f => f.Name.FirstName());
            var myusers = userFaker4.Generate(1);


            return myusers;

        }

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

        public void AddTopicToDB(TopicC obj){

            context.TopicT.Add(obj);
            context.SaveChanges();

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
        
        
        /* 
        public List<comments> GetAllComments()
        {

        }
        */      
    }


}