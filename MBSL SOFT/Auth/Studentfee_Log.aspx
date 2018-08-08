<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/profile.master" AutoEventWireup="true" CodeFile="Studentfee_Log.aspx.cs" Inherits="Auth_Studentfee_Log" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
    <style type="text/css">
        .auto-style1 {
        }

        .auto-style2 {
            width: 97px;
        }

        .auto-style3 {
            width: 211px;
        }

        .auto-style4 {
            width: 225px;
            text-align: right;
        }

        .auto-style5 {
            width: 37px;
        }

        .modal-backdrop.fade.in {
            display: none;
        }
        span{float:left;line-height: initial !important;}

        .modal {
            position: fixed;
            top: 0;
            left: 0;
            background-color: rgba(0, 0, 0, 0.49) !important;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
    </style>
    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>
     <script type="text/javascript">
         function OpenPopUp() {
             window.open('print-bill.aspx?ID=<%=lastrc%>,<%=lastpa%>,<%=cid%>,<%=rno%>,<%=lbldate.Text%>,<%=discont%>,<%=pend%>,reprint', 'MyWindow', 'width=500,height=600');
            return false;
        }
                </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Logs
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
    <div class="col-md-2 col-md-offset-10 text-right" style="display:none">
        <asp:DropDownList ID="ddlcourse" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
    </div>
    <br />
    <div class="col-md-12">

        <asp:GridView ID="GrdDetail" CssClass=" table table-bordered" runat="server"
            CellPadding="4" AutoGenerateColumns="False" PageSize="20" AllowPaging="True"
            BorderStyle="None" BorderWidth="1px"
            Style="width: 100%; text-align: center"
            OnRowDataBound="GrdDetail_RowDataBound" class="table table-bordered" OnRowCommand="GrdDetail_RowCommand" OnRowCancelingEdit="GrdDetail_RowCancelingEdit">

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
                <asp:TemplateField Visible="false" HeaderText="Id">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfto" runat="server" Value='<%#Eval("fid") %>' />
                        <asp:HiddenField ID="hfcid" runat="server" Value='<%#Eval("courseid") %>' />
                        <asp:HiddenField ID="hftot" runat="server" Value='<%#Eval("totalpaidfees") %>' />
                        <asp:Label ID="lblid" runat="server" Text='<%#Eval("id")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date")  %>'></asp:Label>

                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Course Name">
                    <ItemTemplate>
                        <asp:Label ID="lblcourse" runat="server" Text='<%#Eval("particular")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Receipt No">
                    <ItemTemplate>
                        <asp:Label ID="lbloldrecpt" runat="server" Text='<%#Eval("ReciptNo")  %>'></asp:Label>
                        <asp:Label ID="lblstatus" runat="server" CssClass=" label label-danger" Text='<%#Eval("cancelauthorisation")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" Old Receipt No" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblrecpt" runat="server" Text='<%#Eval("oldreceiptno")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fees Period">
                    <ItemTemplate>
                        <asp:Label ID="lblfrom" runat="server" CssClass="label label-info btn" Text='<%#Eval("fromdate") %>'></asp:Label>
                       <span>/</span> 
                        <asp:Label ID="lblto" CssClass="label label-primary btn" runat="server" Text='<%#Eval("todate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Total Fee">
                    <ItemTemplate>
                        <asp:Label ID="lbltotal" runat="server" Text='<%#Eval("totalfees") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Discount">
                    <ItemTemplate>
                        <asp:Label ID="lbldiscount" runat="server" Text='<%#Eval("discount")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Paid">
                    <ItemTemplate>
                        <asp:Label ID="lblpaidfee" runat="server" Text='<%#Eval("paid")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pending Alert">
                    <ItemTemplate>
                        <asp:Label ID="lbladate" runat="server" Text='<%#Eval("pending_fees_alert")  %>'></asp:Label>
                        <span>/</span> 
                        <asp:Label ID="Label2" CssClass="btn label label-danger" runat="server" Text='<%#Eval("pending_fees")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="cancel" CssClass="label label-info" CommandArgument='<%#Eval("id")+","+Eval("date")+","+Eval("tokenno")+","+Eval("totalfees")+","+Eval("courseid") %>'>Cancel</asp:LinkButton>

                        <asp:LinkButton ID="lnkslipdel" runat="server" CommandName="reprint" CssClass="label label-danger" CommandArgument='<%#Eval("id") %>'>Print Slip</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

        <div class="col-md-8 col-md-offset-2" style="display: none">
            <div class="col-md-3">
                <label>Total Fee</label>
                : 
                  <asp:Label ID="lbltotal2" runat="server" Text='' ForeColor="orange" Font-Bold="true"><%=to %></asp:Label>
            </div>

            <div class="col-md-2">
                <label>Discount</label>
                : 
                 <asp:Label ID="lbldisc" runat="server" Text="" ForeColor="Gray" Font-Bold="true"><%=dis %></asp:Label>
            </div>

            <div class="col-md-3">
                <label>Total Paid</label>
                : 
                 <asp:Label ID="lblpaid" runat="server" Text="" ForeColor="Green" Font-Bold="true"><%=pai %></asp:Label>
            </div>

            <div class="col-md-3">
                <label>Pending</label>
                : 
                 <asp:Label ID="lblpending" runat="server" Text="" ForeColor="Red" Font-Bold="true"><%=pen %></asp:Label>
            </div>

        </div>
    </div>
    <div class="row">
        <button type="button" id="btnShowPopup" style="display: none" class="btn btn-primary btn-lg"
            data-toggle="modal" data-target="#myModal">
            Launch demo modal
        </button>
        <div class="modal fade" id="myModal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Fees Receipt</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:Panel ID="pnlContents" runat="server">
                            <div style="width: 725px; height: 380px; padding: 20px; color: black; border: 1px solid;">
                                <table style="width: 100%;">
                                    <tr style="text-align: center">
                                        <td colspan="3">
                                            <h2 style="font-size: 60px; margin: 0PX; text-transform: uppercase; font-family: cursive;"><%=instname %></h2>
                                            <p style="margin: 0PX; text-transform: uppercase"><%=instadd %></p>
                                            <p style="margin: 0PX;">Ph: <%=instph %></p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="width: 50px;">No. :</td>
                                                    <td class="auto-style2"><b>
                                                        <asp:Label ID="lblrno" runat="server" Text=""><%=lastrc %></asp:Label></b> </td>
                                                    <td style="width: 478px;">&nbsp;</td>
                                                    <td class="auto-style4">Dated : </td>
                                                    <td><b>
                                                        <asp:Label ID="lbldate" runat="server" Text=""></asp:Label></b></td>
                                                </tr>

                                                <tr>
                                                    <td class="auto-style1" colspan="5">
                                                        <section style="margin-top: 20px !important; float: left; width: 100%; margin: 5px 0px;">
                                                            <p style="font-size: 17px; margin: 0px; float: left">Received with thanks from : </p>
                                                            <p style="border-bottom: 2px dotted black; float: left; width: 450px; margin: 0px; font-size: 14px; font-weight: bold; height: 24PX">
                                                                <asp:Label ID="lblrname" runat="server" Text=""></asp:Label>
                                                            </p>
                                                        </section>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1" colspan="5">
                                                        <section style="float: left; width: 100%; margin: 5px 0px;">
                                                            <p style="font-size: 17px; margin: 0px; float: left">the sum of Rupees : &nbsp</p>
                                                            <p style="border-bottom: 2px dotted black; float: left; width: 450px; font-size: 14px; font-weight: bold; margin: 0px; height: 24PX">
                                                                <asp:Label ID="lblramt" runat="server" Text=""></asp:Label>
                                                            </p>
                                                        </section>
                                                    </td>
                                                </tr>
                                                <%-- <tr>
                                                        <td class="auto-style1" colspan="5"><section style="    float: left;width: 100%;margin: 5px 0px;border-bottom:2px dotted black;    height: 23px;"> </section> </td>
                                                    </tr>--%>
                                                <tr>
                                                    <td class="auto-style1" colspan="5">
                                                        <section style="float: left; width: 100%; margin: 5px 0px;">
                                                            <p style="font-size: 17px; margin: 0px; float: left">by Cash/Cheque/Draft No. : &nbsp</p>
                                                            <p style="border-bottom: 2px dotted black; float: left; width: 327px; font-size: 14px; font-weight: bold; margin: 0px; height: 24PX">
                                                                <asp:Label ID="lblrcqno" runat="server" Text="N/A"></asp:Label>
                                                            </p>
                                                            <span style="font-size: 17px">Dt</span>
                                                            <p style="border-bottom: 2px dotted black; float: right; width: 114px; font-size: 17px; margin: 0px; height: 24PX">
                                                                <asp:Label ID="lbldtno" runat="server" Text="N/A"></asp:Label>
                                                            </p>
                                                        </section>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1" colspan="5">
                                                        <section style="float: left; width: 100%; margin: 5px 0px;">
                                                            <p style="font-size: 17px; margin: 0px; float: left">on account of : </p>
                                                            <p style="border-bottom: 2px dotted black; float: left; width: 450px; margin: 0px; font-size: 14px; font-weight: bold; height: 24PX"></p>
                                                        </section>
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td class="auto-style1" colspan="5">
                                                        <section style="float: left; width: 100%; margin: 20px 0px;">
                                                            <p style="font-size: 17px; margin: 0px; float: left">Rs. </p>
                                                            <p style="float: left; width: 450px; margin: 0px; font-size: 17px; height: 24PX">
                                                                <asp:Label ID="lblrtotal" runat="server" Text="0"><%=lastpa %></asp:Label>
                                                            </p>
                                                            <p style="float: right; width: 131px; font-size: 17px; margin: 0px; height: 24PX">Signature</p>
                                                        </section>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnPrint" CssClass="btn btn-primary" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Close</button>

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
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

