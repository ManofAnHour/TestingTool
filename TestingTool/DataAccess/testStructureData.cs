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
    public class testStructureData
    {
        public Npgsql.NpgsqlConnection con;
        public Npgsql.NpgsqlCommand cmd;
        public Npgsql.NpgsqlDataAdapter da;

        public Guid Maintaintestcall(Models.Level level)
        {
            Guid record_IDNUM = new Guid();

            //con = new NpgsqlConnection(conFIG.ConnFor_PG_QAData);
            //cmd = new NpgsqlCommand(@"SELECT public.maintain_apitestcall(@row_idnum, @client_idnumber, @apicall, @callname_identifier,@testcasenumber, @loggedinas, @status);", con);

            //cmd.Parameters.Add("@row_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.row_idnumber;
            //cmd.Parameters.Add("@client_idnumber", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.client_idnumber;
            //cmd.Parameters.Add("@apicall", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.callname ?? "";
            //cmd.Parameters.Add("@callname_identifier", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.testcallidentifier ?? "";
            //cmd.Parameters.Add("@testcasenumber", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.testcasenumber ?? "";

            //cmd.Parameters.Add("@loggedinas", NpgsqlTypes.NpgsqlDbType.Varchar).Value = LoggedInAs;
            //cmd.Parameters.Add("@status", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.Status;


            //da = new NpgsqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);

            //record_IDNUM = new Guid(Convert.ToString(ds.Tables[0].Rows[0]["maintain_apitestcall"]));

            return record_IDNUM;
        }
        public List<Models.TestLevels.TestStructures> GetTopStructures()
        {
            List<Models.TestLevels.TestStructures> list = new List<Models.TestLevels.TestStructures>();

            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"select * from qadata.ref_structure where parent_idnumber = '00000000-0000-0000-0000-000000000000' order by name;", con);

            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow DR in ds.Tables[0].Rows)
            {
                Models.TestLevels.TestStructures item = new Models.TestLevels.TestStructures();
                item.id = new Guid(Convert.ToString(DR["row_idnumber"]));
                item.Name = Convert.ToString(DR["name"]);
                item.ShortName = Convert.ToString(DR["srtname"]);
                item.Parent_IDNumber =  new Guid(Convert.ToString(DR["parent_idnumber"]));

                list.Add(item);
            }

            return list;
        }
        public Models.TestLevels.TestStructures GetStructure(Guid ID_Number)
        {
            List<Models.TestLevels.TestStructures> list = new List<Models.TestLevels.TestStructures>();

            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"select * from qadata.ref_structure where row_idnumber = @idnum limit 1;", con);
            cmd.Parameters.Add("@idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = ID_Number;

            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Models.TestLevels.TestStructures item = new Models.TestLevels.TestStructures();
            foreach (DataRow DR in ds.Tables[0].Rows)
            {
                
                item.id = new Guid(Convert.ToString(DR["row_idnumber"]));
                item.Name = Convert.ToString(DR["name"]);
                item.ShortName = Convert.ToString(DR["srtname"]);
                item.Parent_IDNumber = new Guid(Convert.ToString(DR["parent_idnumber"]));
            }

            return item;
        }
        public Guid Maintain_Level(Models.TestLevels.TestStructures item, string username)
        {
            Guid record_IDNUM = new Guid();

            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"SELECT qadata.maintain_level(@idnum, @parent_idnumber, @name, @short_name, @loggedinas, @status);", con);

            cmd.Parameters.Add("@idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.id;
            cmd.Parameters.Add("@parent_idnumber", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.Parent_IDNumber;
            cmd.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.Name ?? "";
            cmd.Parameters.Add("@short_name", NpgsqlTypes.NpgsqlDbType.Varchar).Value = item.ShortName ?? "";
            cmd.Parameters.Add("@loggedinas", NpgsqlTypes.NpgsqlDbType.Varchar).Value = username;
            cmd.Parameters.Add("@status", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.status;
            

            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            record_IDNUM = new Guid(Convert.ToString(ds.Tables[0].Rows[0]["maintain_level"]));

            return record_IDNUM;

        }
        public List<Models.Application> GetApplications()
        {
            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"select * from qadata.ref_structure where parent_idnumber = @NoParent order by name;", con);
            cmd.Parameters.Add("@NoParent", NpgsqlTypes.NpgsqlDbType.Uuid).Value = new Guid();

            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
            List<Models.Application> LI = new List<Models.Application>();

            foreach (DataRow I in ds.Tables[0].Rows)
            {
                Models.Application application = new Models.Application();
                application.id = new Guid(Convert.ToString(I["row_idnumber"]));
                application.Name = Convert.ToString(I["name"]);
                application.ShortName = Convert.ToString(I["srtname"]);

                LI.Add(application);

            }
            
            return LI;
        }

        public List<Models.TestLevels.TestStructures> GetChildStructures(Guid ParentID)
        {
            List<Models.TestLevels.TestStructures> list = new List<Models.TestLevels.TestStructures>();

            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"select * from qadata.ref_structure where parent_idnumber = @ParentID order by name;", con);
            cmd.Parameters.Add("@ParentID", NpgsqlTypes.NpgsqlDbType.Uuid).Value = ParentID;
            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow DR in ds.Tables[0].Rows)
            {
                Models.TestLevels.TestStructures item = new Models.TestLevels.TestStructures();
                item.id = new Guid(Convert.ToString(DR["row_idnumber"]));
                item.Name = Convert.ToString(DR["name"]);
                item.ShortName = Convert.ToString(DR["srtname"]);
                item.Parent_IDNumber = new Guid(Convert.ToString(DR["parent_idnumber"]));

                list.Add(item);
            }

            return list;
        }
        public List<Models.TestCase.testcase> GetStructuresTestCases(Guid StructureID)
        {
            List<Models.TestCase.testcase> list = new List<Models.TestCase.testcase>();

            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"select * from qadata.testcasemain where structure_idnum = @StructureID order by testcasenum;", con);
            cmd.Parameters.Add("@StructureID", NpgsqlTypes.NpgsqlDbType.Uuid).Value = StructureID;
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
    }
}