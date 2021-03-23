using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVC.Views.Home
{
    public partial class Registrations : System.Web.UI.Page
    {
        public SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AlumacSystem;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Connection == null)
                {
                    Connection.Open();
                }
                Connection.Open();
                string Pass =  encryptpass(Password.Text);
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = "SP_UserLogin_SAVE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    long UserId = 0;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@UserName", UserName.Text);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", LastName.Text);
                    cmd.Parameters.AddWithValue("@Email", Email.Text);
                    cmd.Parameters.AddWithValue("@Password", Pass);
                    cmd.Parameters.AddWithValue("@CreatedBy", 1);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@LastModifyBy", 1);
                    cmd.Parameters.AddWithValue("@LastModifyDate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }

            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                Connection.Close();
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