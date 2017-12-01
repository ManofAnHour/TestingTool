using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingTool.Models
{
    public class Automation
    {
        public class Test_Run
        {
            public Guid idnum { get; set; }
            public Guid testset_idnum { get; set; }
            public string notes { get; set; }
            public int id = 0;
            public int Status = 0;
        }
        public class Test_Run_Notes
        {
            public Guid idnum { get; set; }
            public Guid run_idnum { get; set; }
            public Guid testset_idnum { get; set; }
            public Guid test_idnum { get; set; }
            public string notes { get; set; }
            public string method_name { get; set; }
            public int id = 0;
            public int Status = 0;
        }
        public class Test_Run_Item
        {
            public Guid idnum { get; set; }
            public Guid run_idnum { get; set; }
            public Guid testset_idnum { get; set; }
            public Guid test_idnum { get; set; }
            public string method_name { get; set; }
            public int item_number = 0;
            public int Status = 0;
        }
    }
}