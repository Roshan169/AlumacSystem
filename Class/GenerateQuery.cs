using AngulerTest.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace AngulerTest.Class
{
    class GenerateQuery
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AlumacSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        public string Name { get; set; }
        public string Address { get; set; }
        public long UserId { get; set; }


        public string GetQueryViaFileAndTagName(string FileName, string TagName)
        {
            try
            {
                Connection.Open();
                string Query = "";
                FileName = "Query//" + FileName;
                string FilePath = AppDomain.CurrentDomain.BaseDirectory + FileName;
                foreach (XElement obj in XElement.Load(FilePath).Elements(TagName))
                {
                    Query = obj.Value.ToString();
                }
                return Query;

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return "";
            }

            finally
            {
                Connection.Close();
            }

        }
        public string  SinglevalueViaQuery(string Query, string[,] ReplaceValues, IDbConnection IDbConnection)
        {

            string Result = "";
            string sqlQuery = Query;

            if (ReplaceValues != null)
            {
                if (ReplaceValues.Length > 0)
                {
                    for (int i = 0; i <= ReplaceValues.GetUpperBound(0); i++)
                    {
                        sqlQuery = sqlQuery.Replace(ReplaceValues[i, 0], ReplaceValues[i, 1]);
                    }
                }
            }
            //IDbCommand DBCommand = ConnectDB.ConnectDBCommand(sqlQuery, IDbConnection, DBSource);
            IDbCommand DBCommand = Connection.CreateCommand();
            object value = DBCommand.ExecuteScalar();

            if (value != null)
            {
                Result = Convert.ToString(value);
            }
            return Result;
        }
        public void CollectionOfDataSetViaQuery(string sqlQuery)
        {

            try
            {
                if (Connection == null)
                {
                    Connection.Open();
                }

                DataTable DataTable = new DataTable("DataTable");
                //IDataAdapter IDA_DataAdaptor = Connection.Conn(sqlQuery, IDbConnection, DBSource);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = new SqlCommand(sqlQuery);
                DataSet DataSet = new DataSet();
                //IDA_DataAdaptor.Fill(DataSet);
                sqlDataAdapter.Fill(DataSet);
                if (DataSet != null)
                {
                    DataTable = DataSet.Tables[0];
                }
                //return DataTable;
            }

            catch (Exception ex)
            {
                string ErrorMsg = ex.Message;
            }

        }
        //public HomeInformation CollectionOfDataViaQuery(string sqlQuery)
        //{
        //    HomeInformation homeInformationObj = new HomeInformation();

        //    //string Result = "";
        //    //string sqlQuery = GetQueryViaFileAndTagName("", "");

        //    //IDataAdapter IDA_DataAdaptor = Connection.Conn(sqlQuery, IDbConnection, DBSource);
        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        //    sqlDataAdapter.SelectCommand = new SqlCommand(sqlQuery);
        //    DataTable DataTable = new DataTable();
        //    //IDA_DataAdaptor.Fill(DataSet);
        //    sqlDataAdapter.Fill(DataTable);

        //    if (DataTable != null)
        //    {
        //        List<HomeInformation> InfoArray = (from DataRow dr in DataTable.Rows
        //                                           select new HomeInformation()
        //                                           {
        //                                               Id = Convert.ToInt64(dr["ManifestTypeId"]),
        //                                               Name = Convert.ToString(dr["ManifestType"]),
        //                                           }).ToList();
        //        if (InfoArray.Count > 0)
        //            homeInformationObj.HomeInformationCollection = InfoArray;
        //    }

        //    return homeInformationObj;
        //}
        public void CollectionSearchDataViaQuery(string sqlQuery, string[,] ReplaceValues, string[] fieldNames, string[] values, string WhereClause)
        {
            string sqlWhereClause = WhereClause;

            if (fieldNames != null && values != null)
            {
                for (int i = 0; i < fieldNames.Length; i++)
                {
                    sqlWhereClause += " and " + fieldNames[i] + " = '" + values[i].Trim() + "'";
                }
            }

            sqlQuery = GetQueryViaFileAndTagName("ChargeGroup.xml", "TagName");

            if (sqlWhereClause != "")
                sqlQuery = sqlQuery.Replace("_WHERECLAUSE_", sqlWhereClause);

            if (ReplaceValues != null)
            {
                if (ReplaceValues.Length > 0)
                {
                    for (int i = 0; i <= ReplaceValues.GetUpperBound(0); i++)
                    {
                        sqlQuery = sqlQuery.Replace(ReplaceValues[i, 0], ReplaceValues[i, 1]);
                    }
                }
            }
            IDataReader IDR_ChargeGroupDataReader = null;

            //IDbCommand IDC_ChargeGroupDbCommand = Connection.ConnectDBCommand(DBSource);
            IDbCommand IDC_ChargeGroupDbCommand = Connection.CreateCommand();
            IDC_ChargeGroupDbCommand.CommandText = sqlQuery;
            IDC_ChargeGroupDbCommand.CommandType = CommandType.Text;
            IDC_ChargeGroupDbCommand.Connection = this.Connection;

            IDR_ChargeGroupDataReader = IDC_ChargeGroupDbCommand.ExecuteReader();

            if (IDR_ChargeGroupDataReader.Read())
            {
                this.UserId = Convert.ToInt64(IDR_ChargeGroupDataReader["ChargeGroupId"]);
                this.Address = IDR_ChargeGroupDataReader["Address"].ToString();
                this.Name = IDR_ChargeGroupDataReader["Name"].ToString();

            }
            //return IDR_ChargeGroupDataReader;

            if (IDR_ChargeGroupDataReader==null)
            {
                //return IDR_ChargeGroupDataReader;
            }
        }

    }
}