<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Session.aspx.cs" Inherits="AlumacSystem.Design.Session" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
            height: 520px;
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
            border-width: medium;
            background-color: #ec3f3f;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            cursor: pointer;
            }
        .lgnbtn {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
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
            .cnbtn {
                width: 100%;
            }
        }
        .frmalg {
            margin: auto;
            width: 40%;
        }
    </style>

</head>
<body>
    <form id="form2" runat="server" class="frmalg">
       <div  class="container" style="margin: auto; padding-top:20%;margin: 14% 10% 20% 0%;padding: 10% 50% 10% 30%;height:100%; border: thin solid #000000; align-content: center; width:183px; background-image: url('../images/workfromhome.jpg');">
            <center>
                <h3 style="color: #C0C0C0">Session </h3>
                <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
            </center>
            <label for="uname" runat="server"  id="SessionPC"><b></b></label>   
            <label for="uname" runat="server"  id="SessionAddress"><b></b></label>   
            <label for="uname" runat="server"  id="SessionUser"><b></b></label>  
           <asp:Table ID="Table1" runat="server" Height="123px" Width="300px" BackColor="#CCCCFF" BorderColor="Black" BorderWidth="2px" CellPadding="2" CellSpacing="3" CssClass="container"  VerticalAlign="Center">  
            <asp:TableRow runat="server" >  
                <asp:TableCell runat="server">Name <asp:TableCell ID="tempCell1" runat="server"></asp:TableCell> </asp:TableCell>  
                <asp:TableCell runat="server">Email <asp:TableCell ID="TableCell1" runat="server"></asp:TableCell> </asp:TableCell>  
                <asp:TableCell runat="server">UserName <asp:TableCell ID="TableCell2" runat="server"></asp:TableCell> </asp:TableCell>  
                <asp:TableCell runat="server">Accept</asp:TableCell>  
                <asp:TableCell runat="server">Reject</asp:TableCell>  
            </asp:TableRow>  
           
              
        
        </asp:Table>           
        </div>
    </form>
</body>
</html>
