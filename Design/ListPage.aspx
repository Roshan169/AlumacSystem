<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListPage.aspx.cs" Inherits="AlumacSystem.Design.ListPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      
        <center>
            <b><label>Requested User List</label></b><br />
            <br />

        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" OnRowCommand="ApproveReject_RowCommand" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AutoGenerateColumns="False" Height="260px" Width="756px">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
            <Columns >
                <asp:BoundField DataField="RemoteControlSessionId" HeaderText="Remote Id" />
                <asp:BoundField DataField="ComputerName" HeaderText="Computer Name" />
                <asp:BoundField DataField="MacAddress" HeaderText="Mac Address" />
                <asp:BoundField DataField="Approved" HeaderText="Approved" />
                <asp:ButtonField ButtonType="Button"  CommandName="Approved"  HeaderText="Approved" ShowHeader="True" Text="Approved" />
                <asp:ButtonField ButtonType="Button"  CommandName="Reject"  HeaderText="Reject" ShowHeader="True" Text="Reject" />
            </Columns>
        </asp:GridView>
            </center>

        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>

    </form>
</body>
</html>
