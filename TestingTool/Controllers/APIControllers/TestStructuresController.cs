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
    [System.Web.Http.RoutePrefix("api/TestStructures")]
    public class TestStructuresController : ApiController
    {
        // GET: api/TestStructures
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TestStructures/5
        public HttpResponseMessage Get(Guid parent_ID)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testStructureData data = new DataAccess.testStructureData();
            TestLevels.TestStructures list = new TestLevels.TestStructures();
            list = data.GetStructure(parent_ID);

            var collection = list;

            dynamic collectionWrapper = new
            {
                structures = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        [Route("TopLevels")]
        [HttpGet]
        public HttpResponseMessage GetFirstLevels()
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testStructureData data = new DataAccess.testStructureData();
            List<TestLevels.TestStructures> list = new List<TestLevels.TestStructures>();
            list = data.GetTopStructures();

            var collection = list;

            dynamic collectionWrapper = new
            {
                structures = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        [Route("TopLevels")]
        [HttpPost]
        public HttpResponseMessage AddFirstLevel([FromBody]TestLevels.TestStructures item, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            item.id = Guid.NewGuid();
            item.Parent_IDNumber = new Guid();

            DataAccess.testStructureData data = new DataAccess.testStructureData();
            Guid ID_Num = data.Maintain_Level(item, username);


            H.Content = new StringContent(Convert.ToString(ID_Num));
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }
        // POST: api/TestStructures

        [Route("Levels")]
        [HttpPost]
        public HttpResponseMessage AddLevel([FromBody]TestLevels.TestStructures item, [FromUri]string username)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            item.id = Guid.NewGuid();

            DataAccess.testStructureData data = new DataAccess.testStructureData();
            Guid ID_Num = data.Maintain_Level(item, username);


            H.Content = new StringContent(Convert.ToString(ID_Num));
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }
        // POST: api/TestStructures
        [Route("Levels")]
        [HttpGet]
        public HttpResponseMessage GetLevels(Guid parent_ID)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testStructureData data = new DataAccess.testStructureData();
            List<TestLevels.TestStructures> list = new List<TestLevels.TestStructures>();
            list = data.GetChildStructures(parent_ID);

            var collection = list;

            dynamic collectionWrapper = new
            {
                structures = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }
        [Route("{id}/Tests")]
        [HttpGet]
        public HttpResponseMessage GetTests(Guid id)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testStructureData data = new DataAccess.testStructureData();
            List<TestCase.testcase> list = new List<TestCase.testcase>();
            list = data.GetStructuresTestCases(id);

            var collection = list;

            dynamic collectionWrapper = new
            {
                tests = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }



        [Route("Hiarchy")]
        [HttpGet]
        public HttpResponseMessage GetHiarchy(Guid self_ID)
        {
            HttpResponseMessage H = new HttpResponseMessage();

            DataAccess.testStructureData data = new DataAccess.testStructureData();
            List<TestLevels.TestStructures> list = new List<TestLevels.TestStructures>();

            while (1 != 2)
            {
                try
                {
                    list = TryToDoChildren(list, self_ID);
                    var MAXLevel = list.Max(x => x.Level);
                    var MaxTest = list.Where(p => p.Level == MAXLevel);

                    TestLevels.TestStructures item = MaxTest.FirstOrDefault();
                    if (item.Parent_IDNumber == new Guid())
                    { break; }
                }
                catch { break; }
            }
            
            var collection = list;

            dynamic collectionWrapper = new
            {
                structures = collection
            };

            var output = JsonConvert.SerializeObject(collectionWrapper);

            JsonSerializerSettings JSS = new JsonSerializerSettings();

            H.Content = new StringContent(output);
            H.StatusCode = HttpStatusCode.OK;

            return H;
        }

        public List<TestLevels.TestStructures> TryToDoChildren(List<TestLevels.TestStructures>List , Guid ID_Num)
        {
            DataAccess.testStructureData data = new DataAccess.testStructureData();
            TestLevels.TestStructures item = new TestLevels.TestStructures();
            if (List.Count == 0)
            {
                Debug.WriteLine("LOL");
                item = data.GetStructure(ID_Num);
                item.Level = 1;
                List.Add(item);
            }
            else if(List.Count >= 1)
            {
                Debug.WriteLine("LOL111");
                var MAXLevel = List.Max(x => x.Level);
                var MaxTest = List.Where(p => p.Level == MAXLevel);
                
                item = MaxTest.FirstOrDefault();
                int NewLevel = item.Level + 1;
                
                TestLevels.TestStructures NewAddedItem = data.GetStructure(item.Parent_IDNumber);
                NewAddedItem.Level = NewLevel;
                List.Add(NewAddedItem);
                

            }

            return List;
        }


        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TestStructures/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TestStructures/5
        public void Delete(int id)
        {
        }
    }
}
