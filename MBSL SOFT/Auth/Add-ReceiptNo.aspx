<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Add-ReceiptNo.aspx.cs" Inherits="Auth_Add_ReceiptNo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
<div class="col-md-8">

        <div class="form-group">
         <div class="col-md-3">
               <label>Start No.</label>
                </div>
                <div class="col-md-9">
               <asp:TextBox ID="txtstart" runat="server" class="form-control" placeholder="Enter Start No."></asp:TextBox>

          </div></div>
          <div class="form-group">
           <div class="col-md-3">
               <label>End No.</label>
               </div>
                <div class="col-md-9">
               <asp:TextBox ID="txtend" runat="server" class="form-control" placeholder="Enter End No."></asp:TextBox>
          </div></div>
          <asp:Panel ID="pnlcenter" runat="server" Visible="false">
          <div class="form-group">
          <div class="col-md-3">
               <label>Center Name</label>
                 </div>
                <div class="col-md-9">
                    <asp:DropDownList ID="ddlcenter" runat="server">
                    </asp:DropDownList>
          </div></div>
         </asp:Panel>
          <div class="form-group">
                   <asp:Button CssClass="btn-success" ID="btnsubmit" runat="server" 
                       Text="Submit" onclick="btnsubmit_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

