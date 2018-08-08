<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="viewcourse.aspx.cs" Inherits="Auth_viewcourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
 <link rel="stylesheet" href="../admin/css/jquery-ui.css" />
    <script src="../admin/js/jquery-1.8.3.js" type="text/javascript" language="javascript"></script>

    <script src="../admin/js/jquery-ui.js" type="text/javascript" language="javascript"></script>
    	<script src="../admin/js/jquery.min.js" type="text/javascript"></script>
			<script src="../admin/js/jquery-ui.min.js" type="text/javascript"></script>
            <script type="text/javascript" language="javascript">
   function LoadList()
    {      
    
     
        var ds=null;
        ds = <%=listFilter %>;
            $( "#<%=txtCourseFilter.ClientID %>" ).autocomplete({
              source: ds
            });
            }
</script>

            <script>

                function ConfirmDelete() {
                    if (confirm("Do you want to delete this Course?")) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
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
    <center>
    <asp:TextBox ID="txtCourseFilter" CssClass="txtbox" Width="150px" runat="server"></asp:TextBox>
    <asp:Button ID="CourseFilter" CssClass="btn" runat="server" Width="60px" Height="30px"  
        Text="Search" onclick="CourseFilter_Click"/>
    <asp:Button ID="View_all" runat="server" Text="All" CssClass="btn"  
        Width="50px" Height="30px" onclick="View_all_Click"/>
</center>

  <div class="col-md-12">
<asp:DataGrid ID="gridlist" runat="server" Width="100%" AutoGenerateColumns="false" 
            onitemcommand="gridlist_ItemCommand" class="table table-bordered">
 <Columns>
            <asp:TemplateColumn >
                <HeaderTemplate>
                    #</HeaderTemplate>
                <ItemTemplate>
                    &nbsp;&nbsp;<%# Container.DataSetIndex+1 %>
                </ItemTemplate>
            </asp:TemplateColumn>

             <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                  Course Id
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("CourseId")%></div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>
         <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                 Course Name
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("CourseName")%></div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>
         <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" Visible="false">
         
                <HeaderTemplate>
                  Course Type
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("CourseType")%></div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>
          <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" Visible="false">
         
                <HeaderTemplate>
                  Duration
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("Duration")%></div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>
          <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" Visible="false">
         
                <HeaderTemplate>
                  Eligibility
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("Eligibilty")%></div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>
         <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                  Fees
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("Fees")%></div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>
     <asp:BoundColumn DataField="twomonth" HeaderText="2 Month"></asp:BoundColumn>
      <asp:BoundColumn DataField="threemonth" HeaderText="3 Month"></asp:BoundColumn>
      <asp:BoundColumn DataField="fourmonth" HeaderText="4 Month"></asp:BoundColumn>
        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" Visible="false">
         
                <HeaderTemplate>
                  No. Of Instalments
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("no_of_insatalments")%></div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>

        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" Visible="false">
         
                <HeaderTemplate>
                 Amount Of Instalment
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("instalment_amount")%></div>
                   
                </ItemTemplate>
              
        </asp:TemplateColumn>

          <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" Visible="false">
         
                <HeaderTemplate>
                Minimum Hours
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("MinHour")%></div>
                   
                </ItemTemplate>
            
        </asp:TemplateColumn>
          <asp:TemplateColumn>
                <HeaderTemplate>
                Action
                </HeaderTemplate>
                <ItemTemplate>
                         <table>
               <tr>
                        
               <td> &nbsp;
               <asp:ImageButton ToolTip="Edit "   runat="server" ID="lnkEdit" ImageUrl="images/edit.png"  CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' /></td>
                  <td>&nbsp;  <asp:ImageButton ToolTip="Delete"  OnClientClick="return ConfirmDelete()" runat="server" ID="ImageButton1" ImageUrl="images/delete.png"  CommandName="delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' /></td>
                   
               </tr>
               </table>
                </ItemTemplate>
                   <HeaderStyle HorizontalAlign="center" />
                   <ItemStyle HorizontalAlign="center" />
            </asp:TemplateColumn>
        </Columns>
        <HeaderStyle BackColor="#34D1BE" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
    </asp:DataGrid>
    
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

