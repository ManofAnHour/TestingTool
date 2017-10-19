using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using TestingTool.Models;
using System.Diagnostics;

namespace TestingTool.Controllers.APIControllers
{
    [System.Web.Http.RoutePrefix("api/TestCases")]
    public class TestCasesController : ApiController
    {
        // GET: api/TestCases
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TestCases/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("TestCase")]
        [HttpPost]
        public HttpResponseMessage AddTestCase([FromBody]TestCase.testcase item, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            item.id = Guid.NewGuid();
            
            DataAccess.testCaseData data = new DataAccess.testCaseData();
            Guid ID_Num = data.Maintain_TestCase(item, username);


            H.Content = new StringContent(Convert.ToString(ID_Num));
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }
        [Route("TestCase")]
        [HttpPut]
        public HttpResponseMessage MainTainTestCase([FromBody]TestCase.testcase item, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testCaseData data = new DataAccess.testCaseData();
            Guid ID_Num = data.Maintain_TestCase(item, username);
            
            H.Content = new StringContent(Convert.ToString(ID_Num));
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }
        
        // DELETE: api/TestCases/5
        public void Delete(int id)
        {
        }
    }
}
