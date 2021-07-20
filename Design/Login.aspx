<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AlumacSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>

    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
            height: 556px;
            width: 1020px;
        }

        form {
            border: 3px solid #f1f1f1;
        }

        input[type=text], input[type=password] {
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        button:hover {
            opacity: 0.8;
        }

        .cnbtn {
            border-style: none;
            border-color: inherit;
            background-color: #ec3f3f;
            color: white;
            padding: 5px;
            margin: 8px 0;
            cursor: pointer;
        }

        .lgnbtn {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #4CAF50;
            color: white;
            padding: 5px 5px;
            margin: 8px 0;
            cursor: pointer;
        }
                .newbtn {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #4CAF50;
            color: white;
            padding: 5px 5px;
            margin: 8px 0;
            cursor: pointer;
        }
        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }

        img.avatar {
            width: 40%;
            border-radius: 50%;
        }

        .container {
            padding: 16px;
            border: none;
        }

        span.psw {
            float: right;
            padding-top: 16px;
        }
        /* Change styles for span and cancel button on extra small screens */
        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }

            
        }

        .frmalg {
            margin: auto;
            width: 59%;
            height: 573px;
        }
    </style>

</head>
<body>
    <form id="form2" runat="server" class="frmalg" style="border-style: none; border-color: #FFFFFF" >
        <%--            <div id="LoginForm" style="margin: -150% 10% 10% 150%; padding: 10% 50% 10% 80%;height:100%; border: thin solid #000000; align-content: center; width:148px; height: 390px; background-image: url('../images/registration-form-1.jpg');">--%>
        <div class="container"  style="margin-left: 100px;  padding-top: 20%; margin: 14% 10% 20% 30%; padding: 10% 50% 10% 30%; height: 62%; border: thin solid #000000; align-content: center; width: 183px; background-image: url('../images/remote.jpg');">
            <center>
                <h3 style="color: #C0C0C0">Login </h3>
            </center>
            <label for="uname"><b style="background-image: url('../images/Modal.jpg')">Username</b></label>
            <asp:TextBox class="floating-input" ID="UserName" runat="server" type="text" placeholder="Enter UserName" Width="220px"></asp:TextBox>

            <label for="psw"><b>Password</b></label>
            <asp:TextBox class="floating-input" runat="server" ID="Password" type="password" placeholder="Enter Password" Width="220px"></asp:TextBox>
            <asp:Button runat="server" ID="btn_Login" CssClass="lgnbtn" Text="Login" OnClick="LoginUser_Click" Width="79px" Height="35px" />
            &nbsp;&nbsp;
            <asp:Button runat="server" ID="btn_cancel" Text="Cancel" class="cnbtn" OnClick="Cancel_Click" Width="86px" Height="35px" />
            <asp:Button runat="server" ID="NewAdmin" CssClass="newbtn" Text="New Admin" OnClick="NewAdmin_Click" Width="80px" Height="35px" />
            &nbsp;<asp:Button runat="server" ID="NewRequest" Text="New Request" class="newbtn" OnClick="NewRequest_Click" Width="93px" Height="35px" />
        <asp:Label ID="Label1" ForeColor="Red" Width="400px" runat="server" Font-Bold="true"></asp:Label>
        </div>
    </form>
</body>
</html>
