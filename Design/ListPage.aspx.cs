using AngulerTest.Class;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace AlumacSystem.Design
{
    public partial class ListPage : System.Web.UI.Page
    {
        public NpgsqlConnection Connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=ffadmin;Database=postgres");
        //public NpgsqlConnection Connection = new NpgsqlConnection(@"Data Source=LAPTOP-CNDERC7H\SQLEXPRESS;Initial Catalog=RemoteSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateQuery QueryObj = new GenerateQuery();

            string UserId = Request.QueryString["UserId"];
            if (UserId !="" && UserId !=null )
            {
                string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "RemoteControlList");
                DataTable DataTable = new DataTable("DataTable");
                Connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(Query, Connection);
                DataSet dataSetObj = new DataSet();
                
                adapter.Fill(dataSetObj);
                GridView1.DataSource = dataSetObj;
                GridView1.DataBind();
            }
            else
            {
                string message4 = "You do not have rights of this page. Please Contact Admin.";
                System.Text.StringBuilder sb3 = new System.Text.StringBuilder();
                sb3.Append("<script type = 'text/javascript'>");
                sb3.Append("window.onload=function(){");
                sb3.Append("alert('");
                sb3.Append(message4);
                sb3.Append("')};");
                sb3.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb3.ToString());

            }
        }

        protected void ApproveReject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Message = "";
            try
            {
                if (Connection == null)
                {
                    Connection.Open();
                }              
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                long RemoteControlSessionId = Convert.ToInt64(row.Cells[0].Text);
                string AlredyApproved = Convert.ToString(row.Cells[3].Text).ToString();
                GenerateQuery QueryObj = new GenerateQuery();
                string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "GetUserId");
                Query = Query.Replace("_RemoteControlSessionId_", RemoteControlSessionId.ToString());
                long UserId = QueryObj.GetSingleNumericValueViaQuery(Query, null, Connection);
                if (e.CommandName == "Reject")
                {
                        Connection.Open();
                        using (var cmd = Connection.CreateCommand())
                        {
                            cmd.CommandText = "SP_RemoteControlSession_Delete";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@RemoteControlSessionId", RemoteControlSessionId);
                            cmd.ExecuteNonQuery();
                        Message = "Selected User Request Rejected.";
                        }
                }
                if (e.CommandName == "Approved" && AlredyApproved=="N")
                {
                    Connection.Open();
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = "SP_RemoteControlSession_SAVE";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@RemoteControlSessionId", RemoteControlSessionId);
                        cmd.Parameters.AddWithValue("@UserId", UserId);
                        cmd.Parameters.AddWithValue("@Reject", 'N');
                        cmd.Parameters.AddWithValue("@Approved", 'Y');
                        cmd.Parameters.AddWithValue("@CreatedBy", UserId);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@LastModifyBy", UserId);
                        cmd.Parameters.AddWithValue("@LastModifyDate", DateTime.Now);
                        cmd.ExecuteNonQuery();
                        Message = "Selected User Request Get Approved.";
                    }
                }
                else
                    Message = "Selected User are alredy Approved.";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            finally
            {
                Connection.Close();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(Message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                Page_Load(sender, e);
            }
        }
    
    }
}