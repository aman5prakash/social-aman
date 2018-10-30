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
        efmodel context;

        public ValuesController(ITopic _topicObj,efmodel _context){
            this.topicObj=_topicObj;
            this.context=_context;
        }
        // GET api/values
        
        [HttpGet]
        public IActionResult Get()
        {

         return Ok(topicObj.GetAllTopics());
         
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
