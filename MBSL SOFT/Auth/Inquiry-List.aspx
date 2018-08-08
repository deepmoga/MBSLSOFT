<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Inquiry-List.aspx.cs" Inherits="Auth_Inquiry_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    Enquiry List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <asp:Button ID="Button1" OnClick="Button1_Click" CssClass="btn btn-default" runat="server" Text="Add Enquiry" />
    <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" runat="server" AutoGenerateColumns="false" CssClass=" table table-bordered">
        <Columns>
            <asp:TemplateField HeaderText="Alert Date">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lbldate" Text= '<%#Eval("date") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="name" HeaderText="Name" />
           <asp:TemplateField HeaderText="Course">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblname" Text= '<%#Eval("coursename") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="contact" HeaderText="Phone" />
          
            <asp:TemplateField HeaderText="No Of Visit">
                <ItemTemplate>
                    <asp:HiddenField ID="hfid" Value='<%#Eval("inquiryid") %>' runat="server" />
                    <asp:LinkButton ID="lnkvisit" runat="server" CssClass="label label-warning"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" CommandName="detail" CommandArgument='<%#Eval("inquiryid") %>' CssClass="label label-info"  runat="server">Detail</asp:LinkButton>
                    <asp:LinkButton ID="lnkedit" CommandName="edit" CommandArgument='<%#Eval("inquiryid") %>' runat="server" CssClass="label label-info">Inquiry FeedBack</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" CommandName="delete" CommandArgument='<%#Eval("inquiryid") %>' runat="server" CssClass="label label-danger">Inquiry Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
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
</asp:Content>

