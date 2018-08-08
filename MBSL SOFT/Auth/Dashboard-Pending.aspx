<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Dashboard-Pending.aspx.cs" Inherits="Auth_Dashboard_Pending" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
      <script src="../jquery.js"></script>
    <%--<script type="text/javascript">
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
    </script>--%>
      <script type="text/javascript">
          function OpenPopUp23() {
              window.open('print-bill.aspx?ID=<%=txtreno.Text%>,<%=pendos%>,<%=courseid%>,<%=rollno%>,<%=txtddate.Text%>,0,<%=txtpfees.Text%>,reprint', 'MyWindow', 'width=500,height=600');
           return false;
       }
                </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-md-12">
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
                                <asp:Label ID="lblpdate" runat="server" Text=''><%# Convert.ToDateTime (Eval("alertdate")).ToString("dd/MM/yyyy") %></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lbledate" Visible="false" runat="server" Text='<%#Eval("alertdate") %>'></asp:Label>
                                <asp:TextBox ID="txtdate" runat="server" CssClass="date" Text='<%#Eval("alertdate") %>'></asp:TextBox>
                                <ajaxToolkit:CalendarExtender runat="server" BehaviorID="txtdate_CalendarExtender" Format="dd/MM/yyyy" TargetControlID="txtdate" ID="txtdate_CalendarExtender"></ajaxToolkit:CalendarExtender>
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
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

