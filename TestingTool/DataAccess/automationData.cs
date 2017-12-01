using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;

using RestSharp;
using Newtonsoft.Json;

namespace TestingTool.DataAccess
{
    public class automationData
    {
        public Npgsql.NpgsqlConnection con;
        public Npgsql.NpgsqlCommand cmd;
        public Npgsql.NpgsqlDataAdapter da;
        

        public Guid Maintain_TestRun(Models.Automation.Test_Run item, string username)
        {
            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"SELECT automation.maintain_run(@v_IdNum, @v_testset_idnum, @v_ID, @v_notes, @q_username, @v_status);", con);

            cmd.Parameters.Add("@v_IdNum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.idnum;
            cmd.Parameters.Add("@v_testset_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.testset_idnum;
            cmd.Parameters.Add("@v_ID", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.id;
            cmd.Parameters.Add("@v_notes", NpgsqlTypes.NpgsqlDbType.Text).Value = item.notes ?? "";
            cmd.Parameters.Add("@q_username", NpgsqlTypes.NpgsqlDbType.Text).Value = username;
            cmd.Parameters.Add("@v_status", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.Status;

            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Guid IDNUM = new Guid(Convert.ToString(ds.Tables[0].Rows[0]["maintain_run"]));

            return IDNUM;
        }
        public List<Models.Automation.Test_Run> GetTestRun(Guid ID)
        {
            List<Models.Automation.Test_Run> list = new List<Models.Automation.Test_Run>();

            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"select * from automation.runs where row_idnum = @ID;", con);
            cmd.Parameters.Add("@ID", NpgsqlTypes.NpgsqlDbType.Uuid).Value = ID;
            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow DR in ds.Tables[0].Rows)
            {
                Models.Automation.Test_Run item = new Models.Automation.Test_Run
                {
                    idnum = new Guid(Convert.ToString(DR["row_idnum"])),
                    testset_idnum = new Guid(Convert.ToString(DR["testset_idnum"])),
                    id = Convert.ToInt32(DR["id"]),
                    notes = Convert.ToString(DR["notes"]),
                    Status = Convert.ToInt32(DR["status"])
                };
                list.Add(item);
            }

            return list;
        }
        
        public Guid Maintain_RunNotes(Models.Automation.Test_Run_Notes item, string username)
        {
            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"SELECT automation.maintain_runnote(@IdNum, @run_IdNum, @testset_idnum,@test_IdNum, @ID,@method_name, @notes, @username, @status);", con);

            cmd.Parameters.Add("@IdNum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.idnum;
            cmd.Parameters.Add("@run_IdNum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.run_idnum;
            cmd.Parameters.Add("@testset_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.testset_idnum;
            cmd.Parameters.Add("@test_IdNum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.test_idnum;

            cmd.Parameters.Add("@ID", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.id;
            cmd.Parameters.Add("@method_name", NpgsqlTypes.NpgsqlDbType.Text).Value = item.method_name ?? "";
            cmd.Parameters.Add("@notes", NpgsqlTypes.NpgsqlDbType.Text).Value = item.notes ?? "";
            cmd.Parameters.Add("@username", NpgsqlTypes.NpgsqlDbType.Text).Value = username;
            cmd.Parameters.Add("@status", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.Status;

            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Guid IDNUM = new Guid(Convert.ToString(ds.Tables[0].Rows[0]["maintain_runnote"]));

            return IDNUM;
        }
        public List<Models.Automation.Test_Run_Notes> GetRunNote(Guid ID)
        {
            List<Models.Automation.Test_Run_Notes> list = new List<Models.Automation.Test_Run_Notes>();

            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"select * from automation.runnotes where row_idnum = @ID;", con);
            cmd.Parameters.Add("@ID", NpgsqlTypes.NpgsqlDbType.Uuid).Value = ID;
            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow DR in ds.Tables[0].Rows)
            {
                Models.Automation.Test_Run_Notes item = new Models.Automation.Test_Run_Notes
                {
                    idnum = new Guid(Convert.ToString(DR["row_idnum"])),
                    run_idnum = new Guid(Convert.ToString(DR["run_idnum"])),
                    testset_idnum = new Guid(Convert.ToString(DR["testset_idnum"])),
                    test_idnum = new Guid(Convert.ToString(DR["test_idnum"])),
                    id = Convert.ToInt32(DR["id"]),
                    notes = Convert.ToString(DR["notes"]),
                    method_name = Convert.ToString(DR["method_name"]),
                    Status = Convert.ToInt32(DR["status"])
                };
                list.Add(item);
            }

            return list;
        }
        
        public Guid Maintain_RunItem(Models.Automation.Test_Run_Item item, string username)
        {
            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"SELECT automation.maintain_run_item(@IdNum, @run_IdNum, @testset_idnum,@test_IdNum, @item_number ,@method_name,  @username, @status);", con);

            cmd.Parameters.Add("@IdNum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.idnum;
            cmd.Parameters.Add("@run_IdNum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.run_idnum;
            cmd.Parameters.Add("@testset_idnum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.testset_idnum;
            cmd.Parameters.Add("@test_IdNum", NpgsqlTypes.NpgsqlDbType.Uuid).Value = item.test_idnum;

            cmd.Parameters.Add("@item_number", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.item_number;
            cmd.Parameters.Add("@method_name", NpgsqlTypes.NpgsqlDbType.Text).Value = item.method_name ?? "";
            cmd.Parameters.Add("@username", NpgsqlTypes.NpgsqlDbType.Text).Value = username;
            cmd.Parameters.Add("@status", NpgsqlTypes.NpgsqlDbType.Integer).Value = item.Status;

            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            Guid IDNUM = new Guid(Convert.ToString(ds.Tables[0].Rows[0]["maintain_run_item"]));

            return IDNUM;
        }
        public List<Models.Automation.Test_Run_Item> GetRunItem(Guid ID)
        {
            List<Models.Automation.Test_Run_Item> list = new List<Models.Automation.Test_Run_Item>();

            con = new NpgsqlConnection(conFIG.ConnFor_PG_Admin);
            cmd = new NpgsqlCommand(@"select * from automation.run_item where row_idnum = @ID;", con);
            cmd.Parameters.Add("@ID", NpgsqlTypes.NpgsqlDbType.Uuid).Value = ID;
            da = new NpgsqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            foreach (DataRow DR in ds.Tables[0].Rows)
            {
                Models.Automation.Test_Run_Item item = new Models.Automation.Test_Run_Item
                {
                    idnum = new Guid(Convert.ToString(DR["row_idnum"])),
                    run_idnum = new Guid(Convert.ToString(DR["run_idnum"])),
                    testset_idnum = new Guid(Convert.ToString(DR["testset_idnum"])),
                    test_idnum = new Guid(Convert.ToString(DR["test_idnum"])),
                    item_number = Convert.ToInt32(DR["item_number"]),
                    method_name = Convert.ToString(DR["method_name"]),
                    Status = Convert.ToInt32(DR["status"])
                };
                list.Add(item);
            }

            return list;
        }
    }
}

