<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgotpass.aspx.cs" Inherits="library1.Forgotpass" %>

<!DOCTYPE html>

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
    <style type="text/css">
        .auto-style1 {
            width: 480px;
        }
        .auto-style2 {
            width: 167px;
        }
        .auto-style3 {
            width: 167px;
            height: 30px;
        }
        .auto-style4 {
            height: 30px;
        }
    </style>
    <script type="text/javascript">
        function successalert() {
            swal({
                title: 'Congratulations!',
                text: 'Password Changed succesfully',
                type: 'success'
            });
        }
    </script>
     
</head>
<body>
   <form id="form1" runat="server">
    <div id="head" align="Center">
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/dlibrary500.png" />
    
    </div>
       <div align="center"> 
            <h2 style="color: #800000">Create New Password </h2>
        </div>
        <div>

            <table align="center" class="auto-style1">
                <tr>
                    <td class="auto-style3">Enter MobileNo</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtmno" runat="server"  MaxLength="10" AutoComplete="off" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtmno" ErrorMessage="Enter MobileNo" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="a"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">Enter New Password</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtpass" runat="server" TextMode="Password" AutoComplete="off" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtpass" ErrorMessage="Enter New Password" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="a"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="btn_forgot" runat="server" BackColor="#0066FF" BorderColor="Black" BorderStyle="Solid" 
                            ForeColor="Black" Text="Forgot"  ValidationGroup="a" OnClick="btn_forgot_Click"  />
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <a class="Staff" href="login.aspx" cssclass="button" >Back Logoin</a>
                        </td>
                </tr>
                </table>
            </div>
    </form>
</body>
</html>
