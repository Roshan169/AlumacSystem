<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserReport.aspx.cs" Inherits="AlumacSystem.UserReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  
    <title></title>  
</head>  
<body>  
   <form id="form1" runat="server">  
    <div>  
        <CR:CrystalReportViewer runat="server" AutoDataBind="true" ID="UserReportId"></CR:CrystalReportViewer>
    </div>  
       <br />
       <br />
           <asp:RadioButtonList ID="rbFormat" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Text="Word" Value="Word" Selected="True" />
        <asp:ListItem Text="Excel" Value="Excel" />
        <asp:ListItem Text="PDF" Value="PDF" />
        <asp:ListItem Text="CSV" Value="CSV" />
    </asp:RadioButtonList>
    </form>  
</body>  
</html>