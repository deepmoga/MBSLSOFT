<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="View-contact.aspx.cs" Inherits="Auth_View_contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
  Contacts
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
    <div class="col-lg-12">
      <div class="up-lay griddesign">
      <div class="col-md-8">
            <h2 class="up-name">View Contact</h2>
        </div>
        <div class="col-md-4 text-right">
            <asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn btn-danger" 
                onclick="btnback_Click" />
       
        </div>
    </div>
    <div class="col-md-12">
<asp:DataGrid ID="gridlist" runat="server" Width="100%" AutoGenerateColumns="false" 
            onitemcommand="gridlist_ItemCommand" class="table table-striped responsive-utilities jambo_table bulk_action">
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
                      Address
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("address")%></div>
                </ItemTemplate>
              
        </asp:TemplateColumn>
             <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                      Phone
                </HeaderTemplate>
                <ItemTemplate > 
                 <div style=" text-align:center"><%# Eval("phone")%></div>
                </ItemTemplate>
              
           </asp:TemplateColumn>
                 <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                 Email
                </HeaderTemplate>
                <ItemTemplate > 
                 <div style=" text-align:center"><%# Eval("email")%></div>
                </ItemTemplate>
              
           </asp:TemplateColumn>
           <asp:TemplateColumn>
                <HeaderTemplate>
                Action
                </HeaderTemplate>
                <ItemTemplate>
                         <table>
               <tr>
               
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

