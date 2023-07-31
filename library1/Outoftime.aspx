<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="Outoftime.aspx.cs" Inherits="library1.Outoftime" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="container-fluid">
        <div>
        <div align="center">
            <h4 align="center" style="background-color:white; color:blue; padding-top:1%; padding-bottom:1%">
                Out Of Time</h4>
          </div>
        </div>
        </div>
    <div align="center">
 
                        <div>
                            <asp:Button ID="btngo" runat="server" CssClass="btn btn-primary" Text="Search Out of Time" 
                                ValidationGroup="Register" OnClick="btngo_Click"/>
                            </div>
                        </div>

    <br />
    <div class="col-sm-12 offset-sm-0 col-xs-12" id="divGrid" runat="server">
        <asp:GridView ID="gvRegister" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condenced" 
              AllowPaging="false" DataKeyNames="id,Name,Bookauthor,Bookname,Duedate,UserId,AuthorId,BookId,Returndate" >
            <Columns>

                <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server"  Text='<%# Bind("Id") %>' Font-Underline="False"
                            Font-Bold="True"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblname" Text='<%#Bind("Name") %>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Book Author" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblbookauthor" Text='<%#Bind("Bookauthor") %>' runat="server" />
                    </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Book Name" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblbookname" Text='<%#Bind("Bookname") %>' runat="server" />
                    </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Due Date" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblDuedate" Text='<%#Bind("Duedate") %>' runat="server" />
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Return Date" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblDuedate" Text='<%#Bind("Returndate") %>' runat="server" />
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
