<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Outstanding-Report.aspx.cs" Inherits="Auth_Outstanding_Report" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
      <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=Panel1.ClientID %>");
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
      <style type="text/css">
          .auto-style1 {
              width: 768px;
          }
          .auto-style2 {
              width: 185px;
          }
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
Outstanding-Report
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <section>
        
        <div class="form-group col-md-3">
            <label for="exampleInputPassword1">As On</label>
            <asp:TextBox ID="txtToDate" CssClass="form-control" runat="server"></asp:TextBox>

            <asp:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate" ID="txtToDate_CalendarExtender"></asp:CalendarExtender>
        </div>

        <div class="form-group col-md-3">
            <br />
            <asp:Button ID="BtnLoadReport" CssClass="btn btn-default" runat="server"
                Text="Load Report" OnClick="BtnLoadReport_Click" />
            <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-danger" Text="Print" OnClientClick = "return PrintPanel();" />
        </div>
    </section>
    <asp:Panel ID="Panel1" runat="server">
        <asp:Panel ID="Panel2" runat="server">

        <asp:DataGrid ID="gridPaymentinfo" runat="server" AutoGenerateColumns="false" Width="100%"
            HeaderStyle-BackColor="#C2DCEB"
            HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="black" CssClass="table table-bordered" OnItemDataBound="gridPaymentinfo_ItemDataBound">


            <Columns>
                <asp:TemplateColumn>
                    <HeaderTemplate>
                        #
                    </HeaderTemplate>
                    <ItemTemplate>
                        &nbsp;&nbsp;<%# Container.DataSetIndex+1 %>
                    </ItemTemplate>

                </asp:TemplateColumn>

                <asp:TemplateColumn>

                    <HeaderTemplate>
                        Alert Date
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%-- <div style="padding-left:4px;"><%# Eval("Date")%></div>--%>
                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("alertdate")%>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateColumn>

                <asp:TemplateColumn>

                    <HeaderTemplate>
                        Name
                    </HeaderTemplate>
                    <ItemStyle  />
                    <ItemTemplate>
                        <div style="padding-left: 4px;"><%# Eval("rollno")%>&nbsp- &nbsp<%# Eval("name")%></div>

                    </ItemTemplate>

                </asp:TemplateColumn>

                <asp:TemplateColumn>

                    <HeaderTemplate>
                        Phone
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <div style="padding-left: 4px;"><%# Eval("phone")%></div>
                        <%-- <asp:Label ID="lblsts" runat="server" visible="false" Text='<%#  Eval("status") %>'></asp:Label>
                   <input type="hidden" runat="server" id="hdnpagename" value='<%# DataBinder.Eval(Container.DataItem,"pagename") %>' />--%>
                    </ItemTemplate>

                </asp:TemplateColumn>
                <asp:TemplateColumn>

                    <HeaderTemplate>
                        Balance
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <div style="padding-left: 4px;">
                            <asp:Label ID="lblamt" runat="server" Text='<%# Eval("fees")%>'><%# Eval("fees")%></asp:Label></div>

                    </ItemTemplate>

                </asp:TemplateColumn>
                

            </Columns>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
        </asp:DataGrid>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2"><b>Balance</b> </td>
                    <td><b>
                        <asp:Label ID="lbltotal" runat="server" Text="Label"></asp:Label>
                        </b></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            </asp:Panel>

      
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
</asp:Content>



