<%@ Page Title="" Language="C#" MasterPageFile="~/Auth/main.master" AutoEventWireup="true" CodeFile="view-file.aspx.cs" Inherits="Auth_view_file" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cptitle" Runat="Server">
File
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpmain" Runat="Server">
<div class="col-lg-12">
      <div class="up-lay griddesign">
         <div class="col-md-8">
            <h2 class="up-name">View File</h2>
        </div>
        <div class="col-md-4 text-right">
            <asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn btn-danger" 
                onclick="btnback_Click"/>
            &nbsp;<asp:Button ID="btnadd" runat="server" Text="Add File" 
                CssClass="btn btn-success" onclick="btnadd_Click" />
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
                      Name
                </HeaderTemplate>
                <ItemTemplate > 
                     <div style=" text-align:center"><%# Eval("Name")%></div>
                </ItemTemplate>
              
        </asp:TemplateColumn>
             <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
         
                <HeaderTemplate>
                      File
                </HeaderTemplate>
                <ItemTemplate > 
                 <div style=" text-align:center"><%# Eval("File_Val")%></div>
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

