<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mail.aspx.cs" Inherits="MVC.Views.Home.Mail" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        .floating-input, .floating-select {
            font-size: 18px;
            padding: 4px;
            border-bottom: 1px solid blue;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-top-style: none;
        }

            .floating-input:focus, .floating-select:focus {
                outline: none;
            }

        label {
            position: absolute;
            left: 79px;
            top: 2px;
            font-size: 18px;
            align-content: center;
        }

        .floating-label {
            position: relative;
            left: -90%;
            font-weight: bold;
            top: 10px;
            width: 325px;
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="height: 80%">
        <div id="PageForm" style="margin: auto auto auto 0px; height: 165px; width: 273px; padding-top: 35%; padding-bottom: inherit; padding-left: inherit; padding-right: 80%; background-image: url('../images/pc.png');">


            <div id="RegistrationForm" style="margin: -150% 10% 10% 150%; padding: 35% 50% 10% 80%; height: 100%; align-content: center; width: 148px; height: 390px; background-image: url('../images/.jpg');">
                <div class="floating-label">
                    <b>
                        <label style="background-color: black; color: white; font-size: 22px">Admin Registration Form</label></b><br />
                </div>
                <br />
                <br />
                <div class="floating-label">
                    <asp:TextBox class="floating-input" ID="txtto" runat="server" type="text" placeholder=" " Font-Bold="True"></asp:TextBox>
                    <label>Enter Receiver Email</label>
                </div>

                <br />
                <br />
                <div class="floating-label">
                    <asp:TextBox class="floating-input" ID="txtsub" runat="server" type="text" placeholder=" " Font-Bold="True"></asp:TextBox>
                    <label>Enter Subject</label>
                </div>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
                <div class="floating-label">
                    <asp:TextBox class="floating-input" ID="txtmsg" Name="txtmsg" runat="server" type="text" placeholder=" " Font-Bold="True"></asp:TextBox>
                    <label>Enter Message </label>
                </div>
                <br />
                <br />

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button ID="Button1" runat="server" Style="margin-left: -99px" Width="265px" Height="30px" OnClick="Button1_Click" Text="Register" BackColor="#00CC00" />
                &nbsp;
            </div>
        </div>

        <div>

            <CR:CrystalReportViewer ID="UserReportId" runat="server" AutoDataBind="true" Width="450" Height="250" />
            <br />
            <br />
            <br />

            <asp:RadioButtonList ID="rbFormat" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Word" Value="Word" Selected="True" />
                <asp:ListItem Text="Excel" Value="Excel" />
                <asp:ListItem Text="PDF" Value="PDF" />
                <asp:ListItem Text="CSV" Value="CSV" />
            </asp:RadioButtonList>
            <br />
            <br />
            <asp:Button Text="Print" runat="server" OnClick="Print" />
            <br />
            <br />
            <asp:Button Text="Send" runat="server" OnClick="Email" />
        </div>
    </form>

</body>
</html>
