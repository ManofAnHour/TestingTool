using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services;
using Newtonsoft.Json;


namespace TestingTool.Controllers
{
    [System.Web.Http.RoutePrefix("api/TestCase")]
    public class TestCaseController : ApiController
    {
        // GET: api/TestCase
        [Route("GetApplications")]
        [HttpGet]
        public HttpResponseMessage GetApplications()
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testStructureData data = new DataAccess.testStructureData();
            List<Models.Application> list = new List<Models.Application>();
            list = data.GetApplications();

            var collection = list;

            dynamic collectionWrapper = new
            {
                applications = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;
            
            return H;
        }

        [Route("GetApplications")]
        [HttpGet]
        public string GetFirst(string applicationName)
        {
            List<string> L = new List<string>();

            L.Add("Global LaborView");
            L.Add("Geo Skill");
            return Newtonsoft.Json.JsonConvert.SerializeObject(L);
        }



        [Route("GetDate")]
        [HttpGet]
        public string GetDate()
        {
            DataAccess.testStructureData tt = new DataAccess.testStructureData();
            string This = "";
            
            return This;
        }

        // GET: api/TestCase/5
        public string Get(int id)
        {
            if (id >= 1)
                return Convert.ToString(id + 9);
            else return Convert.ToString(id);
        }

        // POST: api/TestCase
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TestCase/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TestCase/5
        public void Delete(int id)
        {
        }



        [HttpGet]
        public static string HelloWorld(string name)
        {
            return string.Format("Hi {0}", name);
        }
    }
}
