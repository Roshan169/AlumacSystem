using AngulerTest.Class;
using MVC.Views.Home;
using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace AlumacSystem
{

    public partial class Login : System.Web.UI.Page
    {

        public NpgsqlConnection Connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=ffadmin;Database=postgres");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //string message1 = "Hello! Mudassar.";
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append("<script type = 'text/javascript'>");
            //sb.Append("window.onload=function(){");
            //sb.Append("alert('");
            //sb.Append(message1);
            //sb.Append("')};");
            //sb.Append("</script>");
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

            //string message2 = "Your request is being processed.";
            //System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            //sb1.Append("alert('");
            //sb1.Append(message2);
            //sb1.Append("');");
            //ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb1.ToString());

            //string message3 = "Do you want to Submit?";
            //System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
            //sb2.Append("return confirm('");
            //sb2.Append(message3);
            //sb2.Append("');");
            //ClientScript.RegisterOnSubmitStatement(this.GetType(), "alert", sb2.ToString());

            //string message4 = "Order Placed Successfully.";
            //System.Text.StringBuilder sb3 = new System.Text.StringBuilder();
            //sb3.Append("<script type = 'text/javascript'>");
            //sb3.Append("window.onload=function(){");
            //sb3.Append("alert('");
            //sb3.Append(message4);
            //sb3.Append("')};");
            //sb3.Append("</script>");
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb3.ToString());

            //
            object ReportIdObject = Request.QueryString["UserId"];
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            UserName.Text = "";
            Password.Text = "";
        }
        protected void LoginUser_Click(object sender, EventArgs e)
        {

            Registrations registrationObj = new Registrations();
            string Pass = registrationObj.encryptpass(Password.Text);


            GenerateQuery QueryObj = new GenerateQuery();
            string[,] ReplaceValues = new string[2, 2];
            ReplaceValues[0, 0] = "_UserName_";
            ReplaceValues[0, 1] = UserName.Text;
            ReplaceValues[1, 0] = "_Password_";
            ReplaceValues[1, 1] = Password.Text;
            long UserId = 0;
            string User = "";

            Registration registration = null;

            string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "ValidUserOrNot");
            Query = Query.Replace("_UserName_", UserName.Text.ToString());
            Query = Query.Replace("_Password_", Password.Text.ToString());
            if (Query != "")
            {
                UserId = QueryObj.GetSingleNumericValueViaQuery(Query, ReplaceValues, Connection);
                User = QueryObj.GetSingleStringValueViaQuery(Query, ReplaceValues, Connection);
                if (UserId > 0)
                    Response.Redirect("ListPage.aspx?UserId=" + UserId);
                else
                {
                    UserName.Text = "";
                    Password.Text = "";
                    Label1.Text = "Enter User Name And Password is incurrect please try again.";
                }
            }
            if (Query != "")
            {
                registration = QueryObj.GetCollectionOfDataViaQuery(Query);
                DataTable DataTableObj = new DataTable("DataTable");
                DataTableObj = QueryObj.GetCollectionOfDataSetViaQuery(Query);
                if (DataTableObj != null)
                {
                    //Data Set havinf data now retrive it to its sutiable properties 
                }
            }
            if (Query != "")
            {
                registration = QueryObj.GetCollectionSearchDataViaQuery(Query, ReplaceValues, null, null, "", registration);
            }
        }

        protected void NewRequest_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Registrations.aspx?UserId=");
            Response.Redirect("UserRegistrations.aspx");

        }
        protected void NewAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrations.aspx");

        }
    }
}