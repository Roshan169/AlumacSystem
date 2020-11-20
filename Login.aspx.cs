using AngulerTest.Class;
using System;
using System.Data.SqlClient;
using System.Windows;

namespace AlumacSystem
{

    public partial class Login : System.Web.UI.Page
    {
        public SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=New;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginUser_Click(object sender, EventArgs e)
        {
            //GenerateQuery QueryObj = new GenerateQuery();
            //string[,] ReplaceValues = new string[1, 2];
            //ReplaceValues[0, 0] = "_UserName_";
            //ReplaceValues[0, 1] = UserName.Text;

            //string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "ValidUserOrNot");
            //string UserFound = QueryObj.SinglevalueViaQuery(Query, ReplaceValues, Connection);
            //if (UserFound != "")
            //    UserFound = "User Found ";


            //            private void buttonbackup_Click(object sender, EventArgs e)
            //            {
            //                try
            //                {
            //                    using (SqlConnection dbConn = new SqlConnection())
            //                    {
            //                        dbConn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=neyadatabase;Integrated Security=True;Connect Timeout=30;";
            //                        dbConn.Open();

            //                        using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
            //                        {
            //                            multiuser_rollback_dbcomm.Connection = dbConn;
            //                            multiuser_rollback_dbcomm.CommandText = @"ALTER DATABASE neyadatabase SET MULTI_USER WITH ROLLBACK IMMEDIATE";

            //                            multiuser_rollback_dbcomm.ExecuteNonQuery();
            //                        }
            //                        dbConn.Close();
            //                    }

            //                    SqlConnection.ClearAllPools();

            //                    using (SqlConnection backupConn = new SqlConnection())
            //                    {
            //                        backupConn.ConnectionString = yourConnectionString;
            //                        backupConn.Open();

            //                        using (SqlCommand backupcomm = new SqlCommand())
            //                        {
            //                            backupcomm.Connection = backupConn;
            //                            backupcomm.CommandText = @"BACKUP DATABASE neyadatabase TO DISK='c:\neyadatabase.bak'";
            //                            backupcomm.ExecuteNonQuery();
            //                        }
            //                        backupConn.Close();
            //                    }
            //                }

            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show(ex.Message);
            //                }
            //            }
            //            And for restore :

            //private void buttonrestore_Click(object sender, EventArgs e)
            //                {
            try
            {
                using (SqlConnection restoreConn = new SqlConnection())
                {
                    restoreConn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = New; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                    restoreConn.Open();
                    using (SqlCommand restoredb_executioncomm = new SqlCommand())
                    {
                        restoredb_executioncomm.Connection = restoreConn;
                        restoredb_executioncomm.CommandText = @"RESTORE DATABASE neyadatabase FROM DISK='D:\Roshan\DataBase\AlumacSystem.mdf'";

                        restoredb_executioncomm.ExecuteNonQuery();
                    }
                    restoreConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}