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

        public Guid Maintain_TestCase(Models.TestCase.testcase item, string username)
        {
            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"SELECT qadata.maintain_testcase( @v_row_idnum, @v_client_idnum, @v_structure_idnum, @v_br_idnum, @v_testtype, @v_iteration, @v_prd, @v_requirement_id, @v_use_case, @v_test_case, @v_test_case_title, @v_test_case_description, @v_module, @v_feature, @v_feature_idnumber, @v_feature_type, @v_test_case_id, @v_test_condition, @v_assigned_to, @v_notes, @v_automated_yes_no, @v_automation_script_name, @v_automation_test_status, @v_regression_yes_no, @v_aproveddate, @v_aprovedby, @v_testcasenum, @v_rorv_idnum, @v_ticket_mapping_idnum, @v_automation_test_idnum, @v_standard_test_idnum, @v_qa_test_idnum, @v_qatestcasenum, @q_username, @v_status);", con);

            cmd.Parameters.Add("@v_row_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.id;
            cmd.Parameters.Add("@v_client_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.client_idnum;
            cmd.Parameters.Add("@v_structure_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.structure_idnum;
            cmd.Parameters.Add("@v_br_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.br_idnum;
            cmd.Parameters.Add("@v_testtype", NpgsqlTypes.NpgsqlDbType.Text).Value = item.testtype ??"";
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
    }
}