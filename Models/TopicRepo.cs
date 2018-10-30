using System;
using Bogus;
using System.Linq;
using System.Collections.Generic;
using quizartsocial_backend.Models;

namespace quizartsocial_backend{

    public class TopicRepo : ITopic
    {
        ITopic topicObj;
        efmodel context;

        public TopicRepo(ITopic _topicObj,efmodel _context){
            this.topicObj=_topicObj;
            this.context=_context;
        }

        public List<category> GetAllTopics()
        {
            int n=50;
            List<category> lg=new List<category>();
            for (int i = 0; i < n; i++){
                    List<category> tName = topicObj.GetAllTopicName();
                    List<category> tImage = topicObj.GetAllTopicImage();
                    category test=new category();
                    test.topic_name=tName[0].topic_name;
                    test.topic_image=tImage[0].topic_image;
                    lg.Add(test);
                    context.category_table.Add(test);
                    context.SaveChanges();
           }
           return lg;
        }

        public List<category> GetAllTopicImage()
        {
             var userFaker = new Faker<category>()
            //.RuleFor(t => t.topic_image, f => f.Image.People());
            .RuleFor(t => t.topic_image, f => f.Internet.Avatar());
            var users = userFaker.Generate(1);

            return users;
        }
        

        public List<category> GetAllTopicName()
        {
             var userFaker1 = new Faker<category>()
            .RuleFor(t => t.topic_name, f => f.Name.FirstName());
            var myusers = userFaker1.Generate(1);


            return myusers;

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