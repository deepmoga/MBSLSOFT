<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="Full-Detail.aspx.cs" Inherits="Auth_Full_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
      <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>

    <div class="col-md-12">
    <div class="col-md-6">
    Roll No : 
    <asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>
    <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnsearch_Click" />
        </div>
    <div class="col-md-6 text-right">
        <asp:Label ID="lblstatus" runat="server" Text=""></asp:Label>
    </div>
        </div>
    <div class="col-md-12">
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">Assign Course</div>
            <div class="panel-body" style="overflow:scroll">
                <asp:GridView ID="GrdDetail" CssClass=" table table-bordered" runat="server" 
        CellPadding="4" AutoGenerateColumns="False" OnRowDataBound="GrdDetail_RowDataBound" >
    
       <FooterStyle BackColor="#323b44" ForeColor="White" />
        <HeaderStyle BackColor="#323b44" Font-Size="14px" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#323b44" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
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

          <asp:TemplateField  HeaderText="CourseId" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblcid" runat="server" Text='<%#Eval("CourseId")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

           
            <asp:TemplateField  HeaderText="Course Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("CourseName")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          
           

                              <asp:TemplateField  HeaderText="Addmission Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbladmitdate" runat="server" Text='<%#Eval("AdmitDate")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText="Course End Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblend" runat="server" Text='<%#Eval("enddate")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField  HeaderText="Fees">
                                <ItemTemplate>
                                    <asp:Label ID="lblfee" runat="server" Text='<%#Eval("Fees")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
           
                               <asp:TemplateField  HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("Status")  %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             
                    <asp:TemplateField Visible="false" >
         <ItemTemplate>
             <table>
               <tr>
                     <td> &nbsp;&nbsp;
                          <asp:LinkButton ID="lnkEdt" ToolTip="Edit Time" ForeColor="white"  CommandName="time"  CommandArgument='<%#Eval("Id") + ";" +Eval("Time")+ ";" +Eval("CourseId")%>' Text="Edit" CssClass="label label-info"  runat="server"></asp:LinkButton>
                                          <asp:LinkButton ID="lnkdeac" CssClass="label label-danger" CommandName="deactive" CommandArgument='<%#Eval("Id")  %>' runat="server">Deactive</asp:LinkButton>

                          </td>
                   <td>
                      
                   </td>
                    
                  
              </tr>
           </table>
       </ItemTemplate>               
     </asp:TemplateField>
    </Columns>
       
    </asp:GridView>
            </div>
        </div>
    </div>
     
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">Fees Logs</div>
            <div class="panel-body">
              
    <br />
  <asp:GridView ID="GridView1" CssClass=" table table-bordered" runat="server"
            CellPadding="4" AutoGenerateColumns="False" PageSize="20" AllowPaging="True"
            BorderStyle="None" BorderWidth="1px"
            Style="width: 100%; text-align: center"
            OnRowDataBound="GridView1_RowDataBound1" class="table table-bordered" OnRowCommand="GridView1_RowCommand1" >

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
                        /
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
                        /
                        <asp:Label ID="Label2" CssClass="btn label label-danger" runat="server" Text='<%#Eval("pending_fees")  %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Action" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="cancel" CssClass="label label-info" CommandArgument='<%#Eval("id")+","+Eval("date")+","+Eval("tokenno")+","+Eval("totalfees")+","+Eval("courseid") %>'>Cancel</asp:LinkButton>

                        <asp:LinkButton ID="lnkslipdel" runat="server" CommandName="reprint" CssClass="label label-danger" CommandArgument='<%#Eval("id") %>'>Print Slip</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
            </div>
        </div>
    </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

