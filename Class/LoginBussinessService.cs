using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AngulerTest.Class
{
  public class LoginBussinessService
  {
    SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AlumacSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        string Query = "";
    string Errsg = "";
    public LoginBussinessService()
    {
    }
    public void LoginValidate()
    {
      try
      {
        con.Open();

        GenerateQuery generateQuery = new GenerateQuery();
        Query = generateQuery.GetQueryViaFileAndTagName("test.xml", "LogInInsertUpdate");

      }
      catch (Exception ex)
      {
        Errsg = ex.Message;
      }
      finally
      {
        con.Close();
      }
    }
  }
}
