<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/profile.master" AutoEventWireup="true" CodeFile="Deposit-Fee.aspx.cs" Inherits="Auth_Deposit_Fee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
    <script src="../jquery.js"></script>
    <script type="text/javascript">
        function OpenPopUp() {
            window.open('print-bill.aspx?ID=<%=Reciptnumber%>,<%=txtamount.Text%>,<%=ddlcourse.SelectedItem.Value%>,<%=lblroll.Text%>,<%=txtdate.Text%>,<%=txtdiscount.Text%>,<%=txtpendingfee.Text%>,0', 'MyWindow', 'width=200,height=600');
            return false;
        }
                </script>
    <style>
        .dropdown-menu::after {
            border-bottom: 6px solid #999999;
            border-left: 6px solid transparent;
            border-right: 6px solid transparent;
            content: "";
            display: inline-block;
            right: 6%;
            position: relative;
            top: -13px;
        }
    </style>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Deposit Fees
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">

    
   
            <div class="product">

                <section class="col-md-8 ">


                    <div class="form-group text-right">


                        <asp:Button ID="btnother" runat="server" Text="Other Charges" CssClass="btn btn-success"
                            OnClick="btnother_Click" Visible="false" />

                    </div>
                    <div class="form-group">
                        <div class="col-md-2 ">
                            <label>Receipt No:</label>
                        </div>
                        <div class="col-lg-10">
                            <asp:Label ID="lblrecpt" runat="server" Text="" ForeColor="Red" Font-Bold="true" Visible="false" ></asp:Label>
                            <asp:TextBox ID="txtrecipt" CssClass="form-control" runat="server" ></asp:TextBox>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-2 ">
                            <label>Search Name:</label>
                        </div>
                        <div class="col-lg-10">
                            
                            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" CssClass="form-control" AutoPostBack="true" placeholder="Search Name then press enter button"></asp:TextBox>  
                <asp:AutoCompleteExtender ServiceMethod="GetCompletionList" MinimumPrefixLength="1"  
                    CompletionInterval="10" EnableCaching="false" CompletionSetCount="1" TargetControlID="TextBox1"  
                    ID="AutoCompleteExtender2" runat="server" FirstRowSelected="false">  
                </asp:AutoCompleteExtender>  
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-2 ">
                            <label>Roll No.:</label>
                        </div>
                        <div class="col-lg-10">
                            
                            <asp:TextBox ID="lblroll" CssClass="form-control" OnTextChanged="lblroll_TextChanged" AutoPostBack="true" runat="server" placeholder="Enter Roll No then press enter button"></asp:TextBox>

                            <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
                        </div>
                    </div>

                    <div class="form-group none">
                        <div class="col-md-2 ">
                            <label>Name:</label>
                        </div>
                        <div class="col-lg-10">

                            <asp:TextBox ID="lblname" OnTextChanged="lblname_TextChanged" runat="server" Text="" AutoPostBack="true" Enabled="false" CssClass="form-control"></asp:TextBox>
                            <asp:AutoCompleteExtender ServiceMethod="SearchCustomers"
                                MinimumPrefixLength="2"
                                CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                TargetControlID="lblname"
                                ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                            </asp:AutoCompleteExtender>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-2 ">
                            <label>Date</label>
                        </div>
                        <div class="col-lg-10">
                            <div class="input-group">
                                <asp:TextBox CssClass="form-control date" ID="txtdate" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtdate" PopupButtonID="Image4" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                <span class="input-group-btn btn btn-default" style="padding: 6px">
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/auth/images/cal.png" Width="20" />
                                </span>
                            </div>



                        </div>

                    </div>

                    <div class="form-group">
                        <div class="col-md-2 ">
                            <label>Select Course:</label>
                        </div>
                        <div class="col-lg-10">
                            <asp:DropDownList ID="ddlcourse" CssClass=" form-control" runat="server" OnSelectedIndexChanged="ddlcourse_SelectedIndexChanged1" AutoPostBack="true">
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="form-group" style="display:none">
                        <div class="col-md-2 ">
                            <label>Monthly Fees</label>
                        </div>
                        <div class="col-lg-10">
                            <asp:DropDownList ID="ddlmonth" Enabled="false" CssClass=" form-control" OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                <asp:ListItem>Select Fees Month</asp:ListItem>
                                <asp:ListItem>1 Month</asp:ListItem>
                                <asp:ListItem>2 Month</asp:ListItem>
                                <asp:ListItem>3 Month</asp:ListItem>
                                <asp:ListItem>4 Month</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="form-group" style="width: 600px">
                        <div class="col-md-2 ">
                            <label>Fees Period:</label>
                        </div>
                        <div class="col-lg-10">
                            <div class="col-md-6">

                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control date" ID="txtfrom" runat="server"
                                        OnTextChanged="txtfrom_TextChanged"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtfrom" PopupButtonID="Image2" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                    <span class="input-group-btn btn btn-default">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/auth/images/cal.png" Width="20" />
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control date" ID="txtto" runat="server" OnTextChanged="txtto_TextChanged"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtto" PopupButtonID="Image3" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                    <span class="input-group-btn btn btn-default">
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/auth/images/cal.png" Width="20" />
                                    </span>
                                </div>

                            </div>








                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-2 ">
                            <label>Fees Mode:</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*" ControlToValidate="ddlmode" ValidationGroup="g" ErrorMessage="Select Fee Mode"
                                InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-10">
                            <asp:DropDownList ID="ddlmode" runat="server" CssClass="form-control"
                                OnSelectedIndexChanged="ddlmode_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem>Select Mode</asp:ListItem>
                                <asp:ListItem Selected="True">Cash</asp:ListItem>
                                <asp:ListItem>Cheque</asp:ListItem>
                                <asp:ListItem>Draft</asp:ListItem>
                            </asp:DropDownList>


                        </div>

                    </div>
                    <div class="form-group">
                            <div class="col-md-2 ">
                                <label>Montly Fee:</label>
                            </div>
                            <div class="col-lg-10">
                                <asp:Label ID="lbltotal" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                     <div class="form-group none">
                            <div class="col-md-2 ">
                                <label>Discount Approved:</label>
                            </div>
                            <div class="col-lg-10">
                                <asp:Label ID="lbldisaprov" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    <div class="form-group">
                            <div class="col-md-2 ">
                                <label>Pending Fee:</label>
                            </div>
                            <div class="col-lg-10">
                                <asp:Label ID="lblpbalance" runat="server" Text="0"></asp:Label>
                            </div>
                        </div>
                    <asp:Panel ID="pnlfee" Visible="false" runat="server">
                        
                        <div class="form-group">
                            <div class="col-md-2 ">

                                <label>Total Fee:</label>
                            </div>
                            <div class="col-lg-10">
                                <asp:Label ID="lbltopa" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="form-group none">
                            <div class="col-md-2 ">

                                <label>Paid Fee:</label>
                            </div>
                            <div class="col-lg-10">
                                <asp:Label ID="lblppaid" runat="server" Text=""></asp:Label>
                            </div>
                        </div>

                        <div class="form-group none">
                            <div class="col-md-2 ">

                                <label>Discount:</label>
                            </div>
                            <div class="col-lg-10">
                                <asp:Label ID="lbldis" runat="server" Text="0"></asp:Label>
                            </div>
                        </div>


                        <div class="form-group">
                            <div class="col-md-2 ">
                                <label>Pending Fee:</label>
                            </div>
                            <div class="col-lg-10">
                                <asp:Label ID="lblpendingfee" runat="server" Text=""></asp:Label>
                            </div>

                        </div>
                    </asp:Panel>

                    <div class="form-group">
                        <div class="col-md-2 ">
                            <label>Amount</label>
                        </div>
                        <div class="col-lg-10">
                            <asp:TextBox CssClass="form-control" OnTextChanged="txtamount_TextChanged" AutoPostBack="true" Text="0"  ID="txtamount" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <div class="form-group" style="display: none">
                        <div class="col-md-2 ">
                            <label>Due Fee</label>
                        </div>
                        <div class="col-lg-10">
                            <asp:TextBox CssClass="form-control" ID="txtduefee" runat="server"></asp:TextBox>
                        </div>

                    </div>


                    <div class="form-group">
                        <div class="col-md-2 ">
                            <label>Discount</label>
                        </div>
                        <div class="col-lg-10">
                            <asp:TextBox CssClass="form-control" ID="txtdiscount" runat="server" Text="0.0" AutoPostBack="true"
                                OnTextChanged="txtdiscount_TextChanged"></asp:TextBox>
                        </div>
                    </div>

                    <asp:Panel ID="pnlcheque" runat="server" Visible="false">
                        <div class="form-group">
                            <div class="col-md-2 ">

                                <label>Cheque</label>
                            </div>
                            <div class="col-lg-10">
                                <asp:TextBox CssClass="form-control" ID="txtcheque" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnldraft" runat="server" Visible="false">
                        <div class="form-group">
                            <div class="col-md-2 ">
                                <label>Draft</label>
                            </div>
                            <div class="col-lg-10">
                                <asp:TextBox CssClass="form-control" ID="txtdraft" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="form-group">
                        <div class="col-md-2 ">
                            <label>Pending Status:</label>
                        </div>
                        <div class="col-lg-10">
                            <div class="radio radio-primary">
                                <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" runat="server">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem Selected="True">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>

                    </div>
                    <asp:Panel ID="pnlate" runat="server" Visible="false">
                        <div class="form-group">
                            <div class="col-md-2 ">
                                <label>Pending Fees</label>
                            </div>
                            <div class="col-lg-10">
                               
                                <asp:TextBox CssClass="form-control" ID="txtpendingfee" Text="0" runat="server"></asp:TextBox>
                                 <span>If fees pending fill the pending fees alert date</span>  
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2 ">
                                <label>Pending Fee Alert</label>
                            </div>
                            <div class="col-lg-10">
                                <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="txtpalert" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtpalert" PopupButtonID="Image1" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                    <span class="input-group-btn btn btn-default">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/auth/images/cal.png" Width="20" />
                                    </span>
                                </div>


                            </div>

                        </div>
                    </asp:Panel>
                    <div class="form-group" style="display: none">
                        <div class="col-md-2 ">
                            <label>Old Receipt No.</label>
                        </div>
                        <div class="col-lg-10">
                            <asp:TextBox CssClass="form-control" ID="txtoldreceiptno" Text="" runat="server" AutoPostBack="true"
                                OnTextChanged="txtoldreceiptno_TextChanged"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-2 ">
                            <label>Note</label>
                        </div>
                        <div class="col-lg-10">
                            <asp:TextBox CssClass="form-control" ID="txtnotice" TextMode="MultiLine" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <asp:Button ID="btndepost" CssClass="btn btn-default" runat="server" Width="70px"
                        ValidationGroup="g" OnClick="fvSubmit_Click" Text="Submit" />
                    <%--  <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="g" DisplayMode="BulletList" ShowSummary="false" ShowMessageBox="true" />--%>
                    &nbsp &nbsp
            <asp:Button ID="btnback" CssClass="btn bordered-link" float="right"
                runat="server" Text="Back to Profile" OnClick="btnback_Click" />

                </section>
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
                                                    <td class="auto-style5">No. :</td>
                                                    <td class="auto-style2"><b>
                                                        <asp:Label ID="lblrno" runat="server" Text=""><%=Reciptnumber %></asp:Label></b> </td>
                                                    <td class="auto-style3">&nbsp;</td>
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
                                                            <p style="border-bottom: 2px dotted black; float: left; width: 450px; margin: 0px; font-size: 14px; font-weight: bold; height: 24PX"><%=Cname %></p>
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
    <div class="loading" align="center">

        <img src="loader.gif" alt="" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>
    <script type="text/javascript">
        // When the document is ready
        $(document).ready(function () {

            $('.date').datepicker({
                format: "dd/mm/yyyy"
            });

        });
    </script>
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

