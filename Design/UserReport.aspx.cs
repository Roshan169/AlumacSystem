using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using AngulerTest.Class;
using MVC.Views.Home;
using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using AlumacSystem;
using System.Net;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using Microsoft.SqlServer.Server;

namespace AlumacSystem
{
    
    public partial class UserReport : System.Web.UI.Page
    {
        public NpgsqlConnection Connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=ffadmin;Database=postgres");
        GenerateQuery QueryObj = new GenerateQuery();

        ReportDocument rprt = new ReportDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Connection==null)
                {
                    Connection.Open();
                }
                rprt.Load(Server.MapPath("~\\Crystal Reports\\UserReport.rpt"));
                string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "UserReport");
                Connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(Query, Connection);
                DataSet dataSetObj = new DataSet();
                adapter.Fill(dataSetObj);
                if (dataSetObj != null)
                {
                    ExportFormatType formatType = ExportFormatType.NoFormat;
                    switch (rbFormat.SelectedItem.Value="PDF")
                    {
                        case "Word":
                            formatType = ExportFormatType.WordForWindows;
                            break;
                        case "PDF":
                            formatType = ExportFormatType.PortableDocFormat;
                            break;
                        case "Excel":
                            formatType = ExportFormatType.Excel;
                            break;
                        case "CSV":
                            formatType = ExportFormatType.CharacterSeparatedValues;
                            break;
                    }
                    adapter.Fill(dataSetObj, "User");
                    rprt.SetDataSource(dataSetObj.Tables[0]);
                    UserReportId.ReportSource = rprt;
                    rprt.ExportToHttpResponse(formatType, Response, false, "UserReport");
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                Connection.Close();
            }


        }
    }
}