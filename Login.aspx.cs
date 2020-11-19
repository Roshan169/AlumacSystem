using AngulerTest.Class;
using System;
using System.Data.SqlClient;

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
            string[,] ReplaceValues = new string[1, 2];
            ReplaceValues[0, 0] = "_UserName_";
            ReplaceValues[0, 1] = UserName.Text;

            string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "ValidUserOrNot");
            string UserFound = QueryObj.SinglevalueViaQuery(Query, ReplaceValues, Connection);
            if (UserFound != "")
                UserFound = "User Found ";
        }
    }
}