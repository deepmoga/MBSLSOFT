<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Dashboard-Inquiry.aspx.cs" Inherits="Auth_Dashboard_Inquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Enquiry Alert
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Enquiry Alert</h3>
            </div>
            <div class="panel-body">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" CssClass="table table-bordered">
                    <Columns>
                     
                        <asp:TemplateField HeaderText="AlertDate">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text=''><%# Convert.ToDateTime (Eval("date")).ToString("dd/MM/yyyy") %></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="name" HeaderText="Name" />
                        <asp:BoundField DataField="contact" HeaderText="Phone" />
                        <asp:BoundField DataField="feedback" HeaderText="Last Reply" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton5" CommandName="view" CommandArgument='<%#Eval("inquiryid") %>' CssClass="label label-danger" runat="server">Profile</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

