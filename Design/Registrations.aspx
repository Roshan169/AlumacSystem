﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrations.aspx.cs" Inherits="MVC.Views.Home.Registrations" %>

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

        .floating-input:focus ~ label, .floating-input:not(:placeholder-shown) ~ label {
            top: -18px;
            align-content: center;
            text-align: center;
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
                    <asp:TextBox class="floating-input" ID="UserName" runat="server" type="text" placeholder=" " Font-Bold="True"></asp:TextBox>
                    <label>Admin Name </label>
                </div>
                <br />
                <br />
                <div class="floating-label">
                    <asp:TextBox class="floating-input" ID="FirstName" runat="server" type="text" placeholder=" " Font-Bold="True"></asp:TextBox>
                    <label>First Name </label>
                </div>
                <br />
                <br />
                <div class="floating-label">
                    <asp:TextBox class="floating-input" ID="LastName" runat="server" type="text" placeholder=" " Font-Bold="True"></asp:TextBox>
                    <label>Last Name </label>
                </div>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
                <div class="floating-label">
                    <asp:TextBox class="floating-input" ID="Email" runat="server" type="text" placeholder=" " Font-Bold="True"></asp:TextBox>
                    <label>Email </label>
                </div>
                <br />
                <br />
                <div class="floating-label">
                    <asp:TextBox class="floating-input" runat="server" ID="Password" type="password" placeholder=" " Font-Bold="True"></asp:TextBox>
                    <label>Password </label>
                </div>

                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Button ID="Button1" runat="server" Style="margin-left: -99px" Width="265px" Height="30px" OnClick="Button1_Click" Text="Register" BackColor="#00CC00" />
                &nbsp;
            </div>

             <asp:Button ID="Button2" runat="server"   Style="margin-left: -99px" Width="265px" Height="30px" OnClick="SendMail_Click" Text="Send Mail" BackColor="#00CC00" />

        </div>


    </form>
    <form>
</body>
</html>
