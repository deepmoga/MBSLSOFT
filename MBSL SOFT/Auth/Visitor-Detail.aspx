<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Visitor-Detail.aspx.cs" Inherits="Auth_Visitor_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
        <div class="panel with-nav-tabs panel-default">
                <div class="panel-heading">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab1default" data-toggle="tab">FeedBack</a></li>
                            <li><a href="#tab2default" data-toggle="tab">Logs</a></li>
                            
                        </ul>
                </div>
                <div class="panel-body">
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="tab1default">
            <section class="col-md-8 col-md-offset-1">
                
                <div class="form-group">

            <label for="inputPassword3" class="col-sm-2 control-label">Follow Us</label>
            <div class="col-sm-10">
                <div class="col-md-6">
                    <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control">
                        <asp:ListItem>Select Type</asp:ListItem>
                        <asp:ListItem>Days</asp:ListItem>
                        <asp:ListItem>Months</asp:ListItem>
                        <asp:ListItem>Years</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtdays" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                
            </div>
        </div>
                <div class="form-group">
                    <label for="inputPassword3" class="col-sm-2 control-label">FeedBack</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtfeed" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    </div>
                <div class="form-group">
                    <label for="inputPassword3" class="col-sm-2 control-label">Status</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlstatus" runat="server" CssClass="form-control">
                            <asp:ListItem>Select Status</asp:ListItem>
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>DeActive</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">

                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-default" OnClick="btnsubmit_Click" />
                    </div>
                </div>
            </section>
                        </div>
                        <div class="tab-pane fade" id="tab2default">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass=" table table-bordered">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="ID" />
                                    <asp:BoundField DataField="date" HeaderText="Added Date" />
                                    <asp:BoundField DataField="feedback" HeaderText="Response" />
                                    <asp:BoundField DataField="days" HeaderText="Value" />
                                    <asp:BoundField DataField="type" HeaderText="Type" />
                                     <asp:BoundField DataField="status" HeaderText="Status" />
                                  
                                </Columns>
                            </asp:GridView>
                        </div>
                        
                    </div>
                </div>
            </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

