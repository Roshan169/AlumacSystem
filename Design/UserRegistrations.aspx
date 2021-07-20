<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistrations.aspx.cs" Inherits="MVC.Views.Home.UserRegistrations" %>

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
            left: 36px;
            top: 2px;
            font-size: 18px;
            align-content:center;
        }
        .floating-label {
            position: relative;
            left: -90%;
         
            font-weight: bold;
            top: 10px;
            width: 325px;
        }
        .floating-input:focus ~ label, .floating-input:not(:placeholder-shown) ~ label {
            top: -18px;
            align-content: center;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="height: 80%">
        <div id="PageForm" style="margin: auto auto auto 0px; height: 165px; width: 273px; padding-top: 35%; padding-bottom: inherit; padding-left: inherit; padding-right: 80%; background-image: url('../images/WHatsapp.jpeg');">

            <br />
            <div id="RegistrationForm" style="margin: -137% 10% 10% 150%; padding: 10% 50% 10% 80%; height: 100%; border: thin solid #000000; align-content: center; width: 100px; height: 400px; background-image: url('../images/Session.png');">
                 <div class="floating-label">
            <b><label style=" color:brown; font-size:22px"  >User Registration Form</label></b><br />
                      </div> <br />
                <br />
                <div class="floating-label">
                    <asp:TextBox class="floating-input" ID="UserName" runat="server" type="text" placeholder=" " Font-Bold="false"></asp:TextBox>
                    <label>User Name </label>
                </div>
                <br />
                <br />

                <div class="floating-label">
                    <asp:TextBox class="floating-input" ID="ComputerName" runat="server" type="text" placeholder=" " Font-Bold="false"></asp:TextBox>
                    <label>Computer Name </label>
                </div>
                <br />
                <br />
                <div class="floating-label">
                    <asp:TextBox class="floating-input" ID="ComputerMacAddress" runat="server" type="text" placeholder=" " Font-Bold="false"></asp:TextBox>
                    <label>Mac Address </label>
                </div>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
                <div class="floating-label">
                    <asp:TextBox class="floating-input" ID="Email" runat="server" type="text" placeholder=" " Font-Bold="false"></asp:TextBox>
                    <label>Email </label>
                </div>
                <br />
                <br />
                <%--<div class="floating-label">
                    <asp:TextBox class="floating-input" runat="server" ID="Password" type="password" placeholder=" " Font-Bold="True"></asp:TextBox>
                    <label>Password </label>
                </div>
                <br />
                <br />--%>
                <asp:DropDownList ID="UserType" runat="server" Height="27px" Style="margin-left: -30px" Width="110px">
                    <asp:ListItem>User Type</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button ID="Button1" class="btn btn-success" runat="server" OnClick="UserRegistration_Save" Style="margin-left: -30px" Width="110px" Text="Register" Height="30px" BackColor="#009933" BorderColor="Black" BorderStyle="None" />
            </div>
        </div>
    </form>
    <form>
</body>
</html>
