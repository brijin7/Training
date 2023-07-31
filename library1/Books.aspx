<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="library1.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="container-fluid" style="border:groove; border-color:gray">
        <div class="header" style="  width:90%; ">
        <div class="col-sm-12 offset-sm-0  col-xs-12">
            <h4 style="text-align: left; background-color:white; color:blue; padding-top:1%; padding-bottom:1%">
                Books Information</h4>
          </div>
        </div>
        <div class="BORDER" >
            <div class="col-sm-12 offset-sm-0  col-xs-12"> 
                
                <div class="row">
                    <div class="col-sm-3 col-xs-12">
                        <label>
                            <b>Book Name</b></label>
                        <asp:TextBox ID="Textbookname" runat="server" CssClass="txtname form-control"  Width="292px" MaxLength="20" AutoComplete="Off"></asp:TextBox>
                            
                        <asp:RequiredFieldValidator ID="rfvOwner" runat="server" ControlToValidate="Textbookname"
                        ValidationGroup="Register" CssClass="vError">*Enter Book Name</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-3 col-xs-12">
                       <label>
                            <b>Author Name </b></label>
&nbsp;<asp:DropDownList ID="ddwnl" runat="server" Width="269px"  Height="38px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="ddwnl"
                        ValidationGroup="Register" InitialValue="0" CssClass="vError">*Enter Author Name</asp:RequiredFieldValidator>
                        </div>
                    <div class="col-sm-3 col-xs-12">
                        <label>
                           <b>Quantity</b></label>

                        <asp:TextBox ID="Textqty" runat="server" CssClass="txtname form-control"  Width="292px"  MaxLength="10"
                            AutoComplete="Off"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="Textqty"
                        ValidationGroup="Register" CssClass="vError">*Enter Quantity</asp:RequiredFieldValidator>
                    </div>
                    
                    
                
                </div>
               </div>
            </div>
        <div  align="right">
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
    <div class="col-sm-12 offset-sm-0 col-xs-12" id="divGrid" runat="server">
        <asp:GridView ID="gvRegister" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condenced" 
            OnRowDeleting="gvRegister_RowDeleting" OnRowEditing="gvRegister_RowEditing" OnPageIndexChanging="gvRegister_PageIndexChanging" PageSize="10"
              AllowPaging="true" DataKeyNames="id,Book Name,AuthorName,Quantity,AuthorId" >
            <Columns>

                <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:LinkButton ID="lblid" runat="server" CommandName="Edit" Text='<%# Bind("id") %>' Font-Underline="False"
                            Font-Bold="True"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Book Name" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblBookname" Text='<%#Bind("[Book Name]") %>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AuthorName" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblauthorname" Text='<%#Bind("AuthorName") %>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblqty" Text='<%#Bind("Quantity") %>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AuthorId" HeaderStyle-CssClass="grdHead" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblAuthorId" Text='<%#Bind("AuthorId") %>' runat="server" />
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
            <HeaderStyle ForeColor="black" BackColor="gray" Font-Bold="false" Font-Size="13px" HorizontalAlign="Center"/>
            <RowStyle BackColor="White" />
            <AlternatingRowStyle BackColor="WhiteSmoke" />
            <FooterStyle BackColor="White" ForeColor="#000066" />
        </asp:GridView>
    </div>
    <asp:HiddenField ID="hfid" runat="server" />
</asp:Content>
