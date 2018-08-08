<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Ledger.aspx.cs" Inherits="Auth_Ledger" %>
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
    Date Wise Report
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    
<div class="grid" style=" width:1041px; margin-bottom:30px">
        <asp:Panel ID="Panel2" runat="server" Visible="false">
                <span style=" color:black">Select Franchisee</span>
                <asp:DropDownList ID="ddlfranc" runat="server" 
                        onselectedindexchanged="ddlfranc_SelectedIndexChanged" AutoPostBack="true" CssClass="simple-input"></asp:DropDownList>
                        </asp:Panel>
    </div>
    <div>
    <br />

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
                <label for="exampleInputFile">Type</label>
                <asp:DropDownList ID="ddltype" runat="server"
                    AutoPostBack="True" OnSelectedIndexChanged="ddltype_SelectedIndexChanged" CssClass="form-control">
                    <asp:ListItem>--All--</asp:ListItem>
                    <asp:ListItem>Expense</asp:ListItem>
                    <asp:ListItem>Course Fees</asp:ListItem>
                   
                </asp:DropDownList>
            </div>
             <div class="form-group col-md-3">
                 <br />
                 <asp:Button ID="BtnLoadReport"  CssClass="btn btn-default" runat="server" 
            Text="Load Report" onclick="BtnLoadReport_Click" />
             </div>
        </section>
  
        <asp:Panel ID="pnltype" Width="500px"  runat="server">
        
      <%-- Expenses: <asp:DropDownList ID="ddlExpense" runat="server" >
        </asp:DropDownList>
      
       Course Wise Fees: <asp:DropDownList ID="ddlCourseWiseFees" runat="server">
        </asp:DropDownList>
        Lpu Payments <asp:DropDownList ID="ddlLpuPayments" runat="server">
        </asp:DropDownList>--%>
        </asp:Panel>
       &nbsp;&nbsp   
    <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
        <br /><br />
        <asp:Panel ID="Panel1" runat="server">
 
       
            <asp:DataGrid ID="gridPaymentinfo" runat="server" AutoGenerateColumns="false" Width="100%"
                HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#C2DCEB"
                HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="black"
                OnItemDataBound="gridPaymentinfo_ItemDataBound" CssClass="table table-bordered">


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
                            Expenses
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <div style="padding-left: 4px;"><%# Eval("Expense_Name")%></div>

                        </ItemTemplate>

                    </asp:TemplateColumn>

                    <asp:TemplateColumn>

                        <HeaderTemplate>
                            Income
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <div style="padding-left: 4px;"><%# Eval("Income")%></div>
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
       <tr> <td>Total Expense:</td><td><%=total_expense %></td></tr>
        <tr>  <td> Total Income: &nbsp</td><td> <%=totalIncome %></td></tr>
        <tr>  <td> Profit/Loss: &nbsp</td><td> <%=Total %></td></tr>
        </table>
        </div>
         </asp:Panel>
        <%--<asp:DataGrid ID="gridPaymentinfo" runat="server" AutoGenerateColumns="false" Width="100%"
          HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#C2DCEB" ShowFooter="False"
        HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="black"  >
      
        
        <Columns>
            <asp:TemplateColumn>
                <HeaderTemplate>
                    #</HeaderTemplate>
                <ItemTemplate>
                    &nbsp;&nbsp;<%# Container.DataSetIndex+1 %>
                </ItemTemplate>
              
            </asp:TemplateColumn>
        

           
     
           <asp:TemplateColumn>
         
                <HeaderTemplate>
                Particulars
                </HeaderTemplate> <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate> 
                     <div style="padding-left:4px;"><%# Eval("paymenttype")%></div>
                     <asp:Label ID="lblsts" runat="server" visible="false" Text='<%#  Eval("status") %>'></asp:Label>
                   <input type="hidden" runat="server" id="hdnpagename" value='<%# DataBinder.Eval(Container.DataItem,"pagename") %>' />
                </ItemTemplate>
              
        </asp:TemplateColumn>
          <asp:TemplateColumn>
         
                <HeaderTemplate>
               Qty
                </HeaderTemplate> <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate> 
                     <div style="padding-left:4px;"><%# Eval("qty")%></div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>
        <asp:TemplateColumn>
         
                <HeaderTemplate>
                 Amount(Rs.)<br />
                 <table  width="200px">
                 <tr><td style="width:100px;">Charges</td><td>Received</td></tr>
                 </table>
                 
                </HeaderTemplate> <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate> 
                     <div style="padding-left:4px;">
                     <table width="200px">
                     <tr>
                     <td style="width:100px;"><%#  Eval("status").ToString() == "Expense" ? Eval("amount") :  "0.00"%></td><td><%#  Eval("status").ToString() != "Expense" ? Eval("amount") : "0.00"%></td>
                     </tr>
                     </table>
                     </div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>
     
          <asp:TemplateColumn>
         
                <HeaderTemplate>
                   Total (Rs.)
                </HeaderTemplate> 
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate> 
                     <div  style='padding-left:4px;' >
                     
                     <%# Eval("totalamount")%>
                     
                     </div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>
        
       
    
        
        
        </Columns></asp:DataGrid>--%>
        <br />
       
      
         <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-danger" Text="Print" OnClientClick = "return PrintPanel();" />
         <asp:Button ID="btnBack" CssClass="btn btn-info" 
            PostBackUrl="Default.aspx" runat="server" Text="Back"   />
    </div>
    <div style="text-align:right">
      <asp:Button ID="btnExporttoexcel" CssClass="btn btn-success"  runat="server" 
            Text="Export Reports to Excel" onclick="btnExporttoexcel_Click" />
       
      </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

