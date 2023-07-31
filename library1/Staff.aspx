<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="library1.Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="container-fluid" style="border:groove; border-color:gray">
        <div class="header" style="  width:90%; ">
        <div class="col-sm-12 offset-sm-0  col-xs-12">
            <h4 style="text-align: left; background-color:white; color:blue; padding-top:1%; padding-bottom:1%">
                Book Collections</h4>
          </div>
        </div>
        <div class="BORDER">
            <div class="col-sm-12 offset-sm-0  col-xs-12">
                <div class="row">
                    <div class="col-sm-3 col-xs-12">
                          <label>
                            <b>Name </b></label>
&nbsp;<asp:DropDownList ID="ddwnl2" runat="server" Width="269px" MaxLength="50" Height="38px">
                              <asp:ListItem Value="0">Select Name</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="na" runat="server" ControlToValidate="ddwnl2" InitialValue="0"
                          ValidationGroup="Register" CssClass="vError">*Enter name</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-3 col-xs-12">
                        <label>
                            <b>Author Name </b></label>
&nbsp;<asp:DropDownList ID="ddwnl" runat="server" Width="269px" MaxLength="50" Height="38px"  
    OnSelectedIndexChanged="ddwnl_SelectedIndexChanged"  AutoPostBack="true" >
                            <asp:ListItem Value="0">Select Author Name</asp:ListItem>
                        </asp:DropDownList>
                            
                        <asp:RequiredFieldValidator ID="rfvOwner" runat="server" ControlToValidate="ddwnl" InitialValue="0"
                        ValidationGroup="Register" CssClass="vError">*Select Author Name</asp:RequiredFieldValidator>
                       
                    </div>
                    <div class="col-sm-3 col-xs-12">
                        <label>
                            <b>Book Name </b></label>
&nbsp;<asp:DropDownList ID="ddwnl1" runat="server" Width="269px" MaxLength="50" 
    OnSelectedIndexChanged="ddwnl1_SelectedIndexChanged" AutoPostBack="true"  Height="38px" >
                        </asp:DropDownList>
                            
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddwnl1"
                        ValidationGroup="Register" InitialValue="0" CssClass="vError">*Select Book Name</asp:RequiredFieldValidator>
                       
                    </div>
                    <div class="col-sm-3 col-xs-12">
                        <label>
                            <b>From Date </b></label>
&nbsp;<asp:TextBox ID="Textdate" runat="server" CssClass="form-control"  Width="292px" MaxLength="50" AutoComplete="Off" TextMode="Date"></asp:TextBox>
                            
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Textdate"
                        ValidationGroup="Register" CssClass="vError">*Enter Date</asp:RequiredFieldValidator>
                    
                    </div>
                    <div class="col-sm-3 col-xs-12">
                        <label>
                            <b>Due Date(One Week Only) </b></label>
&nbsp;<asp:TextBox ID="Textd2" runat="server" CssClass=" form-control"  Width="292px" MaxLength="50" AutoComplete="Off" TextMode="Date"></asp:TextBox>
                            
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Textd2"
                        ValidationGroup="Register" CssClass="vError">*Enter Name</asp:RequiredFieldValidator>
                    
                    </div>
                    
                
                </div>
                <div  align="right">
                    <div class="form-group">
                        <div>
                            <asp:Button ID="btngo" runat="server" CssClass="btn btn-primary" Text="Submit" 
                                ValidationGroup="Register" OnClick="btngo_Click"/>
                                 <asp:Button ID="btnReset" runat="server" CssClass="btn btn-danger" Text="Reset" OnClick="btnReset_Click" />
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </div>
      <br />
    <div class="col-sm-12 offset-sm-0 col-xs-12" id="divGrid" runat="server">
        <asp:GridView ID="gvRegister" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condenced" 
            OnRowDeleting="gvRegister_RowDeleting" OnRowEditing="gvRegister_RowEditing" OnPageIndexChanging="gvRegister_PageIndexChanging"  PageSize="10"         
           AllowPaging="true" DataKeyNames="id,Name,Bookauthor,Bookname,Fromdate,UserId,AuthorId,BookId,Duedate" >
            <Columns>

                <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:LinkButton ID="lblid" runat="server" CommandName="Edit" Text='<%# Bind("id") %>' Font-Underline="False"
                            Font-Bold="True"></asp:LinkButton>
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
                 <asp:TemplateField HeaderText="Author Id" HeaderStyle-CssClass="grdHead" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblAuthorId" Text='<%#Bind("AuthorId") %>' runat="server" />
                    </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Book Id" HeaderStyle-CssClass="grdHead" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblBookId" Text='<%#Bind("BookId") %>' runat="server" />
                    </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User Id" HeaderStyle-CssClass="grdHead" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblUserIdd" Text='<%#Bind("UserId") %>' runat="server" />
                    </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="From Date" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblfromdate" Text='<%#Bind("Fromdate") %>' runat="server" />
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Due Date" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblDuedate" Text='<%#Bind("Duedate") %>' runat="server" />
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
