<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="Bookauthor.aspx.cs" Inherits="library1.Bookauthor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="container-fluid" style="border:groove; border-color:gray" >
        <div class="header" >
        <div >
            <h4 style="text-align: center; background-color:white; color:blue; padding-top:1%; padding-bottom:1%">
                Author Information</h4>
          </div>
        </div>
                  <div align="center" >
                        <label>
                            <b>Author Name</b></label>
                        <asp:TextBox ID="Textaname" runat="server" CssClass="txtname form-control"  Width="292px" MaxLength="20" AutoComplete="Off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvOwner" runat="server" ControlToValidate="Textaname"
                        ValidationGroup="Register" Style="color:red;" >*Enter Author Name</asp:RequiredFieldValidator>
                    </div>

    <br />
                 <div align="center" >
                    <div class="form-group">
                        <div>
                            <asp:Button ID="btngo" runat="server" CssClass="btn btn-primary" Text="Submit" 
                                ValidationGroup="Register" OnClick="btngo_Click" />
                                 <asp:Button ID="btnReset" runat="server" CssClass="btn btn-danger" Text="Reset" OnClick="btnReset_Click" />
                        </div>
                    </div>
                </div>
        </div>
        <br />
    <div class="col-sm-12 offset-sm-0 col-xs-12" id="divGrid" runat="server" >
        <asp:GridView ID="gvRegister" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condenced" OnRowDeleting="gvRegister_RowDeleting" OnRowEditing="gvRegister_RowEditing"
              AllowPaging="false" DataKeyNames="id,AuthorName"  >
            <Columns>

                <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:LinkButton ID="lblid" runat="server" CommandName="Edit" Text='<%# Bind("id") %>' Font-Underline="False"
                            Font-Bold="True"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Author Name" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblAuthorName" Text='<%#Bind("AuthorName") %>' runat="server" />
                    </ItemTemplate>
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
