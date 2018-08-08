<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="SmsSetting.aspx.cs" Inherits="Auth_SmsSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="form-group">
        <div class="col-md-2 ">
            <label>UserName:</label>
        </div>
        <div class="col-lg-10">
            <asp:TextBox ID="txtuser" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-2 ">
            <label>SenderId:</label>
        </div>
        <div class="col-lg-10">
            <asp:TextBox ID="txtsender" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-2 ">
            <label>Type:</label>
        </div>
        <div class="col-lg-10">
            <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control">
                <asp:ListItem>Trans</asp:ListItem>
                <asp:ListItem>Promo</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-2 ">
            <label>Api:</label>
        </div>
        <div class="col-lg-10">
            <asp:TextBox ID="txtapi" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <div class="col-md-2 ">
            <label>Alert No:</label>
        </div>
        <div class="col-lg-10">
            <asp:TextBox ID="txtmob" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
     
     <div class="form-group">
         <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="Submit" CssClass="btn btn-default" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

