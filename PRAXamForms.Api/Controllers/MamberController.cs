using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PRAXamForms.Api.Controllers
{
    public class MamberController : ApiController
    {
        // GET api/mamber
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/mamber/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/mamber
        public void Post([FromBody]string value)
        {
        }

        // PUT api/mamber/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/mamber/5
        public void Delete(int id)
        {
        }
    }
}
