<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="StudentReport.aspx.cs" Inherits="Auth_StudentReport" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
    
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Student Report
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <section>
            <div class="form-group col-md-3">
                <label for="exampleInputEmail1">From</label>
                 <asp:TextBox ID="txtFromDate" CssClass=" form-control" runat="server" ></asp:TextBox>

                <asp:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDate" ID="txtFromDate_CalendarExtender"></asp:CalendarExtender>
            </div>
            <div class="form-group col-md-3">
                <label for="exampleInputPassword1">To</label>
                <asp:TextBox ID="txtToDate"  CssClass="form-control" runat="server"></asp:TextBox>

                <asp:CalendarExtender runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate" ID="txtToDate_CalendarExtender"></asp:CalendarExtender>
            </div>
         
             <div class="form-group col-md-3">
                 <br />
                 <asp:Button ID="BtnLoadReport"  CssClass="btn btn-default" runat="server" 
            Text="Load Report" onclick="BtnLoadReport_Click" />

             </div>
        <div class="form-group col-md-3">
            <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-danger" Text="Print" OnClientClick = "return PrintPanel();" />
        </div>
        </section>
    <asp:Panel ID="Panel1" runat="server">
 
       
            <asp:DataGrid ID="gridPaymentinfo" runat="server" AutoGenerateColumns="false" Width="100%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#C2DCEB"
                HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="black" CssClass="table table-bordered">


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
                            Date
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <%-- <div style="padding-left:4px;"><%# Eval("Date")%></div>--%>
                            <asp:Label ID="lbldate" runat="server" Text='<%# Eval("Date")%>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateColumn>

                    <asp:BoundColumn DataField="name" HeaderText="Name" ></asp:BoundColumn>

                    <asp:TemplateColumn>

                        <HeaderTemplate>
                            Course
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <div style="padding-left: 4px;"><%# Eval("Particular")%></div>

                        </ItemTemplate>

                    </asp:TemplateColumn>

                    <asp:TemplateColumn>

                        <HeaderTemplate>
                            Recipt No
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <div style="padding-left: 4px;"><%# Eval("reciptno")%></div>
                            <%-- <asp:Label ID="lblsts" runat="server" visible="false" Text='<%#  Eval("status") %>'></asp:Label>
                   <input type="hidden" runat="server" id="hdnpagename" value='<%# DataBinder.Eval(Container.DataItem,"pagename") %>' />--%>
                        </ItemTemplate>

                    </asp:TemplateColumn>
                    <asp:TemplateColumn>

                        <HeaderTemplate>
                            Amount
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <div style="padding-left: 4px;"><%# Eval("Amount")%></div>

                        </ItemTemplate>

                    </asp:TemplateColumn>
                </Columns>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            </asp:DataGrid>

        <div style="float:right; width:200px">
        <table>
       
        </table>
        </div>
         </asp:Panel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

