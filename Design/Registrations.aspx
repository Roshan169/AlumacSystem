<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrations.aspx.cs" Inherits="MVC.Views.Home.Registrations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        .floating-input, .floating-select {
            font-size: 18px;
            padding: 2px;
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
            align-content:center;
        }
        .floating-label {
            position: relative;
            left: 13%;
         
            font-weight: bold;
            top: 0px;
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
    <form id="form1" runat="server">
        <div id="PageForm" style="margin: auto auto auto 0px; height: 253px; width: 273px; padding-top: 35%; padding-bottom: inherit; padding-left: inherit; padding-right: 80%; background-image: url('../images/AlumacTask.jpg');">
            
           
              <div id="RegistrationForm" style="margin: -90% 10% 10% 100%; padding: 10% 50% 10% 80%; border: thin solid #000000; align-content: center; width:375px; height: 309px; background-image: url('../images/registration-form-1.jpg');" >
            <div class="floating-label">
                <asp:TextBox class="floating-input" ID="UserName" runat="server" type="text" placeholder=" " Font-Bold="True" ></asp:TextBox>
                <label>User Name </label>
            </div>
            <br />
                  <br />
            <div class="floating-label">
                <asp:TextBox class="floating-input" ID="FirstName" runat="server" type="text" placeholder=" " Font-Bold="True" ></asp:TextBox>
                <label>First Name </label>
            </div>
            <br />
            <br />
            <div class="floating-label">
                <asp:TextBox class="floating-input" ID="LastName" runat="server" type="text" placeholder=" " Font-Bold="True" ></asp:TextBox>
                <label>Last Name </label>
            </div>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <div class="floating-label">
                <asp:TextBox class="floating-input" ID="Email" runat="server" type="text" placeholder=" " Font-Bold="True" ></asp:TextBox>
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
                   <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />


        </div>
        </div>
      

    </form>
    <form>
</body>
</html>
