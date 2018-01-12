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
        public HttpResponseMessage Get(Guid id)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testCaseData data = new DataAccess.testCaseData();
            List<TestCase.testcase> list = new List<TestCase.testcase>();
            list = data.GetTestCase(id);

            var collection = list;

            dynamic collectionWrapper = new
            {
                testcases = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        [Route("TestCase")]
        [HttpPost]
        public HttpResponseMessage AddTestCase([FromBody]TestCase.testcase item, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            item.id = Guid.NewGuid();
            item.status = 1;
            
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



        [Route("TestCase/{testcase_id}/TestSteps")]
        [HttpGet]
        public HttpResponseMessage GetTestSteps(Guid testcase_id)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testCaseData data = new DataAccess.testCaseData();
            List<TestCase.Test_step> list = new List<TestCase.Test_step>();
            list = data.GetTestSteps(testcase_id);

            var collection = list;

            dynamic collectionWrapper = new
            {
                teststeps = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        [Route("TestCase/{testcase_id}/TestSteps")]
        [HttpPost]
        public HttpResponseMessage AddTestSteps([FromBody]TestCase.Test_step item, Guid testcase_id, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            item.Id = Guid.NewGuid();
            item.Test_case_id = testcase_id;
            
            DataAccess.testCaseData data = new DataAccess.testCaseData();
            Guid ID_Num = data.Maintain_TestCase_Step(item, username);

            H.Content = new StringContent(Convert.ToString(ID_Num));
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }
        [Route("TestCase/{testcase_id}/TestSteps")]
        [HttpPut]
        public HttpResponseMessage MainTainTestSteps([FromBody]TestCase.Test_step item, Guid testcase_id, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testCaseData data = new DataAccess.testCaseData();
            Guid ID_Num = data.Maintain_TestCase_Step(item, username);

            H.Content = new StringContent(Convert.ToString(ID_Num));
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        [Route("TestCase/TestSteps/{teststep_id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteTestStep(Guid teststep_id, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();
            Models.TestCase.Test_step item = new TestCase.Test_step { Status = -1, Id = teststep_id };
            DataAccess.testCaseData data = new DataAccess.testCaseData();
            Guid ID_Num = data.Maintain_TestCase_Step(item, username);

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
