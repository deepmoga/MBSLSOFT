<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="view-student.aspx.cs" Inherits="Auth_view_student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" runat="Server">


    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" runat="Server">
    Student
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" runat="Server">
    <div class="row">
        <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>






        <div class="col-md-12" style="overflow: scroll;display:none">

            <asp:GridView ID="GridView1" HeaderStyle-BackColor="#3AC0F2"
                HeaderStyle-ForeColor="White" CssClass="table table-bordered"
                runat="server" AutoGenerateColumns="false" OnDataBound="OnDataBound"
                OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" ItemStyle-Width="30" />
                    <asp:BoundField DataField="rollno" HeaderText="RollNo" ItemStyle-Width="100" />
                    <asp:BoundField DataField="name" HeaderText="Name" ItemStyle-Width="100" />
                    <asp:BoundField DataField="fathername" HeaderText="Father Name" ItemStyle-Width="100" />
                    <asp:BoundField DataField="phone" HeaderText="Contact" ItemStyle-Width="100" />
                    <asp:TemplateField>
                        <ItemTemplate>

                            <table class="abc">
                                <tr>


                                    <td>&nbsp;&nbsp;
            

               <asp:LinkButton ID="LinkButton2" ToolTip="View & Edit Details" ForeColor="white" CommandName="edit" CssClass="label label-info" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>'
                   Text="View" runat="server"></asp:LinkButton>
                                    </td>
                                    <td>&nbsp;  &nbsp;
           
                      <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return ConfirmDelete()" ToolTip="Delete Record" ForeColor="White" CssClass="label label-danger"
                          CommandName="delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' Text="Delete" Visible="false"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButton3" CommandName="deactive" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' runat="server" CssClass="label label-success">Active</asp:LinkButton>
                                    </td>

                                </tr>
                            </table>


                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
            </asp:GridView>


            <asp:GridView ID="GrdDetail" CssClass="table table-bordered" runat="server"
                CellPadding="4" AutoGenerateColumns="False" PageSize="20" AllowPaging="True"
                OnPageIndexChanging="GrdDetail_PageIndexChanging"
                BorderColor="black" BorderStyle="None" BorderWidth="1px"
                Style="width: 100%; display: none; text-align: center" OnRowCommand="GrdDetail_RowCommand"
                OnRowDataBound="GrdDetail_RowDataBound" OnRowDeleting="GrdDetail_RowDeleting">

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
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("id")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="RollNo" SortExpression="rollno">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("rollno")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("name")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Father's Name">
                        <ItemTemplate>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("fathername")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DOB">
                        <ItemTemplate>
                            <asp:Label ID="lbldob" runat="server" Text='<%#Eval("dob")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ContactNo">
                        <ItemTemplate>
                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("phone")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField>
                        <ItemTemplate>

                            <table>
                                <tr>


                                    <td>&nbsp;&nbsp;
            

               
                                    </td>
                                    <td>&nbsp;  &nbsp;
           
                      <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return ConfirmDelete()" ToolTip="Delete Record" ForeColor="White" CssClass="label label-danger"
                          CommandName="delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' Text="Delete"></asp:LinkButton>
                                    </td>
                                     <td>
                                        <asp:LinkButton ID="LinkButton3" CommandName="deactive" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' runat="server" CssClass="label label-success">Active</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>


                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
                <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
            </asp:GridView>
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
                        <h4 class="modal-title">Your Header here</h4>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Enter Admin Password</label>
                            <input type="text" class="form-control" id="txtname" placeholder="Name" runat="server">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" Text="Please Enter Password" ValidationGroup="g1" ErrorMessage="Please Enter Password"></asp:RequiredFieldValidator>
                        </div>


                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn btn-default" ValidationGroup="g1" OnClick="btnsubmit_Click" />
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

    <div class="row">
        <div class=" filterable">
            <%--<div class="panel-heading">
                <h3 class="panel-title">Users</h3>
                <div class="pull-right">
                    <button class="btn btn-default btn-xs btn-filter"><span class="glyphicon glyphicon-filter"></span>Filter</button>
                </div>
            </div>--%>
            <table class="table">
                <thead>
                    <tr class="filters">
                        <th>
                            SNo.
                        </th>
                        <th>
                            <input type="text" class="form-control" placeholder="Id"></th>
                        <th>
                            <input type="text" class="form-control" placeholder="RollNo"></th>
                        <th>
                            <input type="text" class="form-control" placeholder="Name"></th>
                        <th>
                            <input type="text" class="form-control" placeholder="Father's Name"></th>
                        <th>
                            <input type="text" class="form-control" placeholder="Contact"></th>
                        <th>
                           
                            <input type="text" class="form-control" readonly="readonly" placeholder="Photo"></th>
                        <th>
                            <input type="text" class="form-control" readonly="readonly" placeholder="Action"></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="ListView2" runat="server" OnItemCommand="ListView2_ItemCommand" >
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.DataItemIndex+1 %></td>
                                <td><%#Eval("id") %></td>
                                <td><%#Eval("rollno") %></td>
                                <td><%#Eval("name") %></td>
                                <td><%#Eval("fathername") %></td>

                                <td><%#Eval("phone") %></td>
                                
                                
                                <td><img src="../uploadimage/<%#Eval("image") %>" width="80" /> </td>
                                <td>
                                    <asp:LinkButton ToolTip="View & Edit Details" ForeColor="white" CommandName="edit" CssClass="label label-info" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' Text="View" runat="server"></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" CommandName="deactive" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' runat="server" CssClass="label label-danger">DeActive</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton4" OnClick="LinkButton4_Click" CommandArgument='<%#Eval("rollno") %>' CssClass="label label-warning" runat="server">Delete</asp:LinkButton>

                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>


                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" runat="Server">

<%--    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <script src="../quicksearch.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('.search_textbox').each(function (i) {
                $(this).quicksearch("[id*=GridView1] tr:not(:has(th))", {
                    'testQuery': function (query, txt, row) {
                        return $(row).children(":eq(" + i + ")").text().toLowerCase().indexOf(query[0].toLowerCase()) != -1;
                    }
                });
            });
        });
    </script>--%>
    <script>
        $(document).ready(function () {
            $('.filterable .btn-filter').click(function () {
                var $panel = $(this).parents('.filterable'),
                $filters = $panel.find('.filters input'),
                $tbody = $panel.find('.table tbody');
                if ($filters.prop('disabled') == true) {
                    $filters.prop('disabled', false);
                    $filters.first().focus();
                } else {
                    $filters.val('').prop('disabled', true);
                    $tbody.find('.no-result').remove();
                    $tbody.find('tr').show();
                }
            });

            $('.filterable .filters input').keyup(function (e) {
                /* Ignore tab key */
                var code = e.keyCode || e.which;
                if (code == '9') return;
                /* Useful DOM data and selectors */
                var $input = $(this),
                inputContent = $input.val().toLowerCase(),
                $panel = $input.parents('.filterable'),
                column = $panel.find('.filters th').index($input.parents('th')),
                $table = $panel.find('.table'),
                $rows = $table.find('tbody tr');
                /* Dirtiest filter function ever ;) */
                var $filteredRows = $rows.filter(function () {
                    var value = $(this).find('td').eq(column).text().toLowerCase();
                    return value.indexOf(inputContent) === -1;
                });
                /* Clean previous no-result if exist */
                $table.find('tbody .no-result').remove();
                /* Show all rows, hide filtered ones (never do that outside of a demo ! xD) */
                $rows.show();
                $filteredRows.hide();
                /* Prepend no-result row if all rows are filtered */
                if ($filteredRows.length === $rows.length) {
                    $table.find('tbody').prepend($('<tr class="no-result text-center"><td colspan="' + $table.find('.filters th').length + '">No result found</td></tr>'));
                }
            });
        });
    </script>
    
</asp:Content>

