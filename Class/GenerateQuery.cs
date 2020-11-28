using AlumacSystem;
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

        public string GetQueryViaFileAndTagName(string FileName, string TagName)
        {
            try
            {
                if (Connection == null)
                {
                    Connection.Open();
                }
                string Query = "";
                string FolderInsideFileName  = @"Query\" + FileName;
                string FilePath = AppDomain.CurrentDomain.BaseDirectory + FolderInsideFileName;
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

        public long GetSingleNumericValueViaQuery(string Query, string[,] ReplaceValues, IDbConnection IDbConnection)
        {
            long Result = 0;
            string sqlQuery = Query;
            try
            {
                if (Connection == null)
                {
                    Connection.Open();
                }
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
                SqlCommand command = new SqlCommand(sqlQuery, Connection);
                command.CommandText = sqlQuery;
                string message = "";
                for (int i = 0; i < command.Parameters.Count; i++)
                {
                    message += command.Parameters[i].ToString() + "\n";
                }
                object value = command.ExecuteScalar();
                if (value != null)
                {
                    Result = Convert.ToInt64(value);
                }
                return Result;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }

        public string GetSingleStringValueViaQuery(string Query, string[,] ReplaceValues, IDbConnection IDbConnection)
        {
            string Result = "";
            string sqlQuery = Query;
            try
            {
                if (Connection == null)
                {
                    Connection.Open();
                }
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
                SqlCommand command = new SqlCommand(sqlQuery, Connection);
                command.CommandText = sqlQuery;
                string message = "";
                for (int i = 0; i < command.Parameters.Count; i++)
                {
                    message += command.Parameters[i].ToString() + "\n";
                }
                object value = command.ExecuteScalar();
                if (value != null)
                {
                    Result = Convert.ToString(value);
                }
                return Result;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        public DataTable GetCollectionOfDataSetViaQuery(string sqlQuery)
        {
            try
            {
                if (Connection == null)
                {
                    Connection.Open();
                }

                DataTable DataTable = new DataTable("DataTable");
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, Connection);
                DataSet dataSetObj = new DataSet();
                adapter.Fill(dataSetObj);
                if (dataSetObj != null)
                {
                    DataTable = dataSetObj.Tables[0];
                }
                return DataTable;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
            finally
            {
                Connection.Close();
            }

        }

        public Registration GetCollectionOfDataViaQuery(string sqlQuery)
        {
            Registration homeInformationObj = new Registration();
            try
            {
                if (Connection == null)
                {
                    Connection.Open();
                }
                sqlQuery = GetQueryViaFileAndTagName("test.xml", "CollectionOfData");
                SqlCommand selectCMD = new SqlCommand(sqlQuery, Connection);
                selectCMD.CommandTimeout = 30;
                SqlDataAdapter customerDA = new SqlDataAdapter();
                customerDA.SelectCommand = selectCMD;
                Connection.Open();
                DataTable DataTable = new DataTable();
                customerDA.Fill(DataTable);
                Connection.Close();

                if (DataTable != null)
                {
                    List<Registration> InfoArray = (from DataRow dr in DataTable.Rows
                                                    select new Registration()
                                                    {
                                                        UserId = Convert.ToInt64(dr["UserId"]),
                                                        UserName = Convert.ToString(dr["UserName"]),
                                                        LastName = Convert.ToString(dr["UserName"]),
                                                        FirstName = Convert.ToString(dr["UserName"]),
                                                        Email = Convert.ToString(dr["Email"]),
                                                    }).ToList();
                    if (InfoArray.Count > 0)
                        homeInformationObj.RegistrationListCollectionList = InfoArray;
                }
                return homeInformationObj;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
            finally
            {
                Connection.Close();
            }                    
        }

        public Registration GetCollectionSearchDataViaQuery(string sqlQuery, string[,] ReplaceValues, string[] fieldNames, string[] values, string WhereClause ,Registration homeInformationObj )
        {
            try
            {
                if (Connection == null)
                {
                    Connection.Open();
                }
                string sqlWhereClause = WhereClause;

                if (fieldNames != null && values != null)
                {
                    for (int i = 0; i < fieldNames.Length; i++)
                    {
                        sqlWhereClause += " and " + fieldNames[i] + " = '" + values[i].Trim() + "'";
                    }
                }

                sqlQuery = GetQueryViaFileAndTagName("test.xml", "ValidUserOrNotDeatils");

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
                SqlCommand selectCMD = new SqlCommand(sqlQuery, Connection);
                selectCMD.CommandTimeout = 30;
                SqlDataAdapter customerDA = new SqlDataAdapter();
                customerDA.SelectCommand = selectCMD;
                Connection.Open();
                DataTable DataTable = new DataTable();
                customerDA.Fill(DataTable);
                Connection.Close();

                if (DataTable != null)
                {
                    List<Registration> InfoArray = (from DataRow dr in DataTable.Rows
                                                    select new Registration()
                                                    {
                                                        UserId = Convert.ToInt64(dr["UserId"]),
                                                        UserName = Convert.ToString(dr["UserName"]),
                                                        LastName = Convert.ToString(dr["UserName"]),
                                                        FirstName = Convert.ToString(dr["UserName"]),
                                                        Email = Convert.ToString(dr["Email"]),
                                                    }).ToList();
                    if (InfoArray.Count > 0)
                        homeInformationObj.RegistrationListCollectionList = InfoArray;
                }
                return homeInformationObj;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

    }
}