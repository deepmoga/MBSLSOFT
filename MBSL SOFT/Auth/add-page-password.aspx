<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="add-page-password.aspx.cs" Inherits="Auth_add_page_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
  <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
<div class="col-md-8">

        <div class="form-group">
         <div class="col-md-3">
               <label>Page Name</label>
                </div>
                <div class="col-md-9">
               <asp:TextBox ID="txtpage" runat="server" class="form-control" placeholder="Enter page name"></asp:TextBox>

          </div></div>
          <div class="form-group">
           <div class="col-md-3">
               <label>Password</label>
               </div>
                <div class="col-md-9">
               <asp:TextBox ID="txtpass" runat="server" class="form-control" 
                        placeholder="Enter password" TextMode="Password"></asp:TextBox>
          </div></div>
          <div class="form-group">
                   <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server" 
                       Text="Submit" onclick="btnsubmit_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

