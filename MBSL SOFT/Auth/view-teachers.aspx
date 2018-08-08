<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="view-teachers.aspx.cs" Inherits="Auth_view_teachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
<script type="text/javascript">
    $(document).ready(function () {
        $('#clickme').click(function () {
            $('.me').animate({
                height: 'toggle'
            }, 1000
          );
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
  <asp:Label ID="lblcode" runat="server" Text="" Visible="false"></asp:Label>
    <div class="col-md-12 text-right">
            <asp:Button ID="btnadd" runat="server" Text="Add" CssClass=" btn btn-success" 
                onclick="btnadd_Click" />
            <asp:Button ID="btnback" runat="server" Text="Back" CssClass=" btn btn-danger" 
                onclick="btnback_Click"/>
        </div>
        <asp:Panel ID="pnlsearch" runat="server">
        
    <div class="togle me">
        <asp:DropDownList ID="ddlfranchisee" runat="server" Width="195px">
        </asp:DropDownList>
        <asp:Button ID="btnsearch" runat="server" Text="go" CssClass="bordered-link" 
            onclick="btnsearch_Click" />
       
    </div>
    </asp:Panel>
   <div class="col-md-12">

<asp:GridView ID="GrdDetail" CssClass=" table table-bordered" runat="server" 
        CellPadding="4" AutoGenerateColumns="False"   PageSize="20" AllowPaging="True"  
        BorderColor="black" BorderStyle="None" BorderWidth="1px" 
            style=" width:100%; text-align:center" 
            onpageindexchanging="GrdDetail_PageIndexChanging" 
            onrowcommand="GrdDetail_RowCommand" onrowdatabound="GrdDetail_RowDataBound" 
            onrowediting="GrdDetail_RowEditing" class="table table-bordered">
    
        <FooterStyle BackColor="#323b44" ForeColor="White" />
        <HeaderStyle BackColor="#323b44" Font-Size="14px" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
        <PagerStyle BackColor="#323b44" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle  ForeColor="#333333" />
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
                            <asp:Label ID="lblcode" Visible="false" runat="server" Text='<%#Eval("teachercode")  %>'></asp:Label>
                      </ItemTemplate>
                   </asp:TemplateField>
         
                  <asp:TemplateField  HeaderText="Teacher Name">
                        <ItemTemplate>
                              <asp:Label ID="lblname" runat="server" Text='<%#Eval("teachername")  %>'></asp:Label>
                        </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField  HeaderText="Father Name">
                        <ItemTemplate>
                             <asp:Label ID="lblfather" runat="server" Text='<%#Eval("fathername")  %>'></asp:Label>
                        </ItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField  HeaderText="DOB">
                      <ItemTemplate>
                             <asp:Label ID="lbldob" runat="server" Text='<%#Eval("dob")  %>'></asp:Label>
                      </ItemTemplate>
                 </asp:TemplateField>
            
                


                <asp:TemplateField  HeaderText="ContactNo">
                      <ItemTemplate>
                               <asp:Label ID="lblcontact" runat="server" Text='<%#Eval("phone")  %>'></asp:Label>
                       </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Address">
                       <ItemTemplate>
                            <asp:Label ID="lbladdress" runat="server" Text='<%#Eval("address")  %>'></asp:Label>
                      </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Email">
                     <ItemTemplate>
                           <asp:Label ID="lblemail" runat="server" Text='<%#Eval("email")  %>'></asp:Label>
                     </ItemTemplate>
                </asp:TemplateField>
              <%--  <asp:TemplateField  HeaderText="Franchisee">
                      <ItemTemplate>
                           <asp:Label ID="lblfranchisee" runat="server" Text='<%#Eval("centercode")  %>'></asp:Label>
                      </ItemTemplate>
               </asp:TemplateField>--%>
              <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
             
                 <table>
                   <tr>
                     <td> &nbsp;&nbsp;
                         <asp:ImageButton ID="lnkEdt" ImageUrl="images/edit.png" ToolTip="View & Edit Details" ForeColor="#0bb697"  CommandName="edit"  CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>' Text="View & Edit"  runat="server" style="border-radius:3px;" />

                         <asp:LinkButton ID="LinkButton1"  runat="server"></asp:LinkButton>
                    </td>
                   <td>&nbsp;  &nbsp;
                       <asp:ImageButton ToolTip='<%# Eval("status").ToString() == "True" ? "Deactivate Doctor":"Activate Doctor" %>' ImageUrl ='<%# Eval("status").ToString() == "True" ? "images/active.jpg":"images/deactive.jpg" %>' ID="lbnActivate" runat="Server" CommandName='<%# Eval("status").ToString() == "True" ? "Deactivate":"Activate" %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>'/>

                  </td>
                  
                </tr>
             </table>
             </ItemTemplate>
             </asp:TemplateField>
        </Columns>
       
     </asp:GridView>
   </div>
  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

