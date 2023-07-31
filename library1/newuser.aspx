<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newuser.aspx.cs" Inherits="library1.newuser" %>


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
    </style>
     
    <script type="text/javascript"> 
        function erroralert() {
            swal({
                title: 'Oops!',
                text: 'The value Alreday Exists!',
                type: 'info'
            });
        }
        function successalert() {
            swal({
                title: 'Congratulations!',
                text: 'Created succesfully!',
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
            <h2 style="color: #800000">Create New Account </h2>
        </div>
        <div>

            <table align="center" class="auto-style1">
                <tr>
                    <td class="auto-style2">RollNo</td>
                    <td>
                        <asp:TextBox ID="txtrollnum" runat="server" AutoComplete="off"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ErrorMessage="Enter RollNo" ValidationExpression="^[(R+)][(l+)][(0-9)]+$" 
                            ValidationGroup="a" ForeColor="Red" ControlToValidate="txtrollnum" SetFocusOnError="True"  ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">UserName</td>
                    <td>
                        <asp:TextBox ID="txtuser" runat="server" AutoComplete="off"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                            ErrorMessage="Enter Name" ValidationExpression="^[(a-z)(A_Z)]+$" 
                            ValidationGroup="a" ForeColor="Red" ControlToValidate="txtuser" SetFocusOnError="True"  ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">PassWord</td>
                    <td>
                        <asp:TextBox ID="txtpsw" runat="server"  TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtpsw" ErrorMessage="Enter Password" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="a"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Department</td>
                    <td>
                        <asp:DropDownList ID="ddwndep" runat="server" Width="185px" MaxLength="50" Height="34px"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="ddwndep" ErrorMessage="Enter Department" ForeColor="Red" InitialValue="0"
                        SetFocusOnError="True" ValidationGroup="a"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style2">Mobile No</td>
                    <td>
                        <asp:TextBox ID="txtno" runat="server"   MaxLength="10" AutoComplete="off"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                            ErrorMessage="Enter Mobile No" ValidationExpression="^[(0-9)]+$" 
                            ValidationGroup="a" ForeColor="Red" ControlToValidate="txtno" SetFocusOnError="True"  ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Roll</td>
                    <td>
                        
      
                        
                        <asp:RadioButtonList ID="rdobtn_roll" runat="server">
                            <asp:ListItem Value="1">Staff</asp:ListItem>
                            <asp:ListItem Value="2">Student</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="rdobtn_roll" ErrorMessage="Select value" ForeColor="Red" 
                        SetFocusOnError="True" ValidationGroup="a"></asp:RequiredFieldValidator>
                        
      
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Button ID="btn_create" runat="server" BackColor="#0066FF" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" Text="Create" OnClick="btn_create_Click" ValidationGroup="a" />
                    &nbsp;
                     <a class="back" href="Home.aspx" cssclass="button" >Go Back</a> </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
