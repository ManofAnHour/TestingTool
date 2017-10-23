using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Npgsql;

using RestSharp;
using Newtonsoft.Json;

namespace TestingTool.DataAccess
{
    public class testCaseData
    {
        public Npgsql.NpgsqlConnection con;
        public Npgsql.NpgsqlCommand cmd;
        public Npgsql.NpgsqlDataAdapter da;
        public List<Models.TestCase.testcase> GetTestCase(Guid ID)
        {
            List<Models.TestCase.testcase> list = new List<Models.TestCase.testcase>();

            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"select * from qadata.testcasemain where row_idnum = @ID;", con);
            cmd.Parameters.Add("@ID", NpgsqlTypes.NpgsqlDbType.Uuid).Value = ID;
            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow DR in ds.Tables[0].Rows)
            {
                Models.TestCase.testcase item = new Models.TestCase.testcase();
                item.aprovedby = Convert.ToString(DR["aprovedby"]);
                item.aproveddate = Convert.ToDateTime(DR["aproveddate"]);
                item.assigned_to = Convert.ToString(DR["assigned_to"]);
                item.automated_yes_no = Convert.ToString(DR["automated_yes_no"]);
                item.automation_script_name = Convert.ToString(DR["automation_script_name"]);
                item.automation_test_idnum = new Guid(Convert.ToString(DR["automation_test_idnum"]));
                item.automation_test_status = Convert.ToInt16(DR["automation_test_status"]);
                item.br_idnum = new Guid(Convert.ToString(DR["br_idnum"]));
                item.client_idnum = new Guid(Convert.ToString(DR["client_idnum"]));
                item.feature = Convert.ToString(DR["feature"]);
                item.feature_idnumber = new Guid(Convert.ToString(DR["feature_idnumber"]));
                item.feature_type = Convert.ToString(DR["feature_type"]);
                item.id = new Guid(Convert.ToString(DR["row_idnum"]));
                item.iteration = Convert.ToString(DR["iteration"]);
                item.module = Convert.ToString(DR["module"]);
                item.notes = Convert.ToString(DR["notes"]);
                item.prd = Convert.ToString(DR["prd"]);
                item.qatestcasenum = Convert.ToInt32(DR["qatestcasenum"]);
                item.qa_test_idnum = new Guid(Convert.ToString(DR["qa_test_idnum"]));
                item.regression_yes_no = Convert.ToString(DR["regression_yes_no"]);
                item.requirement_id = Convert.ToString(DR["requirement_id"]);
                item.rorv_idnum = new Guid(Convert.ToString(DR["rorv_idnum"]));
                item.standard_test_idnum = new Guid(Convert.ToString(DR["standard_test_idnum"]));
                item.status = Convert.ToInt16(DR["status"]);
                item.structure_idnum = new Guid(Convert.ToString(DR["structure_idnum"]));
                item.testcasenum = Convert.ToInt32(DR["testcasenum"]);
                item.testtype = Convert.ToString(DR["testtype"]);
                item.test_case = Convert.ToString(DR["test_case"]);
                item.test_case_description = Convert.ToString(DR["test_case_description"]);
                item.test_case_id = Convert.ToString(DR["test_case_id"]);
                item.test_case_title = Convert.ToString(DR["test_case_title"]);
                item.test_condition = Convert.ToString(DR["test_condition"]);
                item.ticket_mapping_idnum = new Guid(Convert.ToString(DR["ticket_mapping_idnum"]));
                item.use_case = Convert.ToString(DR["use_case"]);

                list.Add(item);
            }

            return list;
        }

        public Guid Maintain_TestCase(Models.TestCase.testcase item, string username)
        {
            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"SELECT qadata.maintain_testcase( @v_row_idnum, @v_client_idnum, @v_structure_idnum, @v_br_idnum, @v_testtype, @v_iteration, @v_prd, @v_requirement_id, @v_use_case, @v_test_case, @v_test_case_title, @v_test_case_description, @v_module, @v_feature, @v_feature_idnumber, @v_feature_type, @v_test_case_id, @v_test_condition, @v_assigned_to, @v_notes, @v_automated_yes_no, @v_automation_script_name, @v_automation_test_status, @v_regression_yes_no, @v_aproveddate, @v_aprovedby, @v_testcasenum, @v_rorv_idnum, @v_ticket_mapping_idnum, @v_automation_test_idnum, @v_standard_test_idnum, @v_qa_test_idnum, @v_qatestcasenum, @q_username, @v_status);", con);

            cmd.Parameters.Add("@v_row_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.id;
            cmd.Parameters.Add("@v_client_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.client_idnum;
            cmd.Parameters.Add("@v_structure_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.structure_idnum;
            cmd.Parameters.Add("@v_br_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.br_idnum;
            cmd.Parameters.Add("@v_testtype", NpgsqlTypes.NpgsqlDbType.Text).Value = item.testtype ?? "";
            cmd.Parameters.Add("@v_iteration", NpgsqlTypes.NpgsqlDbType.Text).Value = item.iteration ?? "";
            cmd.Parameters.Add("@v_prd", NpgsqlTypes.NpgsqlDbType.Text).Value = item.prd ?? "";
            cmd.Parameters.Add("@v_requirement_id", NpgsqlTypes.NpgsqlDbType.Text).Value = item.requirement_id ?? "";
            cmd.Parameters.Add("@v_use_case", NpgsqlTypes.NpgsqlDbType.Text).Value = item.use_case ?? "";
            cmd.Parameters.Add("@v_test_case", NpgsqlTypes.NpgsqlDbType.Text).Value = item.test_case ?? "";
            cmd.Parameters.Add("@v_test_case_title", NpgsqlTypes.NpgsqlDbType.Text).Value = item.test_case_title ?? "";
            cmd.Parameters.Add("@v_test_case_description", NpgsqlTypes.NpgsqlDbType.Text).Value = item.test_case_description ?? "";
            cmd.Parameters.Add("@v_module", NpgsqlTypes.NpgsqlDbType.Text).Value = item.module ?? "";
            cmd.Parameters.Add("@v_feature", NpgsqlTypes.NpgsqlDbType.Text).Value = item.feature ?? "";
            cmd.Parameters.Add("@v_feature_idnumber", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.feature_idnumber;
            cmd.Parameters.Add("@v_feature_type", NpgsqlTypes.NpgsqlDbType.Text).Value = item.feature_type ?? "";
            cmd.Parameters.Add("@v_test_case_id", NpgsqlTypes.NpgsqlDbType.Text).Value = item.test_case_id ?? "";
            cmd.Parameters.Add("@v_test_condition", NpgsqlTypes.NpgsqlDbType.Text).Value = item.test_condition ?? "";
            cmd.Parameters.Add("@v_assigned_to", NpgsqlTypes.NpgsqlDbType.Text).Value = item.assigned_to ?? "";
            cmd.Parameters.Add("@v_notes", NpgsqlTypes.NpgsqlDbType.Text).Value = item.notes ?? "";
            cmd.Parameters.Add("@v_automated_yes_no", NpgsqlTypes.NpgsqlDbType.Text).Value = item.automated_yes_no ?? "";
            cmd.Parameters.Add("@v_automation_script_name", NpgsqlTypes.NpgsqlDbType.Text).Value = item.automation_script_name ?? "";
            cmd.Parameters.Add("@v_automation_test_status", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.automation_test_status;
            cmd.Parameters.Add("@v_regression_yes_no", NpgsqlTypes.NpgsqlDbType.Text).Value = item.regression_yes_no ?? "";
            cmd.Parameters.Add("@v_aproveddate", NpgsqlTypes.NpgsqlDbType.Date).Value = item.aproveddate;
            cmd.Parameters.Add("@v_aprovedby", NpgsqlTypes.NpgsqlDbType.Text).Value = item.aprovedby ?? "";
            cmd.Parameters.Add("@v_testcasenum", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.testcasenum;
            cmd.Parameters.Add("@v_rorv_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.rorv_idnum;
            cmd.Parameters.Add("@v_ticket_mapping_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.ticket_mapping_idnum;
            cmd.Parameters.Add("@v_automation_test_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.automation_test_idnum;
            cmd.Parameters.Add("@v_standard_test_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.standard_test_idnum;
            cmd.Parameters.Add("@v_qa_test_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.qa_test_idnum;
            cmd.Parameters.Add("@v_qatestcasenum", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.qatestcasenum;
            cmd.Parameters.Add("@q_username", NpgsqlTypes.NpgsqlDbType.Text).Value = username;
            cmd.Parameters.Add("@v_status", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.status;

            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Guid IDNUM = new Guid(Convert.ToString(ds.Tables[0].Rows[0]["maintain_testcase"]));

            return IDNUM;

        }


        public List<Models.TestCase.Test_step> GetTestSteps(Guid Test_ID)
        {
            List<Models.TestCase.Test_step> list = new List<Models.TestCase.Test_step>();

            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"select * from qadata.test_steps where test_idnum = @Test_ID order by step_number;", con);
            cmd.Parameters.Add("@Test_ID", NpgsqlTypes.NpgsqlDbType.Uuid).Value = Test_ID;
            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow DR in ds.Tables[0].Rows)
            {
                Models.TestCase.Test_step item = new Models.TestCase.Test_step();
                item.Expected_result = Convert.ToString(DR["expected_reult"]);
                item.Id = new Guid(Convert.ToString(DR["row_idnum"]));
                item.Status = Convert.ToInt32(DR["status"]);
                item.Step = Convert.ToString(DR["step"]);
                item.Step_num = Convert.ToInt32(DR["step_number"]);
                item.Test_case_id = new Guid(Convert.ToString(DR["test_idnum"]));
                
                list.Add(item);
            }

            return list;
        }

        public Guid Maintain_TestCase_Step(Models.TestCase.Test_step item, string username)
        {
            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"SELECT qadata.maintain_testcase_step(@v_row_idnum, @v_test_idnum, @v_step, @v_expected_result, @v_step_num, @q_username, @v_status);", con);

            cmd.Parameters.Add("@v_row_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.Id;
            cmd.Parameters.Add("@v_test_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.Test_case_id;
            cmd.Parameters.Add("@v_step", NpgsqlTypes.NpgsqlDbType.Text).Value = item.Step ?? "";
            cmd.Parameters.Add("@v_expected_result", NpgsqlTypes.NpgsqlDbType.Text).Value = item.Expected_result ?? "";
            cmd.Parameters.Add("@v_step_num", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.Step_num;
            
            cmd.Parameters.Add("@q_username", NpgsqlTypes.NpgsqlDbType.Text).Value = username;
            cmd.Parameters.Add("@v_status", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.Status;

            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Guid IDNUM = new Guid(Convert.ToString(ds.Tables[0].Rows[0]["maintain_testcase_step"]));

            return IDNUM;
        }
    }
}