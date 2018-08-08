<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="View-User.aspx.cs" Inherits="Auth_View_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
    User Account
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
     <div class="col-lg-12">
      <div class="up-lay griddesign">
        <div class="up-left">
            <h2 class="up-name">View User</h2>
        </div>
        <div class="up-right">
            <asp:Button ID="btnback" runat="server" Text="Back" CssClass="bordered-link" 
                onclick="btnback_Click" Height="46px"/>
            &nbsp;<asp:Button ID="btnadd" runat="server" Text="Add User" 
                CssClass="bordered-link" onclick="btnadd_Click" />
        </div>
    </div>
    <div class="table-responsive">
<asp:DataGrid ID="gridlist" runat="server" Width="100%" AutoGenerateColumns="false" 
            onitemcommand="gridlist_ItemCommand" 
            onitemdatabound="gridlist_ItemDataBound" >
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
                      Name
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("Name")%></div>
                </ItemTemplate>
              
        </asp:TemplateColumn>
             <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                      Phone No.
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("Phone_no")%></div>
                </ItemTemplate>
              
           </asp:TemplateColumn>
          <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                    User Type
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("Usertype")%></div>
                </ItemTemplate>
              
        </asp:TemplateColumn>
        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                      User Name
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("Username")%></div>
                </ItemTemplate>
              
        </asp:TemplateColumn>
        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                      Password
                </HeaderTemplate>
                <ItemTemplate > 
                    <asp:Label ID="lblpass" runat="server" Text='<%# Eval("Password")%>'></asp:Label>
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
                     <asp:ImageButton ToolTip='<%# Eval("Status").ToString() == "True" ? "Deactivate" :"Activate" %>' ImageUrl ='<%# Eval("Status").ToString() == "True" ? "images/active.jpg":"images/deactive.jpg" %>' ID="lbnActivate" runat="Server" CommandName='<%# Eval("Status").ToString() == "True" ? "Deactivate":"Activate" %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>'/>
                </td>
                   <td>                        
               <asp:ImageButton ToolTip="Edit "   runat="server" ID="lnkEdit" ImageUrl="images/edit.png"  CommandName="edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' /></td>
           
               </tr>
               </table>
                </ItemTemplate>
                   <HeaderStyle HorizontalAlign="center" />
                   <ItemStyle HorizontalAlign="center" />
            </asp:TemplateColumn>
        </Columns>
        <HeaderStyle BackColor="#1AE4D2" ForeColor="White" Font-Bold="true" HorizontalAlign="Center" />
</asp:DataGrid>
</div>
 </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpfotter" Runat="Server">
</asp:Content>

