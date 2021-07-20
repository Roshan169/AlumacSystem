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
using System.Windows;
using AlumacSystem;
using System.Net;
using AlumacSystem.Crystal_Reports;
using System.Collections;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.SqlServer.Server;

namespace MVC.Views.Home
{
    public partial class Mail : System.Web.UI.Page
    {
        public NpgsqlConnection Connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=ffadmin;Database=postgres");
        GenerateQuery QueryObj = new GenerateQuery();

        ReportDocument rprt = new ReportDocument();

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                SmtpClient smtp = new SmtpClient();
                MailMessage mail = new MailMessage();

                mail.To.Add(txtto.Text);
                mail.From = new MailAddress("roshanyadav169@gmail.com");
                mail.Subject = txtsub.Text;
                mail.Body = txtmsg.Text;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("roshanyadav169@gmail.com", "HackRoshaner$1");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                // // lblmsg.Text = "Mail Send .......";
            }
            catch (Exception ex)
            {

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            //    rprt.Load(Server.MapPath("~\\Crystal Reports\\UserReport.rpt"));
            //    string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "UserReport");
            //    Connection.Open();
            //    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(Query, Connection);
            //    DataSet dataSetObj = new DataSet();
            //    adapter.Fill(dataSetObj);
            //    if (dataSetObj != null)
            //    {
            //        ExportFormatType formatType = ExportFormatType.NoFormat;
            //        switch (rbFormat.SelectedItem.Value = "PDF")
            //        {
            //            case "Word":
            //                formatType = ExportFormatType.WordForWindows;
            //                break;
            //            case "PDF":
            //                formatType = ExportFormatType.PortableDocFormat;
            //                break;
            //            case "Excel":
            //                formatType = ExportFormatType.Excel;
            //                break;
            //            case "CSV":
            //                formatType = ExportFormatType.CharacterSeparatedValues;
            //                break;
            //        }
            //        adapter.Fill(dataSetObj, "User");
            //        rprt.SetDataSource(dataSetObj.Tables[0]);
            //        UserReportId.ReportSource = rprt;
            //        rprt.ExportToHttpResponse(formatType, Response, false, "UserReport");
            //    }


            //}
        }

        protected void Print(object sender, EventArgs e)
        {
            rprt.Load(Server.MapPath("~\\Crystal Reports\\UserReport.rpt"));
            string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "UserReport");
            Connection.Open();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(Query, Connection);
            DataSet dataSetObj = new DataSet();
            adapter.Fill(dataSetObj);
            if (dataSetObj != null)
            {
                ExportFormatType formatType = ExportFormatType.NoFormat;
                switch (rbFormat.SelectedItem.Value = "PDF")
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

        protected void Email(object sender, EventArgs e)
        {
            using (MailMessage mm = new MailMessage("sender@gmail.com", "receiver@gmail.com"))
            {
                SmtpClient smtp = new SmtpClient();
                MailMessage mail = new MailMessage();

                mail.To.Add(txtto.Text);
                mail.From = new MailAddress("roshanyadav169@gmail.com");
                mail.Subject = txtsub.Text;
                mail.Body = txtmsg.Text;
                rprt.Load(Server.MapPath("~\\Crystal Reports\\UserReport.rpt"));
                mm.Attachments.Add(new Attachment(Server.MapPath("~/Crystal Reports/"), "Invoice.pdf"));
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("roshanyadav169@gmail.com", "HackRoshaner$1");
                smtp.EnableSsl = true;

                smtp.Send(mail);

                //mm.Subject = txtsub.Text; ;
                //mm.Body = "RDLC Report PDF example";
                //mm.Attachments.Add(new Attachment(ExportReportToPDF(Server.MapPath("~/Crystal Reports/"), "Invoice.pdf")));
                //mm.IsBodyHtml = true;
                //smtp.Host = "smtp.gmail.com";
                //smtp.Credentials = new NetworkCredential("roshanyadav169@gmail.com", "HackRoshaner$1");
                //smtp.UseDefaultCredentials = true;
                //smtp.Port = 587;
                //smtp.EnableSsl = true;
                //smtp.Send(mm);
            }
        }

        // Generate repord in a path
        private string ExportReportToPDF(string path, string reportName)
        {

            string filename = "";
            try
            {
                //Warning[] warnings;
                //string[] streamids;
                //string mimeType;
                //string encoding;
                //string filenameExtension;
                //byte[] bytes = UserReportId.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
                //filename = path + reportName;
                //using (var fs = new System.IO.FileStream(filename, System.IO.FileMode.Create))
                //{
                //    fs.Write(bytes, 0, bytes.Length);
                //    fs.Close();
                //}
                rprt.Load(Server.MapPath("~\\Crystal Reports\\UserReport.rpt"));
                string Query = QueryObj.GetQueryViaFileAndTagName("LogIn.xml", "UserReport");
                Connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(Query, Connection);
                DataSet dataSetObj = new DataSet();
                adapter.Fill(dataSetObj);
                if (dataSetObj != null)
                {
                    ExportFormatType formatType = ExportFormatType.NoFormat;
                    switch (rbFormat.SelectedItem.Value = "PDF")
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
                    //rprt.ExportToHttpResponse(formatType, Response, false, "UserReport");
                }
                    ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = "D:\\Roshan Project\\RequiredCommonInfo\\AlumacSystem\\AlumacSystem\\Crystal Reports\\Invoice.pdf";
                CrExportOptions = rprt.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    
                }
                rprt.Export();
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connection.Close();
            }


            return filename;
        }
    }
}