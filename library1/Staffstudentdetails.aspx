<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="Staffstudentdetails.aspx.cs" Inherits="library1.Staffstudentdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="container-fluid" style="border:groove; border-color:gray">
        <div class="header" style="  width:90%; ">
        <div align="center">
            <h4 align="center" style=" background-color:white; color:blue; padding-top:1%; padding-bottom:1%">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Staff Student Information</h4>
          </div>
        </div>
           <div align="center" >
                    <div class="form-group" >
                        <label><b>Select Staff or Student </b></label>
                        <div >                   
&nbsp;<asp:DropDownList ID="ddwnl" runat="server" Width="269px" MaxLength="50" Height="38px"  AutoPostBack="true" >
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Staff</asp:ListItem>
                                <asp:ListItem Value="2">Student</asp:ListItem>
                        </asp:DropDownList>
                            <br />
                            <br />
<asp:Button  ID="btngo" runat="server" CssClass="btn btn-primary" Text="View Details" OnClick="btngo_Click"/>
                        </div>
                    </div>
                </div>
                </div>        
        <br />
    <div class="col-sm-12 offset-sm-0 col-xs-12" id="divGrid" runat="server">
        <asp:GridView ID="gvRegister" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condenced" 
            OnRowEditing="gvRegister_RowEditing" OnRowUpdating="gvRegister_RowUpdating" OnRowCancelingEdit="gvRegister_RowCancelingEdit" 
            OnPageIndexChanging="gvRegister_PageIndexChanging" PageSize="10" 
            AllowPaging="false" DataKeyNames="username,password,roll,Department,MobileNo,RollNumber" >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_edit" runat="server" Text="Edit" CommandName="Edit" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button ID="btn_update" runat="server" Text="Update" CommandName="Update" />
                        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CommandName="Cancel" />
                    </EditItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="id" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblid" Text='<%# Bind("id") %>' runat="server"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User Name" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lbluser" Text='<%#Bind("username") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtuser" Text='<%#Bind("username") %>' runat="server" Width="100"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Password" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblpw" Text='<%#Bind("password") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtpw" Text='<%#Bind("password") %>' runat="server" Width="100"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Roll" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblroll" Text='<%#Bind("roll") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtroll" Text='<%#Bind("roll") %>' runat="server" Width="100"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Department" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lbldep" Text='<%#Bind("Department") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtdep" Text='<%#Bind("Department") %>' runat="server" Width="100"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MobileNo" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblmno" Text='<%#Bind("MobileNo") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtmno"  Text='<%#Bind("MobileNo") %>' runat="server" Width="100"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RollNumber" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblrollno" Text='<%#Bind("RollNumber") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtrollno" Text='<%#Bind("RollNumber") %>' runat="server" Width="100"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Linkbutton ID="Delete" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Sure Delete')" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                 </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="gvPage" />
            <HeaderStyle ForeColor="black" BackColor="gray" Font-Bold="false" Font-Size="13px" HorizontalAlign="Center" />
            <RowStyle BackColor="White" />
            <AlternatingRowStyle BackColor="WhiteSmoke" />
            <FooterStyle BackColor="White" ForeColor="#000066" />
        </asp:GridView>
    </div>
    <asp:HiddenField ID="hfid" runat="server" />
</asp:Content>
