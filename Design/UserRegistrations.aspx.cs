using AlumacSystem;
using AngulerTest.Class;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace MVC.Views.Home
{
    public partial class UserRegistrations : System.Web.UI.Page
    {
        public NpgsqlConnection Connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=ffadmin;Database=postgres");
        //public NpgsqlConnection Connection = new NpgsqlConnection(@"Data Source=LAPTOP-CNDERC7H\SQLEXPRESS;Initial Catalog=RemoteSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        GenerateQuery QueryObj = new GenerateQuery();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            Registration registration = null;

            string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "GetUserTypeList");
            //Query = Query.Replace("_TypeName_", "UserType");
            registration = QueryObj.GetCollectionOfDataViaQuery(Query);
            DataTable DataTableObj = new DataTable("DataTable");
            DataTableObj = QueryObj.GetCollectionOfDataSetViaQuery(Query);
            if (DataTableObj != null)
            {               
                    for (int i = 0; i < DataTableObj.Rows.Count; i++)
                    {
                    long TypeId =Convert.ToInt64( DataTableObj.Rows[i].ItemArray[0]);
                    string theValue = DataTableObj.Rows[i].ItemArray[1].ToString();
                    UserType.DataValueField = DataTableObj.Rows[i].ItemArray[0].ToString();
                    UserType.DataTextField = DataTableObj.Rows[i].ItemArray[1].ToString();
                    UserType.Items.Add(theValue);
                }                
            }           
        }

        protected void UserRegistration_Save(object sender, EventArgs e)
        {

            int UserId = 0;
            string Errmsg = "";
            try
            {
                if (Connection == null)
                {
                    Connection.Open();
                }
                Connection.Open();

                string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "GetUserTypeId");
                Query = Query.Replace("_TypeName_", UserType.SelectedValue.ToString());
                long UserTypeId = QueryObj.GetSingleNumericValueViaQuery(Query, null, Connection);

                string Pass = "";
                using (var cmd = Connection.CreateCommand())
                {
                    
                    cmd.CommandText = "SP_UserLogin_SAVE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@UserName", UserName.Text);
                    cmd.Parameters.AddWithValue("@FirstName", ComputerName.Text);
                    cmd.Parameters.AddWithValue("@LastName", ComputerMacAddress.Text);
                    cmd.Parameters.AddWithValue("@Email", Email.Text);
                    cmd.Parameters.AddWithValue("@Password", Pass);
                    cmd.Parameters.AddWithValue("@CreatedBy", 1);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@LastModifyBy", 1);
                    cmd.Parameters.AddWithValue("@LastModifyDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UserTypeId", UserTypeId);
                    cmd.ExecuteNonQuery();
                    //UserId = (int)cmd.Parameters["@UserId"].Value;                 
                }
            }

            catch (Exception ex)
            {
                Errmsg = ex.Message;
            }
            finally
            {
                Connection.Close();
                if (Errmsg == "")
                {
                    string message4 = UserName + " your access request successfully sended to admin";
                    System.Text.StringBuilder sb3 = new System.Text.StringBuilder();
                    sb3.Append("<script type = 'text/javascript'>");
                    sb3.Append("window.onload=function(){");
                    sb3.Append("alert('");
                    sb3.Append(message4);
                    sb3.Append("')};");
                    sb3.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb3.ToString());
                    Response.Redirect("Login.aspx");
                }
            }
        }

        public string encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }
    }
}