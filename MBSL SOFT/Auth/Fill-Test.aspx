<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Fill-Test.aspx.cs" Inherits="Auth_Fill_Test" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
    <style>table#ctl00_cpmain_rdomode tr {
    display: inline;
}</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Exam Registration
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <section>
        <div class="form-group col-md-6">
            <label for="exampleInputEmail1">Name</label>
            <asp:TextBox ID="txtname" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label for="exampleInputEmail1">Date</label>
            <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtdate" ID="txtdate_CalendarExtender"></asp:CalendarExtender>
        </div>
        <div class="form-group col-md-6">
            <label for="exampleInputEmail1">Mobile</label>
            <asp:TextBox ID="txtmob" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label for="exampleInputEmail1">City</label>
            <asp:TextBox ID="txtcity" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-12">
            <label for="exampleInputEmail1">Passport No</label>
            <asp:TextBox ID="txtpassport" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label for="exampleInputEmail1">D.O.B</label>
            <asp:TextBox ID="txtdob" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtdob" ID="txtdob_CalendarExtender"></asp:CalendarExtender>
        </div>
        <div class="form-group col-md-6">
            <label for="exampleInputEmail1">D.O.E</label>
            <asp:TextBox ID="txtdoe" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtdoe" ID="txtdoe_CalendarExtender"></asp:CalendarExtender>
        </div>
        <div class="form-group col-md-12">
            <label for="exampleInputEmail1">D.O.E 1st Choice</label>
            <asp:TextBox ID="txtd1" TextMode="DateTime" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="form-group col-md-12">
            <label for="exampleInputEmail1">Module</label>
            <asp:DropDownList ID="CheckBoxList2" AutoPostBack="true" CssClass=" form-control" OnTextChanged="CheckBoxList2_TextChanged" runat="server">
                <asp:ListItem>GT</asp:ListItem>
                <asp:ListItem>AC</asp:ListItem>
                <asp:ListItem>PTE</asp:ListItem>
            </asp:DropDownList>
           
        </div>
        <div class="form-group col-md-6">
            <label for="exampleInputEmail1">Venue 1</label>
            <asp:TextBox ID="txtv1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-3">
            <label for="exampleInputEmail1">Username</label>
            <asp:TextBox ID="txtuname" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
      <div class="form-group col-md-3">
            <label for="exampleInputEmail1">Password</label>
            <asp:TextBox ID="txtpass" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>

        <div class="form-group col-md-12">
            <label for="exampleInputEmail1">Mode Of Payment</label>
            <asp:TextBox ID="txtmode" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-12">
            <label for="exampleInputEmail1">Agency</label>
            <div class="radio radio-primary">
                <asp:RadioButtonList ID="rdomode" runat="server">
                    <asp:ListItem>Idp</asp:ListItem>
                    <asp:ListItem>British Council</asp:ListItem>
                    <asp:ListItem>OET</asp:ListItem>
                    <asp:ListItem>Pearson</asp:ListItem>
                    <asp:ListItem>ETS</asp:ListItem>
                </asp:RadioButtonList>

            </div>
        </div>
        <div class="form-group col-md-12" style="display:none">
            <label for="exampleInputEmail1">Institute Name</label>
            <asp:TextBox ID="txtinst" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label for="exampleInputEmail1">Passport</label>
            <asp:FileUpload ID="fpass" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group col-md-6">
            <label for="exampleInputEmail1">Acknowledgement</label>
            <asp:FileUpload ID="fackn" runat="server" CssClass="form-control" />
        </div>

        <asp:Button ID="btnsubmit" class="btn btn-default" OnClick="btnsubmit_Click" runat="server" Text="Submit" />
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>

