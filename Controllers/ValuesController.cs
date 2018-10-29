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
        
        [HttpGet]
        public IActionResult Get()
        {
            int n=10;
            List<category> lg=new List<category>(10);
           // return new string[] { "value1", "value2" };
           Console.WriteLine("--------qqqqqqqqqq");
           for (int i = 0; i < n; i++){
                    List<category> tName = topicObj.GetAllTopicName();
                    List<category> tImage = topicObj.GetAllTopicImage();
                       Console.WriteLine(tName[0].topic_name);
                       Console.WriteLine(tImage[0].topic_image);
                    //    lg[i].topic_name=tName[0].topic_name;
                    //    lg[i].topic_image=tImage[0].topic_image;
                    //    lg.Add(tName[0].topic_name,tImage[0].topic_image);
           }

            return Ok(lg);

        }
        

        /* 
        // GET api/values/5
        [HttpGet("{title}")]
        //[Route("api/values/{id}")]
        public IActionResult Get(string title, [FromQuery] string type)
        {
            if(type=="name")
            {
                List<category> topicName = topicObj.GetAllTopicName();
                return Ok(topicName);
                                         
            }

            else if(type=="image")
            {
                List<category> topicImage = topicObj.GetAllTopicImage();
                return Ok(topicImage);

            }
            return Ok();
           
        }

        */

        // GET api/values/5
        /*
        [HttpGet("{id:string}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
        */

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
