using System;
using Bogus;
using System.Linq;
using System.Collections.Generic;
using quizartsocial_backend.Models;

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

        public void AddTopicToDB(TopicC obj){

            context.TopicT.Add(obj);
            context.SaveChanges();

        }
        /*
        public List<post> GetAllPosts()
        {

        }

        public List<comments> GetAllComments()
        {

        }
        */      
    }


}