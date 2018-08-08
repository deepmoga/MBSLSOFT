<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Auth_Default" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">
    <style>
        .micon{    font-size: 22px;
    position: relative;
    top: 10px;}
        .micon i{color:dimgray}
        .tile-stats{color:white}
        .tile-stats a>h3{color:white}

    </style>
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
      <script type="text/javascript">
          function OpenPopUp23() {
              window.open('print-bill.aspx?ID=<%=txtreno.Text%>,<%=pendos%>,<%=courseid%>,<%=rollno%>,<%=txtddate.Text%>,0,<%=txtpfees.Text%>,reprint', 'MyWindow', 'width=500,height=600');
           return false;
       }
                </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="col-md-12">
        <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="tile-stats" style="background: #ff3838;">
                <a href="Dashboard-Dayalert.aspx">
                <div class="icon">
                    <i class="fa fa-bell-o" style="color: white"></i>
                </div>
                <div class="count">
                    <asp:Label ID="lbldaily" runat="server" Text=""></asp:Label></div>

                <h3>Day Alert</h3>
                <p>Check all Daiy Alert</p>
                </a>
            </div>
        </div>
        <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="tile-stats" style="background: lightseagreen;">
                <a href="Dashboard-Pending.aspx">
                <div class="icon">
                    <i class="fa fa-inr" style="color: white"></i>
                </div>
                <div class="count">
                    <asp:Label ID="lblpendo" runat="server" Text=""></asp:Label></div>

                <h3>Pending Fees</h3>
                <p>Show List Of Pending Fee</p>
                </a>
            </div>
        </div>
        <div class="animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12">
            <div class="tile-stats" style="    background: #3ea9de;">
                <a href="Dashboard-Inquiry.aspx">
                <div class="icon">
                    <i class="fa fa-mobile" style="color: white;"></i>
                </div>
                <div class="count">
                    <asp:Label ID="lblenq" runat="server" Text=""></asp:Label></div>

                <h3>Enquiry Alert</h3>
                <p>Daily Enquiry List</p>
                </a>
            </div>
        </div>
    </div>

    <div class="col-md-12">
        <asp:ListView ID="lvpages" runat="server">
            <ItemTemplate>
                <div class="animated flipInY col-lg-2 col-md-3 col-sm-6 col-xs-12">
                    <div class="tile-stats">
                        <a href="<%#Eval("url") %>">
                            <div class="text-center col-md-12 micon">
                                <i class="<%#Eval("icon") %>" ></i>
                            </div>
                           <div class="text-center col-md-12">
                                <h5><%# Eval("pname") %></h5>
                            </div>

                           
                           
                        </a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <div style="display:none">
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

                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>

                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>
    </div>

    <div class="col-md-7">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Pending Fees</h3>
            </div>
            <div class="panel-body">
                <asp:TextBox ID="txtdate2" OnTextChanged="txtdate2_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender runat="server"  Format="dd/MM/yyyy" TargetControlID="txtdate2" ID="txtdate2_CalendarExtender2"></ajaxToolkit:CalendarExtender>
                <asp:GridView ID="gvpending" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-bordered" OnRowCancelingEdit="gvpending_RowCancelingEdit" ShowHeaderWhenEmpty="true"
                    OnRowEditing="gvpending_RowEditing" OnRowUpdating="gvpending_RowUpdating" OnRowDataBound="gvpending_RowDataBound" OnRowCommand="gvpending_RowCommand">
                    <Columns>


                        <asp:TemplateField HeaderText="id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Roll No">
                            <ItemTemplate>
                                <asp:Label ID="lblroll" runat="server" Text='<%#Eval("rollno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Father's Name">
                            <ItemTemplate>
                                <asp:Label ID="lblfname" runat="server" Text='<%#Eval("fathername") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Course">
                            <ItemTemplate>
                                <asp:Label ID="lblcourse" runat="server" Text='<%#Eval("CourseName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pending Fees">
                            <ItemTemplate>
                                <asp:Label ID="lblfee" runat="server" Text='<%#Eval("Fees") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Due Date">
                            <ItemTemplate>
                                <asp:Label ID="lblpdate" runat="server" Text='<%#Eval("alertdate") %>'><%#Eval("alertdate") %></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lbledate" Visible="false" runat="server" Text='<%#Eval("alertdate") %>'></asp:Label>
                                <asp:TextBox ID="txtdate" runat="server" CssClass="date" Text='<%#Eval("alertdate") %>'></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" BehaviorID="txtdate_CalendarExtender" Format="MM/dd/yyyy" TargetControlID="txtdate" ID="txtdate_CalendarExtender"></ajaxToolkit:CalendarExtender>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text='Edit Date' CommandName="Edit" CssClass="label label-primary"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="pay" CommandArgument='<%#Eval("id") %>' CssClass=" label label-primary">Pay Now</asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" Text='Update' CssClass="label label-success" CommandName="Update"></asp:LinkButton>
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Cancel" CssClass="label label-danger" Text='Cancel'></asp:LinkButton>

                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="col-md-5">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Enquiry Alert</h3>
            </div>
            <div class="panel-body">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" CssClass="table table-bordered">
                    <Columns>
                        <asp:BoundField DataField="date" HeaderText="Alert Date" />
                        <asp:BoundField DataField="name" HeaderText="Name" />
                        <asp:BoundField DataField="contact" HeaderText="Phone" />
                        <asp:BoundField DataField="feedback" HeaderText="Last Reply" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton5" CommandName="view" CommandArgument='<%#Eval("inquiryid") %>' CssClass="label label-danger" runat="server">Profile</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
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
    <div class="row">
        <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
            data-toggle="modal" data-target="#myModal">
            Launch demo modal
        </button>
        <div class="modal fade" id="myModal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Pending Fees Deposit</h4>
                    </div>
                    <div class="modal-body">
                        <section role="form">

                            <div class="row">
                                <div class="text-left col-sm-6 form-group has-feedback">
                                    <label>Date</label>
                                    <asp:TextBox ID="txtddate" runat="server" class="form-control input-default" placeholder="Date"></asp:TextBox>

                                    <ajaxToolkit:CalendarExtender runat="server" Format="dd/MM/yyyy" BehaviorID="txtddate_CalendarExtender" TargetControlID="txtddate" ID="txtddate_CalendarExtender"></ajaxToolkit:CalendarExtender>
                                    <i class="glyphicon glyphicon-calendar form-control-feedback glyphiconalign"></i>
                                </div>
                                <div class="text-left col-sm-6 form-group has-feedback">
                                    <label>Recipt No</label>
                                    <asp:TextBox ID="txtreno" runat="server" class="form-control input-default" placeholder="Recipt No"></asp:TextBox>
                                    <i class="glyphicon glyphicon-user form-control-feedback glyphiconalign"></i>
                                </div>
                            </div>
                            <div class="row">
                                <div class="text-left col-sm-6 form-group has-feedback">
                                    <label>Name</label>
                                    <asp:TextBox ID="txtname" runat="server" class="form-control input-default" placeholder="Name"></asp:TextBox>
                                    <i class="glyphicon glyphicon-user form-control-feedback glyphiconalign"></i>
                                </div>
                                <div class="text-left col-sm-6 form-group has-feedback">
                                    <label>Father Name</label>
                                    <asp:TextBox ID="txtfname" runat="server" class="form-control input-default" placeholder="Father Name"></asp:TextBox>
                                    <i class="glyphicon glyphicon-earphone form-control-feedback glyphiconalign"></i>
                                </div>
                            </div>
                            <div class="form-group has-feedback">
                                <label>Course Name</label>
                                <asp:TextBox ID="txtcname" runat="server" class="form-control input-default" placeholder="Course Name"></asp:TextBox>
                                <i class="glyphicon glyphicon-envelope form-control-feedback"></i>
                            </div>
                            <div class="row">
                                <div class="col-sm-6 form-group">
                                    <label>Payment Type</label>
                                    <asp:DropDownList ID="ddlptype" class="form-control input-default" runat="server">
                                        <asp:ListItem>Cash</asp:ListItem>
                                        <asp:ListItem>Cheque</asp:ListItem>
                                        <asp:ListItem>Draft</asp:ListItem>
                                    </asp:DropDownList>
                                    <i class="glyphicon glyphicon-chevron-down "></i>
                                </div>
                                <div class="col-sm-6 form-group">
                                    <label>Type</label>
                                    <asp:TextBox ID="txttype" runat="server" class="form-control input-default" placeholder="Required If Type Cheque No / Draft No"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6 form-group">
                                    <label>Amount</label>
                                    <asp:TextBox ID="txtamt" runat="server" class="form-control input-default" placeholder="Amount"></asp:TextBox>

                                </div>
                                <div class="text-left col-sm-6 form-group has-feedback">
                                    <label>Pending Fees </label>
                                    <asp:TextBox ID="txtpfees" runat="server" class="form-control input-default" Text="0.0" placeholder="Optional"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="text-left form-group col-sm-6 has-feedback">
                                    <label>Pending Alert Date</label>
                                    <asp:TextBox ID="txtalertdate" runat="server" class="form-control input-default" placeholder="Pending Fees Alert Date Optional"></asp:TextBox>
                                    <i class="glyphicon glyphicon-lock form-control-feedback glyphiconalign"></i>
                                       <ajaxToolkit:CalendarExtender runat="server" Format="dd/MM/yyyy" BehaviorID="txtalertdate_CalendarExtender" TargetControlID="txtalertdate" ID="CalendarExtender2"></ajaxToolkit:CalendarExtender>

                                </div>
                                <div class="text-left form-group col-sm-6 has-feedback">
                                    <label>Remarks</label>
                                    <asp:TextBox ID="txtremarks" TextMode="MultiLine" runat="server" class="form-control input-default" placeholder="Remarks"></asp:TextBox>
                                    <i class="glyphicon glyphicon-lock form-control-feedback glyphiconalign"></i>
                                </div>
                            </div>
                    
                        </section>

                        <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-default" OnClick="Button1_Click" />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Close</button>

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
    </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">
    <script type="text/javascript">
        // When the document is ready
        $(document).ready(function () {

            $('.date').datepicker({
                format: "dd/mm/yyyy"
            });

        });
    </script>
    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }

    </script>
</asp:Content>

