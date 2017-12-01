using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestingTool.Models;
using Newtonsoft.Json;

namespace TestingTool.Controllers.APIControllers
{
    [System.Web.Http.RoutePrefix("api/TestSet")]
    public class TestSetController : ApiController
    {
        // GET: api/TestSet
        public HttpResponseMessage Get()
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testSetData data = new DataAccess.testSetData();
            List<TestSet.Test_Set> list = new List<TestSet.Test_Set>();
            list = data.GetTestSets();

            var collection = list;

            dynamic collectionWrapper = new
            {
                testsets = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }


        
        [HttpGet]
        public HttpResponseMessage GetTestSet([FromUri]string TestSetName)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testSetData data = new DataAccess.testSetData();
            List<TestSet.Test_Set> list = new List<TestSet.Test_Set>();
            string parameter = "testset_title";
            string query = @"select * from qadata.ref_testset where " + parameter + @" = @EqualsWhat";
            
            list = data.GetTestSet(query, "Varchar", TestSetName);

            var collection = list;

            dynamic collectionWrapper = new
            {
                testsets = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        // GET: api/TestSet/5
        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage GetItem(Guid id)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testSetData data = new DataAccess.testSetData();
            List<TestSet.Test_Set> list = new List<TestSet.Test_Set>();
            list = data.GetTestSet(id);

            var collection = list;

            dynamic collectionWrapper = new
            {
                testsets = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        [Route("{id}/Mappings")]
        [HttpGet]
        public HttpResponseMessage GetTestSetMappings(Guid id)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testSetData data = new DataAccess.testSetData();
            List<TestSet.Test_Mapping> list = new List<TestSet.Test_Mapping>();
            list = data.GetTestSetsCases(id);

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


        [HttpPost]
        public HttpResponseMessage AddTestSet([FromBody]TestSet.Test_Set item, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            item.Id = Guid.NewGuid();
            item.Status = 1;

            DataAccess.testSetData data = new DataAccess.testSetData();
            Guid ID_Num = data.Maintain_TestSet(item, username);


            H.Content = new StringContent(Convert.ToString(ID_Num));
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }


        [Route("{id}")]
        [HttpPut]
        public HttpResponseMessage MainTainTestSet(Guid id,[FromBody]TestSet.Test_Set item, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            item.Id = id;

            DataAccess.testSetData data = new DataAccess.testSetData();
            Guid ID_Num = data.Maintain_TestSet(item, username);

            H.Content = new StringContent(Convert.ToString(ID_Num));
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        [Route("{id}/TestCaseMapping")]
        [HttpPut]
        public HttpResponseMessage Maintain_TestSet(Guid id, [FromBody]TestSet.Test_Mapping item, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            item.Test_Set_Id = id;

            DataAccess.testSetData data = new DataAccess.testSetData();
            Guid ID_Num = data.Maintain_TestSet_Mapping(item, username);

            H.Content = new StringContent(Convert.ToString(ID_Num));
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }
        [Route("{id}/TestCaseMapping")]
        [HttpPost]
        public HttpResponseMessage New_TestSet(Guid id, [FromBody]TestSet.Test_Mapping item, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            item.Test_Set_Id = id;
            item.Id = Guid.NewGuid();

            DataAccess.testSetData data = new DataAccess.testSetData();
            Guid ID_Num = data.Maintain_TestSet_Mapping(item, username);

            H.Content = new StringContent(Convert.ToString(ID_Num));
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        // DELETE: api/TestSet/5
        public void Delete(int id)
        {
        }
    }
}
