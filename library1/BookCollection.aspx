<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="BookCollection.aspx.cs" Inherits="library1.BookCollection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div align="center"><h3>Staff Or Student</h3></div>
    <div align="center" style="width: 285px; margin-left: 424px; height: 27px;" >
          <table class="w-100" align="center" style="width: 53%; margin-left: 122px;">
            <tr>
                <td style="width: 161px; height: 26px"><a id="lblstaff" runat="server" class="Staff" href="Staff.aspx" cssclass="button" > Staff</a></td>
                <td style="height: 26px"><a id="lblstudent" runat="server" class="Student" href="Student.aspx" cssclass="button" > Student</a></td>
            </tr>
         
        </table>
       
    </div>
</asp:Content>
