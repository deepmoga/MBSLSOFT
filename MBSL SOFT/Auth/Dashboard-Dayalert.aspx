<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Dashboard-Dayalert.aspx.cs" Inherits="Auth_Dashboard_Dayalert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12 clearfix">
        <div class="panel panel-default" style="overflow:hidden">
            <div class="panel-heading">
                <h3 class="panel-title">Day Alert</h3>
            </div>
            <div class="panel-body">

               
               <%-- <asp:Button ID="Button3" runat="server" Text="Print" CssClass="btn btn-default" OnClientClick="return PrintPanel();" />--%>
            </div>
            <div class="col-md-12">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:Label ID="Label3" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:GridView ID="GridView2" CssClass=" table table-bordered" runat="server"
                        CellPadding="4" AutoGenerateColumns="False" PageSize="20" AllowPaging="True" 
                        BorderColor="black" BorderStyle="None" BorderWidth="1px"
                        Style="width: 100%; text-align: center" class="table table-bordered" OnRowDataBound="GridView2_RowDataBound" OnRowCommand="GridView2_RowCommand" >

                        <FooterStyle BackColor="#323b44" ForeColor="White" />
                        <HeaderStyle BackColor="#323b44" Font-Size="14px" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                        <PagerStyle BackColor="#323b44" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#323b44" Font-Bold="True" ForeColor="white" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />

                        <Columns>

                            <asp:TemplateField HeaderText="Sr. No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Roll No">
                                <ItemTemplate>

                                    <asp:Label ID="lblroll" runat="server" Text='<%#Eval("RollNo")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Roll No" Visible="false">
                                <ItemTemplate>

                                    <asp:Label ID="lblcid" runat="server" Text='<%#Eval("CourseId")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText=" Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblname" runat="server" Text='<%#Eval("name")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Father Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblfather" runat="server" Text='<%#Eval("fathername")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Contact">
                                <ItemTemplate>
                                    <asp:Label ID="lbldob" runat="server" Text='<%#Eval("phone")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>




                            <asp:TemplateField HeaderText="CourseName">
                                <ItemTemplate>
                                    <asp:Label ID="lblcontact" runat="server" Text='<%#Eval("CourseName")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Course End date">
                                <ItemTemplate>
                                    <asp:Label ID="lblalert" runat="server" Text='<%#Eval("enddate") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Days Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblleft" runat="server" Text=''></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkprofile" CommandName="Profile" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="label label-primary">Profile</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton1" CommandName="con" CommandArgument='<%#Eval("RollNo") %>' runat="server" CssClass="label label-primary">continuous</asp:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>

                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

