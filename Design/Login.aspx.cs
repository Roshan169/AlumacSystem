﻿using AngulerTest.Class;
using MVC.Views.Home;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace AlumacSystem
{

    public partial class Login : System.Web.UI.Page
    {
        public SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AlumacSystem;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

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
            ReplaceValues[1, 1] = Pass;
            long UserId = 0;
            string User = "";

            Registration registration = null;

            string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "ValidUserOrNot");
            Query = Query.Replace("_UserName_", UserName.Text.ToString());
            Query = Query.Replace("_Password_", Pass.ToString());
            if (Query != "")
            {
                UserId = QueryObj.GetSingleNumericValueViaQuery(Query, ReplaceValues, Connection);
                User = QueryObj.GetSingleStringValueViaQuery(Query, ReplaceValues, Connection);
            }
            if (Query != "")
            {
                registration = QueryObj.GetCollectionOfDataViaQuery(Query);
                DataTable DataTableObj = new DataTable("DataTable");
                DataTableObj = QueryObj.GetCollectionOfDataSetViaQuery(Query);
                if(DataTableObj !=null)
                {
                    //Data Set havinf data now retrive it to its sutiable properties 
                }
            }
            if(Query !="")
            {
                registration = QueryObj.GetCollectionSearchDataViaQuery(Query, ReplaceValues, null, null,  "" , registration);
            }
            //if (UserId > 0)
                //Alert( "LoggedIn Sucessfully :");

        }
    }
}