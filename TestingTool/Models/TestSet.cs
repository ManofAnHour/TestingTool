using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingTool.Models
{
    public class TestSet
    {
        public class Test_Set
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int testset_id = 0;
            public int Status = 0;
        }

        public class Test_Sets
        {
            public List<Models.TestSet.Test_Set> testsets { get; set; }
        }

        public class Test_Mapping
        {
            public Guid Id { get; set; }
            public Guid Test_Id { get; set; }
            public Guid Test_Set_Id { get; set; }
            public string TestCase_Title { get; set; }
            public int Order_Number = 0;
            public int Status = 0;
        }
        

    }
}