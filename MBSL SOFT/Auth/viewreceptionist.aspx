<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="viewreceptionist.aspx.cs" Inherits="Auth_viewreceptionist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Reception Details
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
  
    <div class="viewproduct">

        <div class="col-md-12 text-right">
            <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btn  btn-primary" 
                onclick="btnadd_Click1"/>
            <asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn btn-danger" 
                onclick="btnback_Click1"/>
        </div>
        <div class="clr">
    </div>


    
    <div class="grid">
        <asp:DataGrid ID="gridlist" runat="server" Width="100%" AutoGenerateColumns="false"
            OnItemCommand="gridlist_ItemCommand1" CssClass="table table-bordered"
            OnItemDataBound="gridlist_ItemDataBound">
            <Columns>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        #
                    </HeaderTemplate>
                    <ItemTemplate>
                        &nbsp;&nbsp;<%# Container.DataSetIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateColumn>

                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">

                    <HeaderTemplate>
                        Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center"><%# Eval("name")%></div>

                    </ItemTemplate>

                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">

                    <HeaderTemplate>
                        Date Of Birth
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbldob" runat="server" Text='<%# Eval("dob")%>'></asp:Label>
                        <%-- <div style=" text-align:center"><%# Eval("dob")%></div>--%>
                    </ItemTemplate>

                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">

                    <HeaderTemplate>
                        Father's Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center"><%# Eval("fname")%></div>

                    </ItemTemplate>

                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">

                    <HeaderTemplate>
                        Mother's Name
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center"><%# Eval("mname")%></div>

                    </ItemTemplate>

                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">

                    <HeaderTemplate>
                        Address
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center"><%# Eval("address")%></div>

                    </ItemTemplate>

                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">

                    <HeaderTemplate>
                        Email
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center"><%# Eval("email")%></div>

                    </ItemTemplate>

                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">

                    <HeaderTemplate>
                        Contact No.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center"><%# Eval("contact")%></div>

                    </ItemTemplate>

                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">

                    <HeaderTemplate>
                        Login ID
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center"><%# Eval("login")%></div>

                    </ItemTemplate>

                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">

                    <HeaderTemplate>
                        Password
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div style="text-align: center">
                            <asp:Label ID="lblpwd" runat="server" Text='<%# Eval("password")%>'></asp:Label>
                        </div>

                    </ItemTemplate>

                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        Action
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table>
                            <tr>

                                <td>&nbsp;
               <asp:linkButton ToolTip="Edit " runat="server" ID="lnkEdit" CssClass="label label-info" CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' Text="Edit" />
                                
                                </td>
                                <td>&nbsp; 
                                    <asp:LinkButton ToolTip="Delete" OnClientClick="return ConfirmDelete()" runat="server" ID="ImageButton1"  CssClass="label label-danger" Text="Delete" CommandName="delete"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' /></td>

                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="center" />
                </asp:TemplateColumn>
            </Columns>
            <HeaderStyle HorizontalAlign="Center" />
        </asp:DataGrid>
    </div>
    <div class="clr">
    </div>
  </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

