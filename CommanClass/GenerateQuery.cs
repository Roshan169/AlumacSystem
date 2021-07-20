using AlumacSystem;
using AngulerTest.Class;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace AngulerTest.Class
{
    class GenerateQuery
    {
       public NpgsqlConnection Connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=ffadmin;Database=postgres");
        
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
                Connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, Connection);
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
                NpgsqlCommand command = new NpgsqlCommand(sqlQuery, Connection);
                Connection.Open();
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
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sqlQuery, Connection);
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
                sqlQuery = GetQueryViaFileAndTagName("LogIn.xml", "CollectionOfData");
                Connection.Open();
                NpgsqlCommand selectCMD = new NpgsqlCommand(sqlQuery, Connection);
                selectCMD.CommandTimeout = 30;
                NpgsqlDataAdapter customerDA = new NpgsqlDataAdapter();
                customerDA.SelectCommand = selectCMD;
                DataTable DataTable = new DataTable();
                customerDA.Fill(DataTable);
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
                        homeInformationObj.RegistrationCollectionList = InfoArray;
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

                sqlQuery = GetQueryViaFileAndTagName("LogIn.xml", "ValidUserOrNotDeatils");

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
                Connection.Open();
                NpgsqlCommand selectCMD = new NpgsqlCommand(sqlQuery, Connection);
                selectCMD.CommandTimeout = 30;
                NpgsqlDataAdapter customerDA = new NpgsqlDataAdapter();
                customerDA.SelectCommand = selectCMD;
                DataTable DataTable = new DataTable();
                customerDA.Fill(DataTable);

                if (DataTable != null)
                {
                    List<Registration> InfoArray = (from DataRow dr in DataTable.Rows
                                                    select new Registration()
                                                    {
                                                        UserId = Convert.ToInt64(dr["UserId"]),
                                                        UserName = Convert.ToString(dr["UserName"]),
                                                        LastName = Convert.ToString(dr["LastName"]),
                                                        FirstName = Convert.ToString(dr["FirstName"]),
                                                        Email = Convert.ToString(dr["Email"]),
                                                    }).ToList();
                    if (InfoArray.Count > 0)
                        homeInformationObj.RegistrationCollectionList = InfoArray;
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