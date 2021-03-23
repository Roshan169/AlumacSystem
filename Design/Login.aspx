<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AlumacSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .floating-input, .floating-select {
            font-size: 18px;
            padding: 2px;
            border-bottom: 1px solid blue;
            background-color: darkgray;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
        }
            /*****  Niche ka line border and text jo likhenge and  padding text  kaha se start karana h left and height first height sec left********/


            .floating-input:focus, .floating-select:focus {
                outline: none;
            }
        /**** Text box vala single niche ka line ke liye *****/

        label {
            position: absolute;
            left: 42px;
            top: 2px;
            width: 77px;
            right: 210px;
        }
        /**** Uper jo jayega label vo kaha pr kis place pr hona chahiye  or Float working ke liye position hona chahiye ****/
        /**** Uper vala label alignment  ****/

        .floating-label {
            position: relative;
            top: -16px;
            left: 185px;
            width: 354px;
            font-weight: bold;
        }
        /****  Float working ke liye position hona chahiye ****/

        .floating-input:focus ~ label, .floating-input:not(:placeholder-shown) ~ label {
            top: -18px;
            align-content: center;
            text-align: center;
        }
        /****  Kitana uper tak jana chahiye label ****/
        /**** .floating-input:not(:placeholder-shown) ~ label     = Ye dalane se Text dalane ke bad label niche nhi aata ****/
    </style>
</head>
<body>
      
    <form id="form1" runat="server" >
        <div  style="padding: inherit; margin: auto; height: 471px; background-color: #00FFFF; background-image="registration-form-1.jpg" width: 620px;" aria-atomic="False" aria-autocomplete="inline" aria-busy="True" aria-checked="undefined">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div style="height: 226px; width: 648px">
            <div class="floating-label" style="align-content:center; top: 4px; left: 186px; width: 329px; background-color:red;  background-image="registration-form-1.jpg" ; >
                <asp:TextBox class="floating-input" ID="UserName" runat="server" type="text" placeholder=" " Font-Bold="True" Width="151px"></asp:TextBox>
                <label>User Name </label>
            </div>
            <br />
            <br />
                <br />
            <div class="floating-label">
                <asp:TextBox class="floating-input" runat="server" ID="Password" type="password" placeholder=" " Font-Bold="True" Width="43%"></asp:TextBox>
                <label>Password </label>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="LoginUser" runat="server" Height="30px" Width="9%" Font-Bold="true" BorderWidth="3px" OnClick="LoginUser_Click"  Text="Login" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            </div>
    </form>
</body>
</html>

