using System;
using Bogus;
using System.Linq;
using System.Collections.Generic;
using quizartsocial_backend.Models;

namespace quizartsocial_backend{

    public class TopicRepo : ITopic
    {
        public List<category> GetAllTopicImage()
        {
             var userFaker = new Faker<category>()
            //.RuleFor(t => t.topic_image, f => f.Image.People());
            .RuleFor(t => t.topic_image, f => f.Internet.Avatar());
            var users = userFaker.Generate(10);

            return users;
        }
        

        public List<category> GetAllTopicName()
        {
             var userFaker1 = new Faker<category>()
            .RuleFor(t => t.topic_name, f => f.Name.FirstName());
            var myusers = userFaker1.Generate(10);

            return myusers;

        }
    }


}