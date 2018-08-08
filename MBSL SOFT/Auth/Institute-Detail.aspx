<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Institute-Detail.aspx.cs" Inherits="Auth_Institute_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Institute Detail
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-8">

        <div class="form-group col-md-6">
            <label>Institute Name</label>
            <asp:TextBox ID="txtname" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group col-md-6">
            <label>Phone</label>
            <asp:TextBox ID="txtphone" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

         <div class="form-group col-md-12">
            <label>Address</label>
            <asp:TextBox ID="txtadd" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
        </div>
        
        
        <div class="form-group col-md-6">
            <label> Sms Username</label>
            <asp:TextBox ID="txtuser" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
         <div class="form-group col-md-6">
            <label>Sms Password</label>
            <asp:TextBox ID="txtpass" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
         <div class="form-group col-md-12">
            <label>Sender id</label>
            <asp:TextBox ID="txtsid" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-12">
            <label>Logo</label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        
        <div class="form-group">
            <%--<label>Resume</label>--%>
        </div>
          <div class="form-group">
                   <asp:Button CssClass="btn btn-default" ID="btnsubmit" runat="server" 
                       Text="Submit" OnClick="btnsubmit_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>
