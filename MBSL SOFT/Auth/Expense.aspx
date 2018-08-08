<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Expense.aspx.cs" Inherits="Auth_Expense" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Expense
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-8">

        <div class="form-group">
            <label>Date</label>
            <asp:TextBox ID="txtdate" CssClass="form-control" runat="server"></asp:TextBox>

            <asp:CalendarExtender runat="server" Enabled="True" TargetControlID="txtdate" ID="txtdate_CalendarExtender"></asp:CalendarExtender>
        </div>

        <div class="form-group">
            <label>Expense</label>
            <input type="text" required placeholder="Name" Class="form-control" id="txtexpense" runat="server" />
        </div>

        <div class="form-group">
            <label>Payment Type</label>
            <asp:DropDownList ID="ddlpayment" runat="server" CssClass="form-control"
                AutoPostBack="True" OnSelectedIndexChanged="ddlpayment_SelectedIndexChanged1">
                <asp:ListItem>Cash</asp:ListItem>
                <asp:ListItem>Cheque</asp:ListItem>
                <asp:ListItem>Draft</asp:ListItem>
            </asp:DropDownList>
        </div>


        <asp:Panel ID="pnlcash" runat="server" Enabled="False">
            <div class="form-group">
                <label>Amount</label>
                <input type="text" placeholder="Amount" Class="form-control" id="txtamount" runat="server" />
            </div>

        </asp:Panel>

        <asp:Panel ID="pnldrft" Visible="false" runat="server">
            <div class="form-group">
                <label>Draft No</label>
                <input type="text" placeholder="" Class="form-control" id="txtDrftNo" runat="server" />
            </div>

        </asp:Panel>
        <asp:Panel ID="pnlCheque" Visible="false" runat="server">
            <div class="form-group">
                <label>cheque No</label>
                <input type="text" placeholder="ChequeN No" Class="form-control" id="txtChequeNo" runat="server" />
            </div>
            <div class="form-group">
                <label>Bank Name</label>
                <input type="text" placeholder="Bank Name" Class="form-control" id="txtBankName" runat="server" />
            </div>
            <div class="form-group">
                <label>Branch Name</label>
                <input type="text" placeholder="Branch Name" Class="form-control" id="txtBranchName" runat="server" />
            </div>
            <div class="form-group">
                <label>Cheque Date</label>
                <asp:TextBox ID="txtChequeDate" runat="server" Class="form-control"></asp:TextBox>


                <asp:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtChequeDate" ID="txtChequeDate_CalendarExtender"></asp:CalendarExtender>
            </div>
            <div class="form-group">
                <label>Status</label>
                <asp:DropDownList ID="ddlStatus"  runat="server" CssClass="form-control">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Deposited</asp:ListItem>
                    <asp:ListItem>Cleareed</asp:ListItem>
                </asp:DropDownList>
            </div>

        </asp:Panel>
        <div class="form-group">
            <%--<label>Resume</label>--%>
        </div>
          <div class="form-group">
                   <asp:Button CssClass="btn btn-default" ID="btnsubmit" runat="server" 
                       Text="Submit" OnClick="fvSubmit_Click"  />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

