using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using RestSharp;
using TestingTool.Models;
using TestingTool.DataAccess;

namespace TestingTool.Controllers.APIControllers
{
    [System.Web.Http.RoutePrefix("api/Automation")]
    public class AutomationController : ApiController
    {
        // GET: api/Automation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Automation/5
        [Route("Run/{id}")]
        [HttpGet]
        public HttpResponseMessage GetItem(Guid id)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.automationData data = new DataAccess.automationData();
            List<Automation.Test_Run> list = new List<Automation.Test_Run>();
            list = data.GetTestRun(id);

            var collection = list;

            dynamic collectionWrapper = new
            {
                runs = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        [Route("Run")]
        [HttpPost]
        public HttpResponseMessage AddTestSet([FromBody]Automation.Test_Run item, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            item.idnum = Guid.NewGuid();
            item.Status = 1;

            DataAccess.automationData data = new DataAccess.automationData();
            Guid ID_Num = data.Maintain_TestRun(item, username);
            
            H.Content = new StringContent(Convert.ToString(ID_Num));
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }
        
        // GET: api/Automation/5
        [Route("Run/Note/{id}")]
        [HttpGet]
        public HttpResponseMessage GetRunNote(Guid id)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.automationData data = new DataAccess.automationData();
            List<Automation.Test_Run_Notes> list = new List<Automation.Test_Run_Notes>();
            list = data.GetRunNote(id);

            var collection = list;

            dynamic collectionWrapper = new
            {
                runnotes = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        [Route("Run/Note")]
        [HttpPost]
        public HttpResponseMessage AddRunNote([FromBody]Automation.Test_Run_Notes item, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            item.idnum = Guid.NewGuid();
            item.Status = 1;

            DataAccess.automationData data = new DataAccess.automationData();
            Guid ID_Num = data.Maintain_RunNotes(item, username);

            H.Content = new StringContent(Convert.ToString(ID_Num));
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }



        // GET: api/Automation/5
        [Route("Run/Item/{id}")]
        [HttpGet]
        public HttpResponseMessage GetRunItem(Guid id)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.automationData data = new DataAccess.automationData();
            List<Automation.Test_Run_Item> list = new List<Automation.Test_Run_Item>();
            list = data.GetRunItem(id);

            var collection = list;

            dynamic collectionWrapper = new
            {
                runitems = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        [Route("Run/{Run_id}/Item")]
        [HttpPost]
        public HttpResponseMessage AddRunItem([FromBody]Automation.Test_Run_Item item, Guid Run_id, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            item.idnum = Guid.NewGuid();
            item.run_idnum = Run_id;
            item.Status = 1;

            DataAccess.automationData data = new DataAccess.automationData();
            Guid ID_Num = data.Maintain_RunItem(item, username);

            H.Content = new StringContent(Convert.ToString(ID_Num));
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        [Route("{TestSet}/Start")]
        [HttpPost]
        public HttpResponseMessage StartTestSet(string TestSet, [FromUri]string username)
        {
            Models.TestSet.Test_Set test_Set;
            List<Models.TestCase.testcase> testCases;
            HttpResponseMessage H = new HttpResponseMessage();

            var clieNt = new RestClient(conFIG.testingTool + "api/TestSet/");

            var request = new RestRequest(Method.GET);
            request.AddQueryParameter("TestSetName", TestSet);

            var response = clieNt.Execute(request);
            string L = response.Content;

            var resultsJSON = JsonConvert.DeserializeObject<Models.TestSet.Test_Sets>(L);
            if (resultsJSON.testsets.Count >= 1)
            {
                test_Set = resultsJSON.testsets[0];


            }


            //    item.idnum = Guid.NewGuid();
            //    item.run_idnum = Run_id;
            //    item.Status = 1;

            //    DataAccess.automationData data = new DataAccess.automationData();
            //    Guid ID_Num = data.Maintain_RunItem(item, username);

            //    H.Content = new StringContent(Convert.ToString(ID_Num));
                H.StatusCode = HttpStatusCode.OK;

                return H;
        }


        // PUT: api/Automation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Automation/5
        public void Delete(int id)
        {
        }
    }
}
