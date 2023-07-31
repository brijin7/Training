<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="library1.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="container-fluid">
        <div class="header" style="  width:90%; ">
        <div class="col-sm-12 offset-sm-0  col-xs-12">
            <h4 style="text-align: center; background-color:white; color:blue; padding-top:1%; padding-bottom:1%">
                Welcome To Our Library</h4>
          </div>
            </div>
         </div>
         
        <br />
    <div class="col-sm-12 offset-sm-0 col-xs-12" id="divGrid" runat="server">
        <asp:GridView ID="gvRegister" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condenced" 
              AllowPaging="false">
            <Columns>

                <asp:TemplateField HeaderText="Library Name" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lbllibname" runat="server" Text='<%# Bind("libraryname") %>'
                            ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Founder" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblfounder" Text='<%#Bind("founder") %>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Since" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblsince" Text='<%#Bind("Since") %>' runat="server" />
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
</asp:Content>
