<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="view-detail.aspx.cs" Inherits="Auth_view_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Institute Detail
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">

    <asp:GridView ID="gvdata" OnRowCommand="gvdata_RowCommand" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id" />
            <asp:BoundField DataField="name" HeaderText="Name" />
            <asp:BoundField DataField="phone" HeaderText="Phone" />
            <asp:BoundField DataField="address" HeaderText="Address" />
            <asp:BoundField DataField="uname" HeaderText="SMS User" />
            <asp:BoundField DataField="pass" HeaderText="SMS Pass" />
            <asp:BoundField DataField="sid" HeaderText="senderid" />
            <asp:TemplateField HeaderText="logo">
                <ItemTemplate>
                    <img src="../uploadimage/<%#Eval("logo") %>" width="80" />
                </ItemTemplate>
            </asp:TemplateField>
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


