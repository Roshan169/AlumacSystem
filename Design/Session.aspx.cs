using AngulerTest.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlumacSystem.Design
{
    public partial class Session : System.Web.UI.Page
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AlumacSystem;Integrated Security=True");
        //public SqlConnection Connection = new SqlConnection(@"Data Source=LAPTOP-CNDERC7H\SQLEXPRESS;Initial Catalog=RemoteSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public long RemoteControlSessionId { set; get; }
        public long UserId { set; get; }
        //public string Name { set; get; }
      //  public string UserName { set; get; }
        public string RejectPc { set; get; }
        public string Approved { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }

        // public string Email { set; get; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Connection == null)
            {
                Connection.Open();
            }

            TableItemStyle tableStyle = new TableItemStyle();
            tableStyle.HorizontalAlign = HorizontalAlign.Center;
            tableStyle.VerticalAlign = VerticalAlign.Middle;
            tableStyle.Width = Unit.Pixel(100);

            string UserId = Request.QueryString["UserId"];
            Registration registration = null;
            GenerateQuery QueryObj = new GenerateQuery();
            long rowNum = 0;
            string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "RemoteControlData");
            registration = QueryObj.GetCollectionOfDataViaQuery(Query);
            DataTable DataTableObj = new DataTable("DataTable");
            DataTableObj = QueryObj.GetCollectionOfDataSetViaQuery(Query);
            TableRow tempRow1 = new TableRow();
            TableRow tempRow2 = new TableRow();
            TableRow tempRow3 = new TableRow();
            SqlDataAdapter adapter = new SqlDataAdapter(Query, Connection);
            DataSet dataSetObj = new DataSet();
            adapter.Fill(dataSetObj);



            StringBuilder html = new StringBuilder();
            html.Append("<table border = '1'>");
            html.Append("<tr>");
            foreach (DataColumn column in DataTableObj.Columns)
            {
                if (column.ColumnName != "UserId"  && column.ColumnName != "RemoteControlSessionId")
                {
                    html.Append("<th>");
                    html.Append(column.ColumnName);
                    html.Append("</th>");
                }
            }
            html.Append("</tr>");
            foreach (DataRow row in DataTableObj.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in DataTableObj.Columns)
                {
                    if (column.ColumnName != "UserId" && column.ColumnName != "RemoteControlSessionId")
                      {
                        html.Append("<td>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }
                }
                html.Append("</tr>");
            }
            html.Append("</table>");
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });


            if (DataTableObj != null)
            {
                int DataSetRowCount = DataTableObj.Rows.Count;
                foreach (DataRow dr in DataTableObj.Rows)
                {
                    TableCell tempCell1 = new TableCell();
                    TableCell tempCell2 = new TableCell();
                    TableCell tempCell3 = new TableCell();
                    for (int cellNum = 0; cellNum < 1; cellNum++)
                    {
                        
                        tempCell1.Text = Convert.ToString(dr["RemoteControlSessionId"]);
                        tempCell2.Text = Convert.ToString(dr["Name"]);
                        tempCell3.Text = Convert.ToString(dr["Email"]);
                        
                        
                        DataSetRowCount = DataSetRowCount - 1;
                    }
                    tempRow1.Cells.AddAt(Convert.ToInt32(rowNum), tempCell1);
                    tempRow2.Cells.AddAt(Convert.ToInt32(rowNum), tempCell2);
                    tempRow3.Cells.AddAt(Convert.ToInt32(rowNum), tempCell3);
                    //Table1.Rows.Add(tempRow1);
                    //Table1.Rows.Add(tempRow2);
                    //Table1.Rows.Add(tempRow3);
                    SessionAddress.InnerText = Convert.ToString(dr["Email"]);
                    rowNum = rowNum + 1;
                }
                Table1.Rows.Add(tempRow1);
            }
            foreach (TableRow rw in Table1.Rows)
                foreach (TableCell cel in rw.Cells)
                    cel.ApplyStyle(tableStyle);

            TableHeaderCell header1 = new TableHeaderCell();
            header1.RowSpan = 1;
            header1.ColumnSpan = 5;
            header1.Text = "Remote Control Accept Reject List";
            header1.Font.Bold = true;
            header1.BackColor = Color.Gray;
            header1.HorizontalAlign = HorizontalAlign.Center;
            header1.VerticalAlign = VerticalAlign.Middle;
            TableRow headerRow1 = new TableRow();
            headerRow1.Cells.Add(header1);
            Table1.Rows.AddAt(0, headerRow1);
        }
        protected void Accept(object sender, EventArgs e)
        {
            SessionUser.InnerText = "";
            SessionAddress.InnerText = "";
        }
        protected void Reject(object sender, EventArgs e)
        {
            SessionUser.InnerText = "";
            SessionAddress.InnerText = "";
        }
    }
}