<%@ Page Language="C#" AutoEventWireup="true" CodeFile="print-bill.aspx.cs" Inherits="Auth_print_bill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        p {
            margin: 0px;
            line-height: 15px;
        }

        .auto-style2 {
            width: 544px;
        }

        .auto-style3 {
            width: 166px;
        }

        .auto-style4 {
            width: 376px;
        }

        .auto-style7 {
            width: 202px;
        }

        .auto-style8 {
        }
        .auto-style9 {
            width: 174px;
        }
    </style>
    <script type="text/javascript">
        function printpage() {
            //Get the print button and put it into a variable
            var printButton = document.getElementById("printpagebutton");
            //Set the print button visibility to 'hidden' 
            printButton.style.display = 'none';
            //Print the page content
            window.print()
            //Set the print button to 'visible' again 
            //[Delete this line if you want it to stay hidden after printing]
            printButton.style.display = 'none';
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <input id="printpagebutton" type="button" value="Print this page" onclick="printpage()"/>
        <div style=" width: 725px; height: 520px; padding: 2px; color: black; ">
            <div style="float: left; width: 723px;">
                <table style="width: 100%; text-align:center">
                    <tr>
                        <td>
                            <img src="http://englishpunjab.com/img/logo-color1.png" width="400px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Ph. <%=phn %></p>
                        </td>
                    </tr>
                   <%-- <tr>
                        <td>
                            <p>Email:mbslzira@gmail.com</p>
                        </td>
                    </tr>--%>
                </table>
            </div>
            <div style="float: left; width: 100%; border-bottom: 1px solid; padding-bottom: 0px;">
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style2">&nbsp;</td>
                        <td>Receipt No:. <%=rno %></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style2" style="text-align: center">
                            <b>RECEIPT </b>
                        </td>
                        <td>Date :<%=date %></td>
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 100%; border-bottom: 1px solid">
                <table style="width: 100%; font-size:14px">
                    <tr>
                        <td class="auto-style3">Received From</td>
                        <td><%=name %></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">S.O/D.O/W.O</td>
                        <td><%=father %></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Address</td>
                        <td><%=address %></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">City/Village</td>
                        <td>Zira</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Program</td>
                        <td><%=cname %></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Phone No.</td>
                        <td><%=phone %></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Payment Mode</td>
                        <td>CASH</td>
                        <td>&nbsp;</td>
                    </tr>
                    
                </table>
            </div>
            <div style="float: left; width: 100%; border-bottom: 1px solid">
                <table style="width: 100%; font-size:14px">
                    <tr>
                        <td class="auto-style4" colspan="2">As per details given below :</td>
                        <td>Installments Details</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">Total Amount :</td>
                        <td class="auto-style7"><%=cfee %></td>
                        <td rowspan="3">
                            <asp:GridView ID="gvinst" Width="100%" GridLines="None" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvinst_RowDataBound">
                                <Columns>
                                    
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="amount" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">Paid Amount</td>
                        <td class="auto-style7"><b><%=amt %></b> </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">Discount</td>
                        <td class="auto-style7"><b><%=dis %></b> </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">Pending Amount</td>
                        <td class="auto-style7"><b><%=pen %></b> </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8" colspan="3">&nbsp;In Words :<%=rsword %></td>
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 100%; border-bottom: 1px solid">
                <div style="float: left; width: 325px;">
                    <h3 style="margin:0px">Terms & Conditions</h3>
                    <ul style="padding: 0px; margin: 0px; list-style: none;font-size:13px">
                        <li>1. Fee will not be refundable at any cost.</li>
                        <li>2. Maintain the discipline in class.</li>
                        <li>3. Use of mobile phone is prohibited in the class. </li>
                        <li>4. All the dues must be cleared within 15 days of admission.</li>
                       
                    </ul>
                </div>
                <div style="float: left; width: 398px;">
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td colspan="2">For M.B.S.L</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">Candidate Signature</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td colspan="2">Auth Signatory</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

        <br />
        <div style=" width: 725px; height: 520px; padding: 2px; color: black; ">
            
            <div style="float: left; width: 723px;">
                <table style="width: 100%; text-align:center">
                    <tr>
                        <td>
                            <img src="http://englishpunjab.com/img/logo-color1.png" width="400px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Ph. <%=phn %></p>
                        </td>
                    </tr>
                  <%--  <tr>
                        <td>
                            <p>Email:mbslzira@gmail.com</p>
                        </td>
                    </tr>--%>
                </table>
            </div>
            <div style="float: left; width:100%;border-bottom: 1px solid; padding-bottom: 0px;">
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style2">&nbsp;</td>
                        <td>Receipt No:. <%=rno %></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style2" style="text-align: center">
                            <b>RECEIPT </b>
                        </td>
                        <td>Date :<%=date %></td>
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 100%; border-bottom: 1px solid">
                <table style="width: 100%;font-size:14px">
                    <tr>
                        <td class="auto-style3">Received From</td>
                        <td><%=name %></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">S.O/D.O/W.O</td>
                        <td><%=father %></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Address</td>
                        <td><%=address %></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">City/Village</td>
                        <td>Zira</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Program</td>
                        <td><%=cname %></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Phone No.</td>
                        <td><%=phone %></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Payment Mode</td>
                        <td>CASH</td>
                        <td>&nbsp;</td>
                    </tr>
                    
                </table>
            </div>
            <div style="float: left; width: 100%; border-bottom: 1px solid">
                <table style="width: 100%; font-size:14px">
                    <tr>
                        <td class="auto-style4" colspan="2">As per details given below :</td>
                        <td>Installments Details</td>
                    </tr>
                    <tr>
                        <td class="auto-style8">Total Amount :</td>
                        <td class="auto-style7"><%=cfee %></td>
                        <td rowspan="3">
                              <asp:GridView ID="GridView1" Width="100%" GridLines="None" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate1" runat="server" Text='<%#Eval("date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="amount" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">Paid Amount</td>
                        <td class="auto-style7"><b><%=amt %></b> </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">Discount</td>
                        <td class="auto-style7"><b><%=dis %></b> </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">Pending Amount</td>
                        <td class="auto-style7"><b><%=pen %></b> </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style8" colspan="3">&nbsp;In Words :<%=rsword %></td>
                    </tr>
                </table>
            </div>
            <div style="float: left; width: 100%; border-bottom: 1px solid">
                <div style="float: left; width: 325px;">
                    <h3 style="margin:0px">Terms & Conditions</h3>
                    <ul style="padding: 0px; margin: 0px; list-style: none;font-size:13px">
                        <li>1. Fee will not be refundable at any cost.</li>
                        <li>2. Maintain the discipline in class.</li>
                        <li>3. Use of mobile phone is prohibited in the class. </li>
                        <li>4. All the dues must be cleared within 15 days of admission.</li>
                    </ul>
                </div>
                <div style="float: left; width: 398px;">
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td colspan="2">For M.B.S.L</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">Candidate Signature</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style9">&nbsp;</td>
                            <td colspan="2">Auth Signatory</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
