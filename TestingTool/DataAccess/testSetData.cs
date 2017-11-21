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
    public class testSetData
    {
        public Npgsql.NpgsqlConnection con;
        public Npgsql.NpgsqlCommand cmd;
        public Npgsql.NpgsqlDataAdapter da;
        public List<Models.TestSet.Test_Set> GetTestSet(Guid ID)
        {
            List<Models.TestSet.Test_Set> list = new List<Models.TestSet.Test_Set>();

            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"select * from qadata.ref_testset where row_idnumber = @ID;", con);
            cmd.Parameters.Add("@ID", NpgsqlTypes.NpgsqlDbType.Uuid).Value = ID;
            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow DR in ds.Tables[0].Rows)
            {
                Models.TestSet.Test_Set item = new Models.TestSet.Test_Set
                {
                    Id = new Guid(Convert.ToString(DR["row_idnumber"])),
                    Title = Convert.ToString(DR["testset_title"]),
                    Description = Convert.ToString(DR["testset_description"]),
                    testset_id = Convert.ToInt32(DR["testset_id"]),
                    Status = Convert.ToInt32(DR["status"])
                };
                list.Add(item);
            }

            return list;
        }

        public Guid Maintain_TestSet(Models.TestSet.Test_Set item, string username)
        {
            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"SELECT qadata.maintain_testset( @v_Id, @v_Title, @v_Description, @v_testset_id, @q_username, @v_status);", con);

            cmd.Parameters.Add("@v_Id", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.Id;
            cmd.Parameters.Add("@v_Title", NpgsqlTypes.NpgsqlDbType.Text).Value = item.Title ?? "";
            cmd.Parameters.Add("@v_Description", NpgsqlTypes.NpgsqlDbType.Text).Value = item.Description ?? "";
            cmd.Parameters.Add("@v_testset_id", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.testset_id;

            cmd.Parameters.Add("@q_username", NpgsqlTypes.NpgsqlDbType.Text).Value = username;
            cmd.Parameters.Add("@v_status", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.Status;

            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Guid IDNUM = new Guid(Convert.ToString(ds.Tables[0].Rows[0]["maintain_testset"]));

            return IDNUM;

        }

        public List<Models.TestSet.Test_Set> GetTestSets()
        {
            List<Models.TestSet.Test_Set> list = new List<Models.TestSet.Test_Set>();

            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"select * from qadata.ref_testset where status >= 1;", con);
            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow DR in ds.Tables[0].Rows)
            {
                Models.TestSet.Test_Set item = new Models.TestSet.Test_Set
                {
                    Id = new Guid(Convert.ToString(DR["row_idnumber"])),
                    Title = Convert.ToString(DR["testset_title"]),
                    Description = Convert.ToString(DR["testset_description"]),
                    testset_id = Convert.ToInt32(DR["testset_id"]),
                    Status = Convert.ToInt32(DR["status"])
                };

                list.Add(item);
            }

            return list;
        }
        public Guid Maintain_TestSet_Mapping(Models.TestSet.Test_Mapping item, string username)
        {
            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"SELECT qadata.maintain_testset_case_mapping( @v_Id, @v_TestSet_Id, @v_Test_Id, @v_order_num, @q_username, @v_status);", con);

            cmd.Parameters.Add("@v_Id", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.Id;
            cmd.Parameters.Add("@v_TestSet_Id", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.Test_Set_Id;
            cmd.Parameters.Add("@v_Test_Id", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.Test_Id;
            cmd.Parameters.Add("@v_order_num", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.Order_Number;

            cmd.Parameters.Add("@q_username", NpgsqlTypes.NpgsqlDbType.Text).Value = username;
            cmd.Parameters.Add("@v_status", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.Status;

            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Guid IDNUM = new Guid(Convert.ToString(ds.Tables[0].Rows[0]["maintain_testset_case_mapping"]));

            return IDNUM;
        }
        public List<Models.TestSet.Test_Mapping> GetTestSetsCases(Guid TestSet_IDNUM)
        {
            List<Models.TestSet.Test_Mapping> list = new List<Models.TestSet.Test_Mapping>();

            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"SELECT MAPP.*, tc.test_case_title FROM qadata.testset_case_mapping MAPP join qadata.testcasemain tc on MAPP.test_idnum = tc.row_idnum where MAPP.testset_idnum = @TestSet_IDNUM and status >= 1  order by order_number;", con);
            cmd.Parameters.Add("@TestSet_IDNUM", NpgsqlTypes.NpgsqlDbType.Uuid).Value = TestSet_IDNUM;
            
            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow DR in ds.Tables[0].Rows)
            {
                Models.TestSet.Test_Mapping item = new Models.TestSet.Test_Mapping
                {
                    Id = new Guid(Convert.ToString(DR["row_idnum"])),
                    TestCase_Title = Convert.ToString(DR["test_case_title"]),
                    Order_Number = Convert.ToInt32(DR["order_number"]),
                    Test_Id = new Guid(Convert.ToString(DR["test_idnum"])),
                    Test_Set_Id = new Guid(Convert.ToString(DR["testset_idnum"])),
                    Status = Convert.ToInt32(DR["status"]),
                };

                list.Add(item);
            }

            return list;
        }
    }
}