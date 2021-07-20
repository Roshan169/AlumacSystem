using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace AngulerTest.Class
{


    //private IDbConnection Connection;
    //private IDbConnection DBConnection;

    public class QueryDataReader
    {
        NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=ffadmin;Database=postgres");
        //public NpgsqlConnection Connection = new NpgsqlConnection(@"Data Source=LAPTOP-CNDERC7H\SQLEXPRESS;Initial Catalog=RemoteSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        string Query = "";
        public UserLogIn DataReader()
        {
            UserLogIn UserObj = new UserLogIn();
            try
            {
                con.Open();
                GenerateQuery n = new GenerateQuery();
                Query = n.GetQueryViaFileAndTagName("", "");
                NpgsqlCommand Cmd = new NpgsqlCommand(Query, con);
                NpgsqlDataReader QueryData = Cmd.ExecuteReader();
                while (QueryData.Read())
                {
                    UserObj.UserName = QueryData["UserName"].ToString();
                    UserObj.Email = QueryData["Email"].ToString();
                    UserObj.UserId = Convert.ToInt64(QueryData["UserId"]);
                }
                return UserObj;
            }

            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }

            finally
            {
                con.Close();
            }
        }

        public void SearchCollection(string[] FieldName, string[] FieldValue, string WhereClause, string WhereCondition)
        {
            try
            {
                string fildValue = "";
                //string fildName="";
                string WhereClouseValue = "";


                if (FieldName != null && FieldValue != null)
                {
                    //for (var i = 0; i < FieldName.Length; i++)
                    //{
                    //     fildName = FieldName[i].ToString();
                    //}
                    for (var i = 0; i < FieldValue.Length; i++)
                    {
                        fildValue = FieldValue[i].ToString();
                        if (fildValue != "")
                            WhereClouseValue = fildValue;

                    }
                    WhereClouseValue = String.Join(",", fildValue.ToString());
                    //This willl work for like query 
                    // WhereClouseValue = ("%" + fildValue + "%");


                }
            }
            catch (Exception ex)
            {
                string ErrMsg = ex.Message;
            }
            finally
            {
                con.Close();
            }
        }


        //Connection Related Changes 
        //public class DB
        //{
        //    public string dbType { get; set; }
        //    public List<DB> dbTypeItems { get; set; }
        //}
        //public static IDbConnection OpenDBConnection(string dbProvider)
        //{

        //    if (String.IsNullOrEmpty(dbProvider))
        //    {
        //        object ObjectPreDBSource = System.Web.HttpContext.Current.Session["DBSource"];
        //        if (ObjectPreDBSource != null)
        //            dbProvider = ObjectPreDBSource.ToString();
        //        if (String.IsNullOrEmpty(dbProvider))
        //        {
        //            List<DB> Items = new List<DB>();
        //            ConnectionStringSettingsCollection ConnectionItems = ConfigurationManager.ConnectionStrings;
        //            if (ConnectionItems != null)
        //            {
        //                for (int i = 0; i < ConnectionItems.Count; i++)
        //                {
        //                    if (ConnectionItems[i].Name == "Oracle" || ConnectionItems[i].Name == "postgres" || ConnectionItems[i].Name == "Sql")
        //                    {
        //                        DB DB = new DB();
        //                        DB.dbType = ConnectionItems[i].Name;
        //                        Items.Add(DB);
        //                    }
        //                }
        //            }
        //            if (Items.Count == 1)
        //            {
        //                object objDBSource = ConfigurationManager.AppSettings["DBSource"];
        //                if (objDBSource != null)
        //                {
        //                    if (objDBSource.ToString() == Items[0].dbType.ToString())
        //                    {
        //                        System.Web.HttpContext.Current.Session["DBSource"] = Items[0].dbType;
        //                        System.Web.HttpContext.Current.Application["DBSource"] = Items[0].dbType;
        //                        dbProvider = Items[0].dbType.ToString();
        //                    }
        //                }
        //            }
        //        }
        //    }


        //    //ECFactory Factory = new ECDBFactory();
        //    //var DAL = Factory.GetDataAccessLayer((ECDBDataProviderType)Enum.Parse(typeof(ECDBDataProviderType), dbProvider));
        //    var DataBaseType = "PostGrey";
        //    IDbConnection DbConnection = DataBaseType.OpenDBConnection();
        //    ConnectionCounter++;
        //    return DbConnection;
        //}
        //public IDbConnection OpenDBConnection()
        //{
        //    try
        //    {
        //        DBConnection = GetDataProviderConnection();
        //        DBConnection.ConnectionString = this.ConnectionString;
        //        DBConnection.Open();
        //        return DBConnection;
        //    }
        //    catch (Exception e)
        //    {
        //        DBConnection.Close();
        //    }
        //    return DBConnection;
        //}

    }

}
