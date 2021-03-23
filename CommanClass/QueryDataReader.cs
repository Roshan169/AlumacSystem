using System;
using System.Data.SqlClient;


namespace AngulerTest.Class
{
  public class QueryDataReader
  {
    SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AlumacSystem;Integrated Security=True");
        string Query = "";
    public UserLogIn DataReader()
    {
      UserLogIn UserObj = new UserLogIn();
      try
      {
        con.Open();
        GenerateQuery n = new GenerateQuery();
        Query = n.GetQueryViaFileAndTagName("", "");
        SqlCommand oCmd = new SqlCommand(Query, con);
        SqlDataReader QueryData = oCmd.ExecuteReader();
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

  }
}
