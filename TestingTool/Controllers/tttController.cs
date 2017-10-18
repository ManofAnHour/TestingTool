using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestingTool.Controllers
{
    public class tttController : ApiController
    {
        // GET: api/ttt
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ttt/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ttt
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ttt/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ttt/5
        public void Delete(int id)
        {
        }
    }
}
