using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdUserSite._03_WebApi
{
    [Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpGet("{namen}")]
        public string Get(string namen)
        {
            var x = namen;
            return x;
        }
        [Route("users/{name}")]
        public string GetUser(string name)
        {
            var x = name;
            return x;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see http://go.microsoft.com/fwlink/?LinkID=717803
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see http://go.microsoft.com/fwlink/?LinkID=717803
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see http://go.microsoft.com/fwlink/?LinkID=717803
        }
    }
}
