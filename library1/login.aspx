<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="library1.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>

    <script type="text/javascript"  src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>

    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script type="text/javascript"  src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css"
        rel="stylesheet" type="text/css" />
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100px;
        }
    </style>
 <script type="text/javascript">
     function successalert() {
         swal({
             title: 'Congratulations!',
             text: 'Login succesfully',
             type: 'success'
         });
     }
 </script>
</head>
<body> 
    <form id="form1" runat="server">
    <div id="head">
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/dlibrary500.png" />
    
    </div>
    <div id="main"><div id="img">
        <table class="style1">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
        <asp:Image ID="Image2" runat="server" ImageUrl="~/img/lin3.png" Height="314px" 
                        style="margin-left: 94px" Width="561px" />
                </td>
            </tr>
        </table>
        </div>
    <div id="login">
        <table class="tbl">
            <tr>
                <td class="tblhead" colspan="2">
                    Login Area</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lbl" runat="server" Font-Size="11px" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="lbl">
                    UserName :</td>
                <td>
                    <asp:TextBox ID="txtusername" runat="server" CssClass="txt" Width="175px" AutoComplete="off" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtusername" ErrorMessage="Enter UserName" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="a"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="lbl">
                    Password :
                </td>
                <td>
                    <asp:TextBox ID="txtpass" runat="server" CssClass="txt" TextMode="Password" Width="175px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtpass" ErrorMessage="Enter PassWord" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="a"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Login" 
                        Width="80px" Font-Size="10pt" ValidationGroup="a" OnClick="Button1_Click"/>
                </td>
            </tr>
            <tr>
                <td>
                  </td>
                <td>
                   <a class="Staff" href="forgot.aspx" cssclass="button" >Forgot Password</a>
                   </td>
            </tr>
        </table>
    </div>
    
    </div>
    </form>
</body>
</html>