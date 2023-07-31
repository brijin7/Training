<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgot.aspx.cs" Inherits="library1.forgot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                text: 'Submited succesfully!',
                type: 'success'
            });
        }
        function updatealert() {
            swal({
                title: 'Congratulations!',
                text: 'Updated Successfully!',
                type: 'success'
            });
        }
        function deletealert() {
            swal({
                title: 'Congratulations!',
                text: 'Deleted Successfully!',
                type: 'success'
            });
        }
        function otheralert() {
            swal({
                title: 'Oops!',
                text: 'Something went wrong on the page!',
                type: 'error'
            });
        }
        function onlyalert() {
            swal({
                title: 'Sorry!',
                text: 'only one row will be allowed!',
                type: 'info'
            });
        }
        $(function () {
            $(".datepicker-1").datepicker();
        });
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }



    </script>
</head>
<body>
   <form id="form1" runat="server">
    <div id="head" align="Center">
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/dlibrary500.png" />
    
    </div>
       <div align="center"> 
            <h2 style="color: #800000">Forgot Password </h2>
        </div>
        <div>

            <table align="center" class="auto-style1">
                <tr>
                    <td class="auto-style3">Enter MobileNo</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtmno" runat="server" MaxLength="20" AutoComplete="off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtmno" ErrorMessage="Enter MobileNo" ForeColor="Red" 
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
