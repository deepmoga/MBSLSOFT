<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="admin_Reports" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<script type = "text/javascript">
    function PrintPanel() {
        var panel = document.getElementById("<%=Panel1.ClientID %>");
        var printWindow = window.open('', '', 'height=400,width=800');
        printWindow.document.write('<html><head><title>Meeting</title>');
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="grid" style=" width:1041px; margin-bottom:30px">
        <asp:Panel ID="Panel2" runat="server" Visible="false">
                <span style=" color:black">Select Franchisee</span>
                <asp:DropDownList ID="ddlfranc" runat="server" 
                        onselectedindexchanged="ddlfranc_SelectedIndexChanged" AutoPostBack="true" CssClass="simple-input"></asp:DropDownList>
                        </asp:Panel>
    </div>
    <div>
    <br />
    Date From: 
        <asp:TextBox ID="txtFromDate" CssClass="txtbox simple-input" runat="server" ></asp:TextBox>
         
        <asp:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server"  PopupButtonID="Image2"
        Enabled="True" TargetControlID="txtFromDate" Format="dd/MM/yyyy">
    </asp:CalendarExtender>
         <asp:Image ID="Image2" runat="server" ImageUrl="~/admin/images/cal.png"/>
        &nbsp;&nbsp To: <asp:TextBox ID="txtToDate"  CssClass="txtbox simple-input" runat="server"></asp:TextBox>
                 <asp:Image ID="Image1" runat="server" ImageUrl="~/admin/images/cal.png"/>
    <asp:CalendarExtender ID="txtToDate_CalendarExtender" runat="server"  PopupButtonID="Image1"
        Enabled="True" TargetControlID="txtToDate" Format="dd/MM/yyyy">
    </asp:CalendarExtender>
                 
    
        &nbsp;&nbsp
        <br />
        <br />
       Select Type: <asp:DropDownList ID="ddltype" runat="server" 
            AutoPostBack="True" onselectedindexchanged="ddltype_SelectedIndexChanged" CssClass="simple-input">
       <asp:ListItem>--All--</asp:ListItem>
       <asp:ListItem>Expense</asp:ListItem>
       <asp:ListItem>Course Fees</asp:ListItem>
       <asp:ListItem>Lpu Payments</asp:ListItem>
         <asp:ListItem>Other Charges</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Panel ID="pnltype" Width="500px"  runat="server">
        
      <%-- Expenses: <asp:DropDownList ID="ddlExpense" runat="server" >
        </asp:DropDownList>
      
       Course Wise Fees: <asp:DropDownList ID="ddlCourseWiseFees" runat="server">
        </asp:DropDownList>
        Lpu Payments <asp:DropDownList ID="ddlLpuPayments" runat="server">
        </asp:DropDownList>--%>
        </asp:Panel>
       &nbsp;&nbsp   <asp:Button ID="BtnLoadReport"  CssClass="btn" runat="server" 
            Text="Load Report" onclick="BtnLoadReport_Click" />
    <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
        <br /><br />
        <asp:Panel ID="Panel1" runat="server">
 
       
           <asp:DataGrid ID="gridPaymentinfo" runat="server" AutoGenerateColumns="false" Width="100%"
          HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#C2DCEB" ShowFooter="False"
        HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="black" 
                onitemdatabound="gridPaymentinfo_ItemDataBound"  >
      
        
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
            Date
                </HeaderTemplate> <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate> 
                    <%-- <div style="padding-left:4px;"><%# Eval("Date")%></div>--%>
                    <asp:Label ID="lbldate" runat="server" Text='<%# Eval("Date")%>'></asp:Label>
                </ItemTemplate>
              
        </asp:TemplateColumn>
           
           <asp:TemplateColumn>
         
                <HeaderTemplate>
             Expenses
                </HeaderTemplate> <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate> 
                     <div style="padding-left:4px;"><%# Eval("Expense_Name")%></div>
               
                </ItemTemplate>
              
        </asp:TemplateColumn>
     
           <asp:TemplateColumn>
         
                <HeaderTemplate>
                Income
                </HeaderTemplate> <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate> 
                     <div style="padding-left:4px;"><%# Eval("Income")%></div>
                    <%-- <asp:Label ID="lblsts" runat="server" visible="false" Text='<%#  Eval("status") %>'></asp:Label>
                   <input type="hidden" runat="server" id="hdnpagename" value='<%# DataBinder.Eval(Container.DataItem,"pagename") %>' />--%>
                </ItemTemplate>
              
        </asp:TemplateColumn>
          <asp:TemplateColumn>
         
                <HeaderTemplate>
             Amount
                </HeaderTemplate> <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate> 
                     <div style="padding-left:4px;"><%# Eval("Amount")%></div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn></Columns></asp:DataGrid>

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
       
        <asp:Button ID="btnPrint" CssClass="btn" runat="server" OnClientClick="PrintPanel()" Text="Print" />
         <asp:Button ID="btnBack" CssClass="btn" 
            PostBackUrl="~/Franchisee/Default.aspx" runat="server" Text="Back"  />
    </div>
    <div style="text-align:right">
      <asp:Button ID="btnExporttoexcel" CssClass="btn"  runat="server" 
            Text="Export Reports to Excel" onclick="btnExporttoexcel_Click" />
       
      </div>
</asp:Content>

