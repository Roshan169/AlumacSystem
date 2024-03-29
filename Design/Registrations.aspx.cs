﻿using AngulerTest.Class;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MVC.Views.Home
{
    public partial class Registrations : System.Web.UI.Page
    {
        public NpgsqlConnection Connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=ffadmin;Database=postgres");
        //public NpgsqlConnection Connection = new NpgsqlConnection(@"Data Source=LAPTOP-CNDERC7H\SQLEXPRESS;Initial Catalog=RemoteSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        GenerateQuery QueryObj = new GenerateQuery();
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
                
                string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "GetUserTypeId");
                Query = Query.Replace("_TypeName_", "Admin");
                long UserTypeId = QueryObj.GetSingleNumericValueViaQuery(Query, null, Connection);

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
                    cmd.Parameters.AddWithValue("@UserTypeId", UserTypeId);
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
                Response.Redirect("Login.aspx");
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

        protected void SendMail_Click(object sender, EventArgs e)
        {


            try
            {
                SmtpClient smtp = new SmtpClient();
                MailMessage mail = new MailMessage();
                NetworkCredential obj = new NetworkCredential();
                mail.To.Add(Email.Text);
                mail.From = new MailAddress("roshanyadav169@gmail.com");
                mail.Subject = FirstName.Text;
                mail.Body = Request.Form["LastName"];
                mail.Body = LastName.Text;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("roshanyadav169@gmail.com", "HackRoshaner$1");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                // lblmsg.Text = "Mail Send .......";
            }
            catch (Exception ex)
            {

            }
        }
    }
}