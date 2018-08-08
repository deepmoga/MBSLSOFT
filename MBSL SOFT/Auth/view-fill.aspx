<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="view-fill.aspx.cs" Inherits="Auth_view_fill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Exam Registration
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <asp:Button ID="Button1" OnClick="Button1_Click" CssClass="btn btn-default" runat="server" Text="Add Paper" />
    <asp:GridView ID="gvdata" OnRowCommand="gvdata_RowCommand" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id" Visible="false" />
            <asp:TemplateField HeaderText="Id">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="name" HeaderText="Name" />
            <asp:BoundField DataField="passport" HeaderText="Passport No." />
            <asp:BoundField DataField="dob" HeaderText="D.O.B" />
            <asp:BoundField DataField="doe" HeaderText="D.O.E" />
            <asp:BoundField DataField="module" HeaderText="Module" />
            <asp:BoundField DataField="status" HeaderText="Filled Under" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit" CommandArgument='<%#Eval("id") %>' CssClass="label label-info">Edit</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="label label-primary" CommandName="slip" CommandArgument='<%#Eval("fid") %>'>Re Print Slip</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#2A3F54" ForeColor="White" />
                </asp:GridView>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

