<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Expense-List.aspx.cs" Inherits="Auth_Expense_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Expense List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <asp:Button ID="Button1" OnClick="Button1_Click" CssClass="btn btn-default" runat="server" Text="Add Expense" />
    <asp:GridView ID="gvdata" OnRowCommand="gvdata_RowCommand" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id" />
            <asp:BoundField DataField="date" HeaderText="Date" />
            <asp:BoundField DataField="expense_name" HeaderText="Expense" />
            <asp:BoundField DataField="amount" HeaderText="Amount" />
            <asp:BoundField DataField="paymenttype" HeaderText="Type" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit" CommandArgument='<%#Eval("id") %>' CssClass="label label-info">Edit</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#2A3F54" ForeColor="White" />
                </asp:GridView>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

