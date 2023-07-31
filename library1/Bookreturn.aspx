<%@ Page Title="" Language="C#" MasterPageFile="~/New.Master" AutoEventWireup="true" CodeBehind="Bookreturn.aspx.cs" Inherits="library1.Bookreturn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="server">
    <div class="container-fluid" style="border:groove; border-color:gray">
        <div class="header" style="  width:90%; ">
        <div class="col-sm-12 offset-sm-0  col-xs-12">
            <h4 style="text-align: left; background-color:white; color:blue; padding-top:1%; padding-bottom:1%">
                Book Return</h4>
          </div>
        </div>
         <div class="BORDER">
            <div class="col-sm-12 offset-sm-0  col-xs-12">
                <div class="row">
                    <div class="col-sm-3 col-xs-12">
                          <label>
                            <b>Name </b></label>
&nbsp;<asp:DropDownList ID="ddwnlname" runat="server" Width="269px" MaxLength="50" Height="38px" 
    OnSelectedIndexChanged="ddwnlname_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="na" runat="server" ControlToValidate="ddwnlname"
                          ValidationGroup="Register" CssClass="vError">*Enter name</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-3 col-xs-12">
                        <label>
                            <b>Author Name </b></label>
&nbsp;<asp:DropDownList ID="ddwnlaname" runat="server" Width="269px" MaxLength="50" Height="38px" 
    OnSelectedIndexChanged="ddwnlaname_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                            
                        <asp:RequiredFieldValidator ID="rfvOwner" runat="server" ControlToValidate="ddwnlaname"
                        ValidationGroup="Register" CssClass="vError">*Select Author Name</asp:RequiredFieldValidator>
                       
                    </div>
                    <div class="col-sm-3 col-xs-12">
                        <label>
                            <b>Book Name </b></label>
&nbsp;<asp:DropDownList ID="ddwnlbname" runat="server" Width="269px" MaxLength="50" Height="38px" 
    OnSelectedIndexChanged="ddwnlbname_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                            
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddwnlbname"
                        ValidationGroup="Register" CssClass="vError">*Select Book Name</asp:RequiredFieldValidator>
                       
                    </div>
                    <div class="col-sm-3 col-xs-12">
                        <label>
                            <b>Due Date </b></label><br />
                   <asp:TextBox ID="Textduedate" runat="server" CssClass="form-control"   Width="292px" MaxLength="50" AutoComplete="On" ></asp:TextBox>
                            
                  
                    
                    </div>
                    <div class="col-sm-3 col-xs-12">
                        <label>
                            <b>Return Date </b></label>
&nbsp;<asp:TextBox ID="Textdate" runat="server" CssClass="form-control"  Width="292px" MaxLength="50" AutoComplete="Off" TextMode="Date"></asp:TextBox>
                            
                        <br />
                            
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Textdate"
                        ValidationGroup="Register" CssClass="vError">*Enter Date</asp:RequiredFieldValidator>
                    
                    </div>
                    
                </div>
                
                    </div>
                <div align="right">
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
    
     <br />
    <div class="col-sm-12 offset-sm-0 col-xs-12" id="divGrid" runat="server">
        <asp:GridView ID="gvRegister" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condenced" 
            OnPageIndexChanging="gvRegister_PageIndexChanging" PageSize="10"
              AllowPaging="true">
            <Columns>
                <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="grdHead">
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server"  Text='<%# Bind("Id") %>'></asp:Label>
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
                        <asp:Label ID="lblReturndate" Text='<%#Bind("Returndate") %>' runat="server" />
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
