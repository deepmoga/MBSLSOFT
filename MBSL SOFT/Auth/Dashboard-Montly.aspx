<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Dashboard-Montly.aspx.cs" Inherits="Auth_Dashboard_Montly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
        <script src="../jquery.js"></script>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Monthly Alert
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12 clearfix">
        <div class="panel panel-default" style="overflow:hidden">
            <div class="panel-heading">
                <h3 class="panel-title">Monthly Fees Alert</h3>
            </div>
            <div class="panel-body">

                <div class="col-md-12" style="display: none">
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlCourse" CssClass=" form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddltime" CssClass=" form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnsubmit" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btnsubmit_Click" />

                    </div>

                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>
                <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-default" OnClientClick="return PrintPanel();" />
            </div>
            <div class="col-md-12">
                <asp:Panel ID="pnlContents" runat="server">
                    <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:GridView ID="GrdDetail" CssClass=" table table-bordered" runat="server"
                        CellPadding="4" AutoGenerateColumns="False" PageSize="20" AllowPaging="True" OnRowCommand="GrdDetail_RowCommand"
                        BorderColor="black" BorderStyle="None" BorderWidth="1px"
                        Style="width: 100%; text-align: center" class="table table-bordered" OnRowDataBound="GrdDetail_RowDataBound" OnPageIndexChanging="GrdDetail_PageIndexChanging">

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

                            <asp:TemplateField HeaderText="AlertDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblalert" runat="server" Text='<%#Eval("Alertdate","{0:D}") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkprofile" CommandName="Profile" CommandArgument='<%#Eval("id") %>' runat="server" CssClass="label label-primary">Profile</asp:LinkButton>

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

