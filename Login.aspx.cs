﻿using AngulerTest.Class;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace AlumacSystem
{

    public partial class Login : System.Web.UI.Page
    {
        public SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AlumacSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginUser_Click(object sender, EventArgs e)
        {
            GenerateQuery QueryObj = new GenerateQuery();
            string[,] ReplaceValues = new string[2, 2];
            ReplaceValues[0, 0] = "_UserName_";
            ReplaceValues[0, 1] = UserName.Text;
            ReplaceValues[1, 0] = "_Password_";
            ReplaceValues[1, 1] = UserName.Text;
            long USerId = 0;

            Registration registration = null;

            string Query = QueryObj.GetQueryViaFileAndTagName("test.xml", "CollectionOfData");
            if (Query != "")
                USerId = QueryObj.GetSingleNumericValueViaQuery(Query, ReplaceValues, Connection);
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
          

        }
    }
}