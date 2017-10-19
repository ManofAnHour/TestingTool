using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TestingTool.Models
{
    public class TestCase
    {
        public class testcase
        {

            public Guid id { get; set; }
            public Guid client_idnum { get; set; }
            public Guid structure_idnum { get; set; }
            public Guid br_idnum { get; set; }
            public string testtype { get; set; }
            public string iteration { get; set; }
            public string prd { get; set; }
            public string requirement_id { get; set; }
            public string use_case { get; set; }
            public string test_case { get; set; }
            public string test_case_title { get; set; }
            public string test_case_description { get; set; }
            public string module { get; set; }
            public string feature { get; set; }
            public Guid feature_idnumber { get; set; }
            public string feature_type { get; set; }
            public string test_case_id { get; set; }
            public string test_condition { get; set; }
            public string assigned_to { get; set; }
            public string notes { get; set; }
            public string automated_yes_no { get; set; }
            public string automation_script_name { get; set; }
            public int automation_test_status = 0;
            public string regression_yes_no { get; set; }
            public DateTime aproveddate;
            public string aprovedby { get; set; }
            public Int32 testcasenum = 0;
            public Guid rorv_idnum { get; set; }
            public Guid ticket_mapping_idnum { get; set; }
            public Guid automation_test_idnum { get; set; }
            public Guid standard_test_idnum { get; set; }
            public Guid qa_test_idnum { get; set; }
            public Int32 qatestcasenum = 0;
            public string created_by { get; set; }
            public DateTime create_date;
            public string updated_by { get; set; }
            public DateTime updated_date;
            public int status;
        }
    }
}